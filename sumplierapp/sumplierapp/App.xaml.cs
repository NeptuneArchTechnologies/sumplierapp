using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace sumplierapp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new CustomerLoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
