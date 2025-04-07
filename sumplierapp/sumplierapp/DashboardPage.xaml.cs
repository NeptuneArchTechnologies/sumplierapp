using Newtonsoft.Json;
using sumplierapp.Api;
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
        public DashboardPage()
        {
            InitializeComponent();
            locationThread = new LocationThread();
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
    }
}
