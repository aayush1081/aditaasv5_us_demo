using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aditaas_v5.ViewModels
{
    public class ViewUniversalSearchData
    {
        public int? RecordId { get; set; }
        public int? ModuleId { get; set; }
        public int? OrgId { get; set; }
        public int? UserId { get; set; }
        public int? CurrAssignQueueId { get; set; }
        public string IdNumber { get; set; }
        public string ContactName { get; set; }
        public string AssignTo { get; set; }
        public string Queue { get; set; }
        public string ShortDesc { get; set; }
        public int? StatusId { get; set; }
        public int? CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public int? ItemId { get; set; }
        public int? ChannelId { get; set; }
        public int? PriorityId { get; set; }
        public int? LocationId { get; set; }
        public int? AltLocationId { get; set; }
        public int? ConfigCiId { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedById { get; set; }
        public DateTime? ModifiedOn { get; set; }


    }
}
