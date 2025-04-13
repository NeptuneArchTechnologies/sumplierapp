using sumplierapp.Api;
using sumplierapp.Configs;
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
    public partial class MyOrderPage : ContentPage
    {
        ApiService apiService = new ApiService();
        public MyOrderPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetTicketAll();
        }

        async void GetTicketAll()
        {
            DateTime now = DateTime.Now;

            await apiService.GetTicketAll(
            companyCode: Config.Instance.GetCurrentCustomer().CompanyCode,
            resellerCode: Config.Instance.GetCurrentCustomer().ResellerCode,
            customerCode: Config.Instance.GetCurrentCustomer().CustomerCode,
            startDateTime: now.AddHours(-5),
            endDateTime: now,
            onSuccess: (tickets) =>
            {
                myOrderFlowListView.FlowItemsSource = tickets;
            },
            onFail: (errorMessage) =>
            {
                Console.WriteLine($"Hata oluştu: {errorMessage}");
            });
        }


        private void btnNewOrder_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new CustomerAccountPage());
        }

        private void btnBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync(true);
        }
    }
}