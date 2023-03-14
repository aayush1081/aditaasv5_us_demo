using System;
using System.Linq;
using System.Collections.Generic;

namespace Kendo.Mvc.Grid.CRUD.Models
{
    /// <summary>
    /// Represents a filter expression of Kendo DataSource.
    /// </summary>
    public class Filter : ICloneable
    {
        /// <summary>
        /// Gets or sets the name of the sorted field (property). Set to <c>null</c> if the <c>Filters</c> property is set.
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// Gets or sets the filtering operator. Set to <c>null</c> if the <c>Filters</c> property is set.
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        /// Gets or sets the filtering value. Set to <c>null</c> if the <c>Filters</c> property is set.
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Gets or sets the filtering logic. Can be set to "or" or "and". Set to <c>null</c> unless <c>Filters</c> is set.
        /// </summary>
        public string Logic { get; set; }

        public string DataType { get; set; }

        /// <summary>
        /// Gets or sets the child filter expressions. Set to <c>null</c> if there are no child expressions.
        /// </summary>
        public IEnumerable<Filter> Filters { get; set; }
        public string DateFormat { get; set; }
        public string TimeZone { get; set; }

        /// <summary>
        /// Mapping of Kendo DataSource filtering operators to Dynamic Linq
        /// </summary>
        private static readonly IDictionary<string, string> operators = new Dictionary<string, string>
    {
        {"eq", "="},
        {"neq", "!="},
        {"lt", "<"},
        {"lte", "<="},
        {"gt", ">"},
        {"gte", ">="},
        {"startswith", "StartsWith"},
        {"endswith", "EndsWith"},
        {"contains", "Contains"},
        {"doesnotcontain", "DoesNotContains"},

        {"isnull", "IS NULL"},
        {"isnotnull", "IS NOT NULL"},
        {"isnullorempty", "isnullorempty"},
        {"isnotnullorempty", "isnotnullorempty"},
    };

        /// <summary>
        /// Get a flattened list of all child filter expressions.
        /// </summary>
        public IList<Filter> All()
        {
            var filters = new List<Filter>();

            Collect(filters);

            return filters;
        }

        private void Collect(IList<Filter> filters)
        {
            if (Filters != null && Filters.Any())
            {
                foreach (Filter filter in Filters)
                {
                    filters.Add(filter);

                    filter.Collect(filters);
                }
            }
            else
            {
                filters.Add(this);
            }
        }

        /// <summary>
        /// Converts the filter expression to a predicate suitable for Dynamic Linq e.g. "Field1 = @1 and Field2.Contains(@2)"
        /// </summary>
        /// <param name="filters">A list of flattened filters.</param>
        public string ToExpression(IList<Filter> filters)
        {
            if (Filters != null && Filters.Any())
            {
                return "(" + String.Join(" " + Logic + " ", Filters.Select(filter => filter.ToExpression(filters)).ToArray()) + ")";
            }

            int index = filters.IndexOf(this);

            string comparison = operators[Operator];

            if (comparison == "StartsWith" || comparison == "EndsWith" || comparison == "Contains")
            {
                return String.Format("({0}).ToLower().{1}(@{2})", Field, comparison, index);
            }

            if (comparison == "DoesNotContains")
            {
                return String.Format("!({0}).ToLower().{1}(@{2})", Field, "Contains", index);
            }

            if (comparison == "IS NULL" || comparison == "IS NOT NULL")
            {
                return String.Format("({0}) {1}", Field, comparison);
            }
            if (comparison == "isnullorempty")
            {
                return String.Format("String.IsNullOrEmpty({0})", Field);
            }
            if (comparison == "isnotnullorempty")
            {
                return String.Format("!String.IsNullOrEmpty({0})", Field);
            }

            if (DataType == "String")
                return String.Format("({0}).ToLower() {1} @{2}", Field, comparison, index);
            else
                return String.Format("({0}) {1} @{2}", Field, comparison, index);
        }

        public string ToSqlExpression(IList<Filter> filters)
        {
            if (Filters != null && Filters.Any())
            {
                return "(" + String.Join(" " + Logic + " ", Filters.Select(filter => filter.ToSqlExpression(filters)).ToArray()) + ")";
            }

            int index = filters.IndexOf(this);

            string comparison = operators[Operator];
            if (Value != null)
                Value = Value.ToString().ToLower().Replace("'","''");

            if (comparison == "StartsWith" || comparison == "EndsWith" || comparison == "Contains" || comparison == "DoesNotContains")
            {
                if (comparison == "StartsWith")
                    return String.Format("lower({0}) like '{1}%'", Field, Value);
                else if (comparison == "EndsWith")
                    return String.Format("lower({0}) like '%{1}'", Field, Value);
                else if (comparison == "Contains")
                    return String.Format("lower({0}) like '%{1}%'", Field, Value);
                else if (comparison == "DoesNotContains")
                    return String.Format("lower({0}) not like '%{1}%'", Field, Value);
            }
            else if (comparison == "IS NULL" || comparison == "IS NOT NULL")
            {
                    return String.Format("({0}) {1}", Field, comparison);
            }
            else if (comparison == "isnullorempty")
            {
                if (DataType == "string")
                    return String.Format("({0} IS NULL OR {0}='')", Field);
                else
                    return String.Format(" {0} IS NULL ", Field);
            }
            else if (comparison == "isnotnullorempty")
            {
                if (DataType == "string")
                    return String.Format("({0} IS NOT NULL AND {0}<>'')", Field);
                else
                    return String.Format(" {0} IS NOT NULL ", Field);
            }

            if (DataType == "string")
                return String.Format("lower(({0}) {1} '{2}'", Field, comparison, Value);
            else
                return String.Format("{0} {1} '{2}'", Field, comparison, Value);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
