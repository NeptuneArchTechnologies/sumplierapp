using System;
using System.Collections.Generic;
using System.Text;

namespace sumplierapp.Model
{
    public class CustomerDevice
    {
        public long id { get; set; }
        public long companyCode { get; set; }
        public long customerCode { get; set; }
        public long resellerCode { get; set; }
        public string licenceCode { get; set; }
        public string deviceCode { get; set; }
        public string printerName { get; set; }
        public string lat { get; set; }
        public string lang { get; set; }
    }

}
