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
        public CustomerLoginPage()
        {
            InitializeComponent();
        }

        private void btnCustomerLogin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new UserLoginPage(email.Text));//Diğer sayfaya geçiş için
            Preferences.Set("customerName",email.Text);//Setlemek için
            string emre = Preferences.Get("customerName", string.Empty);//Çağırmak için
        }
    }
}