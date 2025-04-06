using System;
using System.Collections.Generic;
using System.Text;

namespace sumplierapp.Model
{
    public class Customer
    {
        public long Id { get; set; }
        public long CompanyCode { get; set; }
        public long ResellerCode { get; set; }
        public long CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public int CustomerType { get; set; }
        public string Email { get; set; } 
        public string Password { get; set; } 
        public string Phone { get; set; } 
        public string Address { get; set; }  
        public string TaxOffice { get; set; }
        public string TaxNumber { get; set; }
        public bool IsActive { get; set; }
    }

}
