using System;
using System.Collections.Generic;

#nullable disable

namespace aditaas_v5.Models
{
    public partial class ViewMyfavMyapprovals
    {
        public int ApprApprovalId { get; set; }
        public string ApprIdNumber { get; set; }
        public string ApprModule { get; set; }
        public string ApprRecord { get; set; }
        public string ApprStatus { get; set; }
        public string ApprDescription { get; set; }
        public string ApprComment { get; set; }
        public string ApprQueue { get; set; }
        public string Approver { get; set; }
        public string ApprCreatedBy { get; set; }
        public string ApprModifiedBy { get; set; }
        public DateTime? ApprModifiedOn { get; set; }
        public DateTime? ApprCreatedOn { get; set; }
        public string ApprRequester { get; set; }
        public int? Sequence { get; set; }

        public string ApprOrgName { get; set; }

        public int? ApprModuleId { get; set; }
        public int? ApprApproverId { get; set; }
        public int? ApprStatusId { get; set; }
        public int? ApprQueueId { get; set; }
        public int? ApprCreatedbyId { get; set; }
        public int? ApprModifiedById { get; set; }
        public int? ApprRecordId { get; set; }
        public int? ApprRequesterId { get; set; }
        public int? ApprOrgId { get; set; }
        public bool? isVip { get; set; }
        public string contactUserName { get; set; }
        public string contactMobile { get; set; }
        public string contactFirstName { get; set; }
        public string contactLastName { get; set; }
        public string contactTitle { get; set; }
        public string contactEmail { get; set; }
        public bool? contactIsActive { get; set; }
        public string contactSiteName { get; set; }
        public int? rowNumberId { get; set; }
        public bool? isActive { get; set; }
        public string ApprCreatedByFullName { get; set; }
        public string ApprApproverFullName { get; set; }
        public string ApprRequesterFullName { get; set; }
        public string ApprAuthorizedByFullName { get; set; }
    }
}
