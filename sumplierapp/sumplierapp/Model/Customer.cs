using System;
using System.Collections.Generic;
using System.Text;

namespace sumplierapp.Model
{
    public class Customer
    {
        public long id { get; set; }
        public long companyCode { get; set; }
        public long resellerCode { get; set; }
        public long customerCode { get; set; }
        public string customerName { get; set; }
        public int customerType { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string taxOffice { get; set; }
        public string taxNumber { get; set; }
        public bool isActive { get; set; }
    }
}
