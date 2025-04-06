using System;
using System.Collections.Generic;
using System.Text;

namespace sumplierapp.Model
{
    public class CustomerCategory
    {
        public long Id { get; set; }
        public long CompanyCode { get; set; }
        public long ResellerCode { get; set; }
        public long CustomerCode { get; set; }
        public long MenuCode { get; set; }
        public long CategoryCode { get; set; }
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
    }
}
