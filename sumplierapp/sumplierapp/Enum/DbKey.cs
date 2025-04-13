using System;
using System.Collections.Generic;
using System.Text;

namespace sumplierapp.Enum
{
    public enum DbKey
    {
        Customer,
        Accounts,
        User,
        Menu,
        Device,
        Category,
        Product,
        Settings,
        Ticket
    }

    public static class DbKeyExtensions
    {
        public static string Name(this DbKey key)
        {
            return key.ToString();
        }
    }

}
