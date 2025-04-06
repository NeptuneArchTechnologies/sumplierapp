using Newtonsoft.Json;
using sumplierapp.Api;
using sumplierapp.Config;
using sumplierapp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace sumplierapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomerLoginPage : ContentPage
    {
        AppConfig appConfig = new AppConfig();
        ApiService apiService = new ApiService();
        public CustomerLoginPage()
        {
            InitializeComponent();
        }

        public async void btnCustomerLogin_Clicked(object sender, EventArgs e)
        {
            var customerLogin = JsonConvert.DeserializeObject<Customer>(await apiService.GetCustomerLogin(email.Text, password.Text));
            if (!string.IsNullOrEmpty(customerLogin.ToString()))
            {
                appConfig.SetCompanyCode(customerLogin.companyCode.ToString());
                appConfig.SetCustomerCode(customerLogin.customerCode.ToString());
                appConfig.SetCustomerName(customerLogin.customerName.ToString());
                Navigation.PushModalAsync(new UserLoginPage());
            }
            else
            {
                DisplayAlert("Hata","Kullanıcı bilgileri hatalı  !!!","Tamam");
            }
            //string emre = Preferences.Get("customerName", string.Empty);//Çağırmak için
        }
    }
}