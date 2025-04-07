using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sumplierapp.Model;
using Xamarin.Forms;

namespace sumplierapp.Configs
{
    public class Config
    {
        private static Config _instance;
        private static readonly object _lock = new object();

        public static Config Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                            _instance = new Config();
                    }
                }
                return _instance;
            }
        }

        private Config() { }

        private Customer currentCustomer;
        private User currentUser;
        private Dictionary<long, CustomerMenu> menuMap = new Dictionary<long, CustomerMenu>();
        private Dictionary<long, CustomerCategory> categoryMap = new Dictionary<long, CustomerCategory>();
        private Dictionary<long, CustomerProduct> productMap = new Dictionary<long, CustomerProduct>();
        private Dictionary<long, CustomerAccount> accountMap = new Dictionary<long, CustomerAccount>(); 

        public void SetCurrentCustomer(Customer customer)
        {
            currentCustomer = customer;
        }

        public Customer GetCurrentCustomer()
        {
            return currentCustomer;
        }


        public void SetCurrentUser(User user)
        {
            currentUser = user;
        }

        public User GetCurrentUser()
        {
            return currentUser;
        }

        // CheckSetMenus
        public void CheckSetMenus(List<CustomerMenu> menuList)
        {
            menuMap.Clear();

            foreach (var menu in menuList)
            {
                menuMap[menu.Id] = menu;
            }
        }

        // CheckSetCategories
        public void CheckSetCategories(List<CustomerCategory> categoryList)
        {
            categoryMap.Clear();

            foreach (var category in categoryList)
            {
                categoryMap[category.Id] = category;
            }
        }

        // CheckSetProducts
        public void CheckSetProducts(List<CustomerProduct> productList)
        {
            productMap.Clear();

            foreach (var product in productList)
            {
                productMap[product.Id] = product;
            }
        }

        // CheckSetAccounts
        public void CheckSetAccounts(List<CustomerAccount> accountList)
        {
            accountMap.Clear();

            foreach (var account in accountList)
            {
                accountMap[account.Id] = account;
            }
        }

        // GetAccountById
        public CustomerAccount GetAccountById(long? accountId)
        {
            if (accountId.HasValue)
            {
                if (accountMap.TryGetValue(accountId.Value, out var account))
                {
                    return account;
                }
            }
            return null;
        }

        // GetAccountByCode
        public CustomerAccount GetAccountByCode(long code)
        {
            foreach (var account in accountMap.Values)
            {
                if (account.AccountCode == code)
                {
                    return account;
                }
            }
            return null;
        }

        // GetAllAccounts
        public List<CustomerAccount> GetAllAccounts()
        {
            return accountMap.Values.ToList();
        }

        // GetDefaultMenu
        public CustomerMenu GetDefaultMenu()
        {
            var menus = GetMenus();

            foreach (var menu in menus)
            {
                if (menu.IsActive)
                    return menu;
            }

            return menus[0];
        }


        // GetMenuCategory
        public List<CustomerCategory> GetMenuCategory(CustomerMenu menu)
        {
            var categories = new List<CustomerCategory>();

            var menuCode = menu.MenuCode;

            foreach (var category in categoryMap.Values)
            {
                if (category.MenuCode == menuCode)
                {
                    categories.Add(category);
                }
            }

            return categories;
        }

        // GetMenus
        public List<CustomerMenu> GetMenus()
        {
            var menus = new List<CustomerMenu>();

            foreach (var menu in menuMap.Values)
            {
                menus.Add(menu);
            }

            return menus;
        }



        // GetCategoryProducts
        public List<CustomerProduct> GetCategoryProducts(CustomerCategory category)
        {
            var products = new List<CustomerProduct>();

            var categoryCode = category.CategoryCode;

            foreach (var product in productMap.Values)
            {
                if (product.CategoryCode == categoryCode)
                {
                    products.Add(product);
                }
            }

            return products;
        }

    }
}
