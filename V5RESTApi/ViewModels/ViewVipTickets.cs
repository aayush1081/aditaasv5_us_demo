using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aditaas_v5.ViewModels
{
    public class ViewVipTickets
    {
        public int? VipId { get; set; }
        public string VipIdNumber { get; set; }
        public string VipShortDesc { get; set; }
        public DateTime? VipOpenedDate { get; set; }
        public string VipCategory { get; set; }
        public string VipSubCategory { get; set; }
        public string VipItem { get; set; }
        public string VipPriority { get; set; }
        public string VipStatus { get; set; }
        public string VipAssignedTo { get; set; }
        public string VipContactName { get; set; }
        public string VipLocation { get; set; }
        public string VipAltLocation { get; set; }
        public DateTime? VipLastModifyDate { get; set; }
        public DateTime? VipTargetResolveTime { get; set; }
        public string VipCreatedBy { get; set; }
        public DateTime? VipCreatedOn { get; set; }
        public DateTime? VipModifiedOn { get; set; }
        public string VipModifiedBy { get; set; }
        public int? VipCreatedById { get; set; }
        public int? VipModifiedById { get; set; }
        public int? VipAssignedToId { get; set; }
        public int? VipUserId { get; set; }
        public string VipQueue { get; set; }
        public int? VipCurrentQueueId { get; set; }
        public int? VipOrgId { get; set; }
        public string VipOrgName { get; set; }
        public bool? Is_VIP { get; set; }
        public bool? isDraft { get; set; }
        public bool? HasChild { get; set; }
        public string addlComments { get; set; }
        public int? ModuleId { get; set; }
        public bool? isParent { get; set; }
    }
}
