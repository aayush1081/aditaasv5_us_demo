using aditaas_v5.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

namespace Kendo.Mvc.Grid.CRUD.Models
{
    public static class QueryableExtensions
    {
        /// <summary>
        /// Applies data processing (paging, sorting and filtering) over IQueryable using Dynamic Linq.
        /// </summary>
        /// <typeparam name="T">The type of the IQueryable</typeparam>
        /// <param name="queryable">The IQueryable which should be processed.</param>
        /// <param name="take">Specifies how many items to take. Configurable via the pageSize setting of the Kendo DataSource.</param>
        /// <param name="skip">Specifies how many items to skip.</param>
        /// <param name="sort">Specifies the current sort order.</param>
        /// <param name="filter">Specifies the current filter.</param>
        /// <returns>A DataSourceResult object populated from the processed IQueryable.</returns>
        public static DataSourceResult ToDataSourceResult<T>(this IQueryable<T> queryable, int take, int skip, IEnumerable<Sort> sort, Filter filter)
        {
            // Filter the data first
            queryable = Filter(queryable, filter);

            // Calculate the total number of records (needed for paging)
            var total = queryable.Count();

            // Sort the data
            queryable = Sort(queryable, sort);

            // Finally page the data
            queryable = Page(queryable, take, skip);

            return new DataSourceResult
            {
                Data = queryable.ToList(),
                Total = total
            };
        }

        public static DataSourceResult ToDataSourceResult<T>(this IQueryable<T> queryable, Filter filter)
        {
            // Filter the data first
            queryable = Filter(queryable, filter);

            return new DataSourceResult
            {
                Data = queryable.ToList(),
                Total = 0
            };
        }

        private static IQueryable<T> Filter<T>(IQueryable<T> queryable, Filter filter)
        {
            if (filter != null && filter.Logic != null)
            {
                // Collect a flat list of all filters
                var filters = filter.All().Distinct().ToList();

                string DateFormat = filter.DateFormat;
                string TimeZone = filter.TimeZone;

                foreach (var dfilter in filters.Where(a => a.Field != "" && a.Field != null))
                {
                    var propinf = queryable.ElementType.GetProperty(dfilter.Field);
                    if (propinf == null)
                        propinf = queryable.ElementType.GetProperty(dfilter.Field.Substring(0, 1).ToUpper() + dfilter.Field.Substring(1));

                    var proptype = propinf.PropertyType;
                    if (proptype == typeof(string))
                        dfilter.DataType = "String";
                    else if ((proptype == typeof(DateTime) || proptype == typeof(DateTime?)))
                    {
                        if(dfilter.DataType != "DateTime")
                            dfilter.DataType = "Other";

                        if (dfilter.Value != null)
                        {
                            var newDateTime = new DateTime();
                            var issuccess = DateTime.TryParseExact(Convert.ToString(dfilter.Value), DateFormat, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out newDateTime);
                            if(issuccess)
                            {
                                var startOftheDay = new DateTime(newDateTime.Year, newDateTime.Month, newDateTime.Day);
                                var startOftheDayUTC = TimeZoneInfo.ConvertTimeToUtc(startOftheDay, GlobalClass.GetTimeZoneByName(TimeZone));
                                                                
                                dfilter.Value = startOftheDayUTC;
                                if (dfilter.Operator == "eq")
                                {
                                    dfilter.Operator = "gte";
                                    dfilter.DataType = "DateTime";
                                }   
                            }
                        }
                        
                    }
                    else
                        dfilter.DataType = "Other";
                }

                var newArray = filters.Where(f => f.DataType == "DateTime").ToArray();
                foreach (var dtFilter in newArray)
                {
                    var indexoffilter = filters.IndexOf(dtFilter);
                    var flist = new List<Filter>();

                    flist.Add((Filter)dtFilter.Clone());

                    var newFilter = new Filter();
                    newFilter.Field = dtFilter.Field;
                    newFilter.DataType = "DateTime";
                    newFilter.Value = DateTime.Now;
                    newFilter.Operator = "lte";
                   
                    newFilter.Value = ((DateTime)dtFilter.Value).AddHours(23).AddMinutes(59).AddSeconds(59);

                    flist.Add(newFilter);
                    dtFilter.Filters = flist;

                    dtFilter.DataType = null;
                    dtFilter.DateFormat = null;
                    dtFilter.Field = null;
                    dtFilter.Logic = "and";
                    dtFilter.Operator = null;
                    dtFilter.Value = null;

                    filters.AddRange(dtFilter.Filters);
                }

                // Get all filter values as array (needed by the Where method of Dynamic Linq)
                var values = filters.Select(f =>
                {
                    if (f.Value != null && f.Value.GetType() == typeof(string))
                        return f.Value.ToString().ToLower();
                    else
                        return f.Value;
                }).ToArray();

                // Create a predicate expression e.g. Field1 = @0 And Field2 > @1
                string predicate = filter.ToExpression(filters);

                // Use the Where method of Dynamic Linq to filter the data
                queryable = queryable.Where(predicate, values);
            }

            return queryable;
        }

        private static IQueryable<T> Sort<T>(IQueryable<T> queryable, IEnumerable<Sort> sort)
        {
            if (sort != null && sort.Any())
            {
                // Create ordering expression e.g. Field1 asc, Field2 desc
                var ordering = String.Join(",", sort.Select(s => s.ToExpression()));

                // Use the OrderBy method of Dynamic Linq to sort the data
                return queryable.OrderBy(ordering);
            }

            return queryable;
        }

        private static IQueryable<T> Page<T>(IQueryable<T> queryable, int take, int skip)
        {
            return queryable.Skip(skip).Take(take);
        }
    }
}
