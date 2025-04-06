using System;
using System.Collections.Generic;
using System.Text;

namespace sumplierapp.Model
{
    public class User
    {
        public long Id { get; set; }
        public long CompanyCode { get; set; }
        public long ResellerCode { get; set; }
        public long CustomerCode { get; set; }
        public long UserCode { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int LoginType { get; set; }
        public bool IsActive { get; set; }
        public long RoleCode { get; set; }
        public string Image { get; set; }
        public bool Deleted { get; set; }
    }
}