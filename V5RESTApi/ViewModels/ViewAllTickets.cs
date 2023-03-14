using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aditaas_v5.Models
{
    public class ViewAllTickets
    {
        public int RecordId { get; set; }
        public int ModuleId { get; set; }
        public string IdNumber { get; set; }
        public int? OrgId { get; set; }
        public int? UserId { get; set; }
        public int? StatusId { get; set; }
        public int? PriorityId { get; set; }
        public int? AssignToId { get; set; }
        public int? CurrAssignQueueId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedById { get; set; }

        public string ShortDesc { get; set; }
        public string AdditionalComments { get; set; }
        public int LocationId { get; set; }

    }

    public partial class ViewAllOpenTickets
    {
        public string ModuleName { get; set; }
        public int? OrgId { get; set; }
        public string IdNumber { get; set; }
        public string Location { get; set; }
        public string ContactName { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Item { get; set; }
        public string Priority { get; set; }
        public string Queue { get; set; }
        public string AssignedTo { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? OpenedDate { get; set; }
        public DateTime? LastModifyDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool? IsActive { get; set; }
        public string Status { get; set; }
        public string OrgName { get; set; }
        public string Firstassignqueuename { get; set; }
        public string Prevassignqueuename { get; set; }
        public int Recordid { get; set; }
        public string ShortDesc { get; set; }
    }
}
