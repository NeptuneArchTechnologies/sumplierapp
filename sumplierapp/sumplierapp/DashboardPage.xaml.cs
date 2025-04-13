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
        public DashboardPage()//bool UserIsActive
        {
            InitializeComponent();
            //locationThread = new LocationThread();
            //currentUserName.Text = Config.Instance.GetCurrentUser().Name + " " + Config.Instance.GetCurrentUser().Surname;
            //statusChangeSwitch.IsToggled = UserIsActive;
        }
        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();
        //    await locationThread.CheckAndStartLocationService();
        //}
        //SİPARİŞLERİM , RAPORLAR VE AYARLAR OLACAK
        //PROFİL SAĞ ÜSTTE OLACAK OKUNULDUĞUNDA PROFİL POPUP AÇILACAK PROFİL BİLGİLERİNE GİREBİLİCEK YADA KENDİNİ İSACTİVE SİNİ FALSE YAPABİLECEK

        private void btnMyTask_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MyTaskPage());
        }

        private void btnMyOrder_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MyOrderPage());
            Config.Instance.SetCurrentTicketState((int)Enum.TicketStateEnum.New);
        }

        //async void getWeather(string Latitude, string Longitude)
        //{
        //    try
        //    {
        //        City.Text = await weatherController.getWeatherCity(Latitude, Longitude);
        //        Region.Text = await weatherController.getWeatherRegion(Latitude, Longitude);
        //        Temp.Text = await weatherController.getWeatherTemp(Latitude, Longitude);
        //        Temp2.Text = await weatherController.getWeatherTempFeel(Latitude, Longitude);
        //        WeatherIcon.Source = await weatherController.getWeatherImage(Latitude, Longitude);
        //        WeatherText.Text = await weatherController.getWeatherCondition(Latitude, Longitude);
        //    }
        //    catch (Exception)
        //    {


        //    }
        //}
    }
}
