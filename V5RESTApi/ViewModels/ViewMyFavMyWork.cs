using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aditaas_v5.Models
{
    public class ViewMyFavMyWork
    {
        public int? WorkId { get; set; }
        public string WorkIdNumber { get; set; }
        public string WorkShortDesc { get; set; }
        public DateTime? WorkOpenedDate { get; set; }
        public string WorkCategory { get; set; }
        public string WorkSubCategory { get; set; }
        public string WorkItem { get; set; }
        public string WorkPriority { get; set; }
        public string WorkStatus { get; set; }
        public string WorkAssignedTo { get; set; }
        public string WorkContactName { get; set; }
        public string WorkLocation { get; set; }
        public string WorkAltLocation { get; set; }
        public DateTime? WorkLastModifyDate { get; set; }
        public DateTime? WorkTargetResolveTime { get; set; }
        public string WorkCreatedBy { get; set; }
        public string WorkModifiedBy { get; set; }
        public int? WorkCreatedById { get; set; }
        public int? WorkModifiedById { get; set; }
        public int? WorkAssignedToId { get; set; }
        public int? WorkUserId { get; set; }
        public string WorkQueue { get; set; }
        public int? WorkCurrentQueueId { get; set; }
        public int? WorkOrgId { get; set; }
        public string WorkOrgName { get; set; }
        public bool? isVip { get; set; }

        //public string contactUserName { get; set; }
        //public string contactMobile { get; set; }
        //public string contactFirstName { get; set; }
        //public string contactLastName { get; set; }
        //public string contactTitle { get; set; }
        //public string contactEmail { get; set; }
        //public bool? contactIsActive { get; set; }
        //public string contactSiteName { get; set; }
        public string WorkSeverity { get; set; }
        public string WorkChannel { get; set; }
        public string WorkImpactedCi { get; set; }
        public bool? HasChild { get; set; }
        public string addlComments { get; set; }
        public bool? isDraft { get; set; }

        public int? ModuleId { get; set; }
        public int? slaPercentage { get; set; }
        public string slaColor { get; set; }
        public int? ParentIncidentId { get; set; }
        public bool? IsParent { get; set; }

    }
}
