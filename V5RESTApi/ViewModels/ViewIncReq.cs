using System;
using System.Collections.Generic;

namespace aditaas_v5.Models
{
    public partial class ViewIncReq
    {
        public int Id { get; set; }
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
        public int? CreatedById { get; set; }
        public int? ModifiedById { get; set; }
        public int? AssignedToId { get; set; }
        public int? ModuleId { get; set; }
        
        public int? UserId { get; set; }
        public string CreatedBy { get; set; }
        public string AssignedGroupName { get; set; }
        public int? slaPercentage { get; set; }
        public string slaColor { get; set; }
        public int? OrgId { get; set; }
    }
}
