using Newtonsoft.Json;
using sumplierapp.Api;
using sumplierapp.Configs;
using sumplierapp.Model;
using sumplierapp.Threads;
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
	public partial class DashboardPage : ContentPage
	{
        private readonly LocationThread locationThread;
        public DashboardPage(bool UserIsActive)
        {
            InitializeComponent();
            locationThread = new LocationThread();
            currentUserName.Text = Config.Instance.GetCurrentUser().Name + " " + Config.Instance.GetCurrentUser().Surname;
            statusChangeSwitch.IsToggled = UserIsActive;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await locationThread.CheckAndStartLocationService();
        }

        private void btnNewOrder_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new CustomerAccountPage());
        }

        private void btnOldOrder_Clicked(object sender, EventArgs e)
        {

        }

        private void btnMyTask_Clicked(object sender, EventArgs e)
        {

        }
    }
}
