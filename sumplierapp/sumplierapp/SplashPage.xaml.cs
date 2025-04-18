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
using sumplierapp.LocalDatabase;
using sumplierapp.Enum;
using Newtonsoft.Json;

namespace sumplierapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashPage : ContentPage
    {
        private bool _UserIsActive;
        private Customer currentCustomer = Config.Instance.GetCurrentCustomer();
        private User currentUser = Config.Instance.GetCurrentUser();

        private List<CustomerMenu> menusList = null;
        private List<CustomerCategory> categoryList = null;
        private List<CustomerProduct> productList = null;
        private List<CustomerAccount> accountList = null;

        private CustomerDevice mDevice = DataStorage.Instance.GetModel<CustomerDevice>(DbKey.Device.Name());
        internal enum SplashState { Start, Device, Menus, Categories, Products, Accounts, Done }

        private SplashState currentState;
        public SplashPage(bool UserIsActive)
        {
            InitializeComponent();
            _UserIsActive = UserIsActive;
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
                    progressBar.IsVisible = true;
                    Task.Delay(10000);
                    PercentLabel.Text = "%25";
                    StatusText.Text = "Menü Yükleniyor...";
                    currentState = SplashState.Menus;
                    Task.Delay(5000);
                    fetchMenus();
                    break;

                case SplashState.Device:
                    // Menüleri aldıktan sonra Device'ye geçiyoruz
                    Console.WriteLine("Device State: Fetch devices...");
                    progressBar.IsVisible = true;
                    Task.Delay(10000);
                    PercentLabel.Text = "%40";
                    StatusText.Text = "Cihaz kontrol ediliyor...";
                    currentState = SplashState.Device;
                    Task.Delay(5000);
                    CheckSendDevice();
                    break;

                case SplashState.Categories:
                    // Kategoriler geldikten sonra Products'a geçiyoruz
                    Console.WriteLine("Categories state: Fetching categories...");
                    PercentLabel.Text = "%50";
                    StatusText.Text = "Kategoriler Yükleniyor...";
                    currentState = SplashState.Categories;
                    Task.Delay(5000);
                    fetchCategories();
                    break;

                case SplashState.Products:
                    // Ürünler geldikten sonra Accounts'a geçiyoruz
                    Console.WriteLine("Products state: Fetching products...");
                    PercentLabel.Text = "%70";
                    StatusText.Text = "Ürünler Yükleniyor...";
                    currentState = SplashState.Products;
                    Task.Delay(5000);
                    fetchProducts();
                    break;

                case SplashState.Accounts:
                    // Hesaplar geldikten sonra Done state'ine geçiyoruz
                    Console.WriteLine("Accounts state: Fetching accounts...");
                    PercentLabel.Text = "%85";
                    StatusText.Text = "Hesaplar Yükleniyor...";
                    currentState = SplashState.Accounts;
                    Task.Delay(5000);
                    fetchAccounts();
                    break;

                case SplashState.Done:
                    // Tüm adımlar tamamlandığında
                    Console.WriteLine("Done state: All steps completed.");
                    PercentLabel.Text = "%100";
                    StatusText.Text = "Yükleme Tamamlandı...";
                    progressBar.IsVisible = false;
                    currentState = SplashState.Done;
                    Task.Delay(5000);
                    OnConfigDone();
                    break;

            }
        }
        private SplashState GetNextState()
        {

            switch (currentState)
            {
                case SplashState.Start:
                    return SplashState.Device;

                case SplashState.Device:
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

                        Console.WriteLine($"fetch Menus successfully {menuList}");
                        this.menusList = menuList;
                        ContinueNextStep();

                    }

                },
                errorMessage =>
                {
                    Console.WriteLine($"fetch Menus fail: {errorMessage}");
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

                        Console.WriteLine($"fetch Categories successfully {categories}");
                        this.categoryList = categories;
                        ContinueNextStep( );
                    }

                },
                errorMessage =>
                {
                    Console.WriteLine($"fetch Categories fail: {errorMessage}");
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

                        Console.WriteLine($"fetch Products successfully: {products}");
                        this.productList = products;
                        ContinueNextStep();
                    }

                },
                errorMessage =>
                {
                    Console.WriteLine($"fetch Products fail: {errorMessage}");
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

                        Console.WriteLine($"fetch Accounts successfully: {accounts}");
                        this.accountList = accounts;
                        ContinueNextStep();
                    }

                },
                errorMessage =>
                {
                    Console.WriteLine($"fetch Accounts fail: {errorMessage}");
                });
        }

        private void CheckSendDevice()
        {

            if (mDevice == null) {

                mDevice = CreateNewDevice();
            
            }

            if (mDevice != null) {

                var apiService = new ApiService();

                string json = JsonConvert.SerializeObject(mDevice);

                // Inline ApiCallBacks
                apiService.PostCustomerDevice(json,
                   onSuccess: (device) =>
                   {
                       Console.WriteLine($"Check Send Device successfully: {device}");
                       DataStorage.Instance.SaveModel(DbKey.Device.Name(), mDevice);
                       Config.Instance.SetCurrentDevice(mDevice);
                       ContinueNextStep();

                   },
                   onFailure: (errorMessage) =>
                   {
                       Console.WriteLine("Check Send Device fail: " + errorMessage);
                       ContinueNextStep();
                   }
                );
            }

        }

        private CustomerDevice CreateNewDevice()
        {
            CustomerDevice device = new CustomerDevice
            {
                id = 0,
                companyCode = currentCustomer.CompanyCode,
                customerCode = currentCustomer.CustomerCode,
                resellerCode = currentCustomer.ResellerCode,
                licenceCode = "",
                printerName = "",
                deviceCode = Plugin.DeviceInfo.CrossDeviceInfo.Current.Id,
                lat = "",
                lang = ""
            }; 

            return device;
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