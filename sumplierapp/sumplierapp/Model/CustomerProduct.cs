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
        public decimal Price { get; set; }
        public decimal Price2 { get; set; }
        public decimal Price3 { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxRate2 { get; set; }
        public decimal TaxRate3 { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
