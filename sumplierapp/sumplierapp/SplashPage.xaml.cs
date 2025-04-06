﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sumplierapp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using sumplierapp.Configs;
using sumplierapp.Api;
using Xamarin.Essentials;

namespace sumplierapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashPage : ContentPage
    {

        private Customer currentCustomer = Config.Instance.GetCurrentCustomer();
        private User currentUser = Config.Instance.GetCurrentUser();

        private List<CustomerMenu> menusList = null;
        private List<CustomerCategory> categoryList = null;
        private List<CustomerProduct> productList = null;
        private List<CustomerAccount> accountList = null;
        internal enum SplashState { Start, Menus, Categories, Products, Accounts, Done }

        private SplashState currentState;
        public SplashPage()
        {
            InitializeComponent();

            if (currentUser == null || currentCustomer == null)
            {

                // Must handle error cases
            }

            currentState = SplashState.Start;
            ContinueNextStep();

        }

        public void ContinueNextStep()
        {

            SplashState nextState = GetNextState();


            switch (nextState)
            {
                case SplashState.Menus:
                    // Menüleri aldıktan sonra Categories'e geçiyoruz
                    Console.WriteLine("Menus state: Fetching menus...");
                    currentState = SplashState.Menus;
                    fetchMenus();
                    break;

                case SplashState.Categories:
                    // Kategoriler geldikten sonra Products'a geçiyoruz
                    Console.WriteLine("Categories state: Fetching categories...");
                    currentState = SplashState.Categories;
                    fetchCategories();
                    break;

                case SplashState.Products:
                    // Ürünler geldikten sonra Accounts'a geçiyoruz
                    Console.WriteLine("Products state: Fetching products...");
                    currentState = SplashState.Products;
                    fetchProducts();
                    break;

                case SplashState.Accounts:
                    // Hesaplar geldikten sonra Done state'ine geçiyoruz
                    Console.WriteLine("Accounts state: Fetching accounts...");
                    currentState = SplashState.Accounts;
                    fetchAccounts();
                    break;

                case SplashState.Done:
                    // Tüm adımlar tamamlandığında
                    Console.WriteLine("Done state: All steps completed.");
                    currentState = SplashState.Done;
                    OnConfigDone();
                    break;

            }
        }

        private SplashState GetNextState()
        {

            switch (currentState)
            {
                case SplashState.Start:
                    return SplashState.Menus;

                case SplashState.Menus:
                    return SplashState.Categories;

                case SplashState.Categories:
                    return SplashState.Products;

                case SplashState.Products:
                    return SplashState.Accounts;

                case SplashState.Accounts:
                    return SplashState.Done;

                default:
                    return SplashState.Start;
            }
        }

        private void fetchMenus()
        {

            var apiService = new ApiService();

            // Inline ApiCallBacks
            apiService.GetMenus(currentCustomer.CompanyCode, currentCustomer.ResellerCode, currentCustomer.CustomerCode,
                menuList =>
                {

                    if (menuList != null && menuList.Count != 0)
                    {

                        Console.WriteLine($"Menus gets successfully {menuList}");
                        this.menusList = menuList;
                        ContinueNextStep();

                    }

                },
                errorMessage =>
                {
                    Console.WriteLine($"Giriş başarısız: {errorMessage}");
                });
        }

        private void fetchCategories()
        {

            var apiService = new ApiService();

            // Inline ApiCallBacks
            apiService.GetCategories(currentCustomer.CompanyCode, currentCustomer.ResellerCode, currentCustomer.CustomerCode,
                categories =>
                {

                    if (categories != null && categories.Count != 0)
                    {

                        Console.WriteLine($"Menus gets successfully {categories}");
                        this.categoryList = categories;
                        ContinueNextStep( );
                    }

                },
                errorMessage =>
                {
                    Console.WriteLine($"Giriş başarısız: {errorMessage}");
                });
        }

        private void fetchProducts()
        {

            var apiService = new ApiService();

            // Inline ApiCallBacks
            apiService.GetProducts(currentCustomer.CompanyCode, currentCustomer.ResellerCode, currentCustomer.CustomerCode,
                products =>
                {

                    if (products != null && products.Count != 0)
                    {

                        Console.WriteLine($"Menus gets successfully {products}");
                        this.productList = products;
                        ContinueNextStep();
                    }

                },
                errorMessage =>
                {
                    Console.WriteLine($"Giriş başarısız: {errorMessage}");
                });
        }

        private void fetchAccounts()
        {

            var apiService = new ApiService();

            // Inline ApiCallBacks
            apiService.GetAccounts(currentCustomer.CompanyCode, currentCustomer.ResellerCode, currentCustomer.CustomerCode,
                accounts =>
                {

                    if (accounts != null && accounts.Count != 0)
                    {

                        Console.WriteLine($"Menus gets successfully {accounts}");
                        this.accountList = accounts;
                        ContinueNextStep();
                    }

                },
                errorMessage =>
                {
                    Console.WriteLine($"Giriş başarısız: {errorMessage}");
                });
        }

        private void OnConfigDone()
        {

            Config.Instance.CheckSetMenus(menusList);
            Config.Instance.CheckSetCategories(categoryList);
            Config.Instance.CheckSetProducts(productList);
            Config.Instance.CheckSetAccounts(accountList);

            Navigation.PushModalAsync(new DashboardPage());
        }

    }
}