using System;
using System.Collections.Generic;
using System.Text;

namespace sumplierapp.Model
{
    public class CustomerAccount
    {
        public long Id { get; set; }
        public long CompanyCode { get; set; }
        public long ResellerCode { get; set; }
        public long CustomerCode { get; set; }
        public long AccountCode { get; set; }
        public string AccountName { get; set; }
        public string Address { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public bool IsActive { get; set; }
        public string PhoneNumber { get; set; }
        public string TaxNumber { get; set; }
        public string TaxOffice { get; set; }
    }
}
