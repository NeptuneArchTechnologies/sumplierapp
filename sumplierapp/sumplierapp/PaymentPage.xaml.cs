using sumplierapp.Api;
using sumplierapp.Enum;
using sumplierapp.LocalDatabase;
using sumplierapp.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace sumplierapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentPage : ContentPage
    {
        ApiService apiService = new ApiService();
        public PaymentPage()
        {
            InitializeComponent();
            btnClose.IsVisible = false;
            this.BackgroundColor= Xamarin.Forms.Color.DarkOrange;
            status.Text = "Sipariş Gönderiyor...";
            status.TextColor = Xamarin.Forms.Color.White;
            sendStatusIcon.Source = "waiting_icon";
            string json = Preferences.Get("CurrentTicket", string.Empty);
            PostTicket(json);
        }

        async void PostTicket(string json)
        {
            await Task.Delay(2000);

            await apiService.PostTicket(json,
            onSuccess: (responseContent) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    status.Text = "Sipariş Başarıyla Gönderildi";
                    status.TextColor = Xamarin.Forms.Color.White;
                    orderCode.Text = responseContent;
                    this.BackgroundColor = ColorConverters.FromHex("#27ae60");
                    sendStatusIcon.Source = "done_icon";

                    Task.Delay(15000);

                    Navigation.PopModalAsync(true);

                    MessagingCenter.Send(this,MessagingCenterEnum.PaymentSuccess.ToString());
                });
            },
            onFailure: (error) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    status.Text = "Sipariş Gönderimi Başarısız";
                    status.TextColor = Xamarin.Forms.Color.Red;
                    this.BackgroundColor = ColorConverters.FromHex("#FFFFFF");
                    sendStatusIcon.Source = "fail_icon";
                    btnClose.IsVisible = true;
                });
            });
        }
        private void btnClose_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync(false);
        }
    }
}