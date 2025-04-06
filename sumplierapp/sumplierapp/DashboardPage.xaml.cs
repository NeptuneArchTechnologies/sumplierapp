using Newtonsoft.Json;
using sumplierapp.Api;
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
	public partial class DashboardPage : ContentPage
	{
        ApiService apiService = new ApiService();
        public DashboardPage (string userName)
		{
			InitializeComponent ();
            GetCurrentLocation();
        }
        public async Task<string> GetCurrentLocation()// Cihaz konum bilgisi almak için
        {
            try
            {
                UsersGeoLocation usersGeoLocation = new UsersGeoLocation();
                var location = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Medium));

                Console.WriteLine("Location:"+location);

                if (location != null)
                {
                    usersGeoLocation.id = 0;
                    usersGeoLocation.companyCode = Convert.ToInt64(1);
                    usersGeoLocation.resellerCode = Convert.ToInt64(100);
                    usersGeoLocation.customerCode = Convert.ToInt64(100);
                    usersGeoLocation.deviceCode = "deviceCode";
                    usersGeoLocation.userCode = Convert.ToInt64(100);
                    usersGeoLocation.lat = location.Latitude.ToString().Replace(',', '.');
                    usersGeoLocation.lang = location.Longitude.ToString().Replace(',', '.');
                    usersGeoLocation.datetime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-ddThh:mm.ss.fff"));

                    Console.WriteLine("Model:" + usersGeoLocation);

                    string userGeoLocation = JsonConvert.SerializeObject(usersGeoLocation);

                    await apiService.PostGeoLocation(userGeoLocation);
                }

                return "Başarılı";
            }
            catch (FeatureNotSupportedException)
            {
                return "Cihaz konum hizmetlerini desteklemiyor";
            }
            catch (PermissionException)
            {
                return "Cihaz konum izni verilmemiş";
            }
            catch (Exception ex)
            {
                return "Hata";
            }
        }
    }
}