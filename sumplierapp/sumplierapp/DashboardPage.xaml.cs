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
using System.Xml;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace sumplierapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPage : ContentPage
    {
        WeatherApiService weatherApiService = new WeatherApiService();
        private readonly LocationThread locationThread;
        public DashboardPage()
        {
            InitializeComponent();
            locationThread = new LocationThread();
            CurrentUserName.Text = Config.Instance.GetCurrentUser().Name + " " + Config.Instance.GetCurrentUser().Surname;

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await locationThread.CheckAndStartLocationService();
            getWeather();
            getCurrency();
        }

        private void btnMyTask_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MyTaskPage());
        }

        private void btnMyOrder_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MyOrderPage());
            Config.Instance.SetCurrentTicketState((int)Enum.TicketStateEnum.New);
        }

        async void getWeather()
        {
            try
            {
                var location = Config.Instance.GetCurrentLocation();
                await weatherApiService.GetWeather(location.lat, location.lang,
                onSuccess: weather =>
                {
                    CountryName.Text = weather.location.country;
                    CityName.Text = weather.location.region;
                    RegionName.Text = weather.location.name;
                    Temp.Text = weather.current.temp_c.ToString() + " C°".Replace(',', '.');
                    WeatherIcon.Source = "https:" + weather.current.condition.icon;
                    WeatherName.Text = weather.current.condition.text;

                    Console.WriteLine("Hava Durumu : Çalıştırldı.");
                },
                onFail: error =>
                {
                    Console.WriteLine("Hata oluştu: " + error);
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hava Durumu Hatası: " + ex);
            }
        }

        void getCurrency()
        {
            try
            {
                XmlDocument xmlVerisi = new XmlDocument();
                xmlVerisi.Load("http://www.tcmb.gov.tr/kurlar/today.xml");

                decimal dolar = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "USD")).InnerText.Replace('.', ','));
                decimal euro = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "EUR")).InnerText.Replace('.', ','));
                decimal sterlin = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "GBP")).InnerText.Replace('.', ','));

                DolarCurrency.Text = dolar.ToString("0.00");
                EuroCurrency.Text = euro.ToString("0.00");
                PoundCurrency.Text = sterlin.ToString("0.00");
            }
            catch (Exception)
            {

            }
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}
