using Newtonsoft.Json;
using sumplierapp.Api;
using sumplierapp.Configs;
using sumplierapp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sumplierapp.Api;
using sumplierapp.Interface;
using sumplierapp.Model;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using sumplierapp.LocalDatabase;
using sumplierapp.Enum;

namespace sumplierapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerLoginPage : ContentPage
    {
        public CustomerLoginPage()
        {
            InitializeComponent();
            DeviceCode.Text = Plugin.DeviceInfo.CrossDeviceInfo.Current.Id;
            // Check if we got Customer data on out locale...

            Customer customer = DataStorage.Instance.GetModel<Customer>(DbKey.Customer.Name());

            if (customer != null)
            {
                Config.Instance.SetCurrentCustomer(customer);
                Navigation.PushModalAsync(new UserLoginPage());
                return;
            }
        }

        public void btnCustomerLogin_Clicked(object sender, EventArgs e)
        {
            // Get the mail and password
            string email = emailEntry.Text;
            string password = passwordEntry.Text;

            var apiService = new ApiService();

            // Inline ApiCallBacks
            apiService.GetCustomerLogin(email, password,
                customer => {

                    if (customer != null) {

                        Console.WriteLine($"Giriş başarılı {customer}");
                        DataStorage.Instance.SaveModel(DbKey.Customer.Name(), customer);
                        Config.Instance.SetCurrentCustomer(customer);
                        Navigation.PushModalAsync(new UserLoginPage());
                    }

                },
                errorMessage => {
                    Console.WriteLine($"Giriş başarısız: {errorMessage}");
                });
        }       
    }
}