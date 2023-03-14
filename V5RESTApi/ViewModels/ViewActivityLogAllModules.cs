using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aditaas_v5.ViewModels
{
    public class ViewActivityLogAllModules
    {
        public int ActivityLogId { get; set; }
        public DateTime LogTime { get; set; }
        public string ActionType { get; set; }
        public string LogTitle { get; set; }
        public string DescriptionHtml { get; set; }
        public string Module { get; set; }
        public string IdNumber { get; set; }
        public DateTime? Resolved { get; set; }
    }
}
