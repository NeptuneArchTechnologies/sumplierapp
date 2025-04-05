using sumplierapp.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace sumplierapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserLoginPage : ContentPage
    {
        string customerName;
        public UserLoginPage(string CustomerName)//Bir önceki sayfadan gelen veri buraya geliyor
        {
            InitializeComponent();
            customerName = CustomerName;//UserLoginde ilgili alana setlenebilir

            LoginTypeEnum.App.ToString(); // Yaparsan string olan adı gelir
            int type = (int)LoginTypeEnum.App; // Yaparsan int değeri gelir
        }

        private void btnUserLogin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new SplashPage());
        }
    }
}