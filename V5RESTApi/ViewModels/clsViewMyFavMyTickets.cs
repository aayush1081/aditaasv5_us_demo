using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aditaas_v5.Models
{
    public class clsViewMyFavMyTickets
    {
        public int TicketId { get; set; }
        public string TicketIdNumber { get; set; }
        public string TicketShortDesc { get; set; }
        public DateTime? TicketOpenedDate { get; set; }
        public string TicketCategory { get; set; }
        public string TicketSubCategory { get; set; }
        public string TicketItem { get; set; }
        public string TicketPriority { get; set; }
        public string TicketStatus { get; set; }
        public string TicketAssignedTo { get; set; }
        public string TicketContactName { get; set; }
        public string TicketLocation { get; set; }
        public string TicketAltLocation { get; set; }
        public DateTime? TicketLastModifyDate { get; set; }
        public DateTime? TicketTargetResolveTime { get; set; }
        public string TicketCreatedBy { get; set; }
        public string TicketModifiedBy { get; set; }
        public int?  TicketCreatedById { get; set; }
        public int? TicketModifiedById { get; set; }
        public int? TicketAssignedToId { get; set; }
        public int? TicketUserId { get; set; }
        public string TicketQueue { get; set; }
        public int? TicketOrgId { get; set; }
        public string TicketOrgName { get; set; }
        public int? TicketQueueId { get; set; }
        public bool? TicketIsVip { get; set; }
        //public string contactUserName { get; set; }
        //public string contactMobile { get; set; }
        //public string contactFirstName { get; set; }
        //public string contactLastName { get; set; }
        //public string contactTitle { get; set; }
        //public string contactEmail { get; set; }
        //public bool? contactIsActive { get; set; }
        //public string contactSiteName { get; set; }
        public string TicketSeverity { get; set; }
        public string TicketChannel { get; set; }
        public string TicketImpactedCi { get; set; }
        public bool? HasChild { get; set; }
        public string addlComments { get; set; }

        public int? moduleId { get; set; }
        public int? slaPercentage { get; set; }
        public string slaColor { get; set; }
        public bool? isParent { get; set; }
    }
}
