using System;
using System.Collections.Generic;

namespace aditaas_v5.Models
{
    public partial class ViewCmdbCiList
    {
        public int CiId { get; set; }
        public string Name { get; set; }
        public int? Type { get; set; }
        public string IpAddress { get; set; }
        public int? VendorId { get; set; }
        public int? OrgId { get; set; }
        public string SerialNumber { get; set; }
        
    }
}
