using Newtonsoft.Json;
using sumplierapp.Api;
using sumplierapp.Config;
using sumplierapp.Enum;
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
    public partial class UserLoginPage : ContentPage
    {
        AppConfig appConfig = new AppConfig();
        public string customerName,companyCode,resellerCode,customerCode,userCode;
        public UserLoginPage()//Bir önceki sayfadan gelen veri buraya geliyor
        {
            InitializeComponent();
            customerName = appConfig.GetCustomerName();//UserLoginde ilgili alana setlenebilir

            LoginTypeEnum.App.ToString(); // Yaparsan string olan adı gelir
            int type = (int)LoginTypeEnum.App; // Yaparsan int değeri gelir

            
        }

        private void btnUserLogin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new SplashPage());
        }

        
    }
}