using System;
using System.Collections.Generic;
using System.Text;

namespace sumplierapp.Model
{
    public class UsersGeoLocation
    {
        public long id { get; set; }
        public long companyCode { get; set; }
        public long resellerCode { get; set; }
        public long customerCode { get; set; }
        public string deviceCode { get; set; }
        public long userCode { get; set; }
        public string lat { get; set; }
        public string lang { get; set; }
        public DateTime datetime { get; set; }
    }
}
