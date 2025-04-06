using System;
using System.Collections.Generic;
using System.Text;

namespace sumplierapp.Model
{
    public class CustomerMenu
    {
        public long Id { get; set; }
        public long CompanyCode { get; set; }
        public long ResellerCode { get; set; }
        public long CustomerCode { get; set; }
        public long MenuCode { get; set; }
        public string MenuName { get; set; }
        public bool IsActive { get; set; }
    }
}
