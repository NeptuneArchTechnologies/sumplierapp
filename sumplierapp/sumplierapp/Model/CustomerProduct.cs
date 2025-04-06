using System;
using System.Collections.Generic;
using System.Text;

namespace sumplierapp.Model
{
    public class CustomerProduct
    {
        public long Id { get; set; }
        public long CompanyCode { get; set; }
        public long ResellerCode { get; set; }
        public long CustomerCode { get; set; }
        public long CategoryCode { get; set; }
        public long ProductCode { get; set; }
        public string Barcode { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public double Price2 { get; set; }
        public double Price3 { get; set; }
        public double TaxRate { get; set; }
        public double TaxRate2 { get; set; }
        public double TaxRate3 { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
