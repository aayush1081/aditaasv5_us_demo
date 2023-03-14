using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aditaas_v5.Models
{
    public class ViewMyFavOpenUnAssigned
    {
        public int? Id { get; set; }
        public string IdNumber { get; set; }
        public string ShortDesc { get; set; }
        public DateTime? OpenedDate { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Item { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public string AssignedTo { get; set; }
        public string ContactName { get; set; }
        public string Location { get; set; }
        public string AltLocation { get; set; }
        public DateTime? LastModifyDate { get; set; }
        public DateTime? TargetResolveTime { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int? CreatedById { get; set; }
        public int? ModifiedById { get; set; }
        public int? AssignedToId { get; set; }
        public int? CurrentQueueId { get; set; }
        public int? UserId { get; set; }
        public string Queue { get; set; }
        public int? OrgId { get; set; }
        public string OrgName { get; set; }
        public string Severity { get; set; }
        public string Channel { get; set; }
        public string ImpactedCi { get; set; }
        public bool? isVip { get; set; }
       
        public bool? HasChild { get; set; }
        public string addlComments { get; set; }

        public int? ModuleId { get; set; }
        public int? slaPercentage { get; set; }
        public string slaColor { get; set; }
        public int? ParentIncidentId { get; set; }
        public bool? IsParent { get; set; }
    }
}
