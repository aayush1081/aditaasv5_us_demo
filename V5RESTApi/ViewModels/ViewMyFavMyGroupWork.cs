using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aditaas_v5.Models
{
    public class ViewMyFavMyGroupWork
    {
        public int? GworkId { get; set; }
        public string GworkIdNumber { get; set; }
        public string GworkShortDesc { get; set; }
        public DateTime? GworkOpenedDate { get; set; }
        public string GworkCategory { get; set; }
        public string GworkSubCategory { get; set; }
        public string GworkItem { get; set; }
        public string GworkPriority { get; set; }
        public string GworkStatus { get; set; }
        public string GworkAssignedTo { get; set; }
        public string GworkContactName { get; set; }
        public string GworkLocation { get; set; }
        public string GworkAltLocation { get; set; }
        public DateTime? GworkLastModifyDate { get; set; }
        public DateTime? GworkTargetResolveTime { get; set; }
        public string GworkCreatedBy { get; set; }
        public string GworkModifiedBy { get; set; }
        public int? GworkCreatedById { get; set; }
        public int? GworkModifiedById { get; set; }
        public int? GworkAssignedToId { get; set; }
        public int? GworkUserId { get; set; }
        public int? GworkCurrentQueueId { get; set; }
        public string GworkQueue { get; set; }
        public int? GworkOrgId { get; set; }
        public string GworkOrgName { get; set; }
        public string GworkSeverity { get; set; }
        public string GworkChannel { get; set; }
        public string GworkImpactedCi { get; set; }
        public bool? isVip { get; set; }

        public int? ModuleId { get; set; }
        public bool? HasChild { get; set; }
        public string addlComments { get; set; }
        public int? slaPercentage { get; set; }
        public string slaColor { get; set; }
        public int? ParentIncidentId { get; set; }
        public bool? IsParent { get; set; }
    }
}
