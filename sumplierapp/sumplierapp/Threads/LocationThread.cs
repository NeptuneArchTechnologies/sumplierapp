using Newtonsoft.Json;
using sumplierapp.Api;
using sumplierapp.Configs;
using sumplierapp.Model;
using System.Threading.Tasks;
using System;
using Xamarin.Essentials;
using System.Threading;
using System.Globalization;

namespace sumplierapp.Threads
{
    public class LocationThread
    {
        private readonly ApiService apiService;
        private Timer timer;
        private bool isRunning = false;
        private readonly TimeSpan interval = TimeSpan.FromSeconds(30);

        private readonly long companyCode;
        private readonly long resellerCode;
        private readonly long customerCode;
        private readonly string deviceCode;
        private readonly long userCode;

        public LocationThread()
        {
            apiService = new ApiService();

            var customer = Config.Instance.GetCurrentCustomer();
            var user = Config.Instance.GetCurrentUser();

            if (customer == null || user == null)
            {
                Console.WriteLine("Konum servisi başlatılamadı: Kullanıcı veya müşteri bilgisi eksik.");
                return;
            }

            companyCode = customer.CompanyCode;
            resellerCode = customer.ResellerCode;
            customerCode = customer.CustomerCode;
            deviceCode = Config.Instance.GetCurrentDevice().deviceCode;
            userCode = user.UserCode;
        }

        public async Task CheckAndStartLocationService()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            if (status != PermissionStatus.Granted)
            {
                //If not ask for permission...
                var requestStatus = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

                if (requestStatus == PermissionStatus.Granted)
                {
                    // Wait for permission to get granted...
                    Start();
                }
                else
                {
                    // User denied...
                    Console.WriteLine("Konum izni verilmedi.");
                }
            }
            else
            {
                // Start if we got permission...
                Start();
            }
        }

        // Start
        public void Start()
        {
            if (!isRunning)
            {
                isRunning = true;
                timer = new Timer(async _ => await ProcessLocationAsync(), null, TimeSpan.Zero, interval);
                Console.WriteLine("Konum servisi başlatıldı.");
            }
        }

        // Stop
        public void Stop()
        {
            if (isRunning)
            {
                timer?.Dispose();
                timer = null;
                isRunning = false;
                Console.WriteLine("Konum servisi durduruldu.");
            }
        }

        // ProcessLocationAsync
        private async Task ProcessLocationAsync()
        {
            try
            {
                var location = await GetCurrentLocation();
                if (location != null)
                {
                    await SendLocation(location);
                }
                else
                {
                    Console.WriteLine("Konum alınamadı.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Konum işlenirken hata oluştu: {ex.Message}");
            }
        }


        // GetCurrentLocation
        private async Task<Xamarin.Essentials.Location> GetCurrentLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);

                var usersGeoLocation = new UsersGeoLocation
                {
                    lat = location.Latitude.ToString(CultureInfo.InvariantCulture),
                    lang = location.Longitude.ToString(CultureInfo.InvariantCulture)
                };

                Config.Instance.SetCurrentLocation(usersGeoLocation);

                if (location == null)
                    Console.WriteLine("Konum bilgisi null döndü.");

                return location;
            }
            catch (FeatureNotSupportedException)
            {
                Console.WriteLine("Cihaz konum hizmetlerini desteklemiyor.");
            }
            catch (PermissionException)
            {
                Console.WriteLine("Konum izni verilmemiş.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Konum alma hatası: " + ex.Message);
            }

            return null;
        }

        // SendLocation
        private async Task SendLocation(Xamarin.Essentials.Location location)
        {
            try
            {
                if (location == null) return;

                var geo = new UsersGeoLocation
                {
                    id = 0,
                    companyCode = companyCode,
                    resellerCode = resellerCode,
                    customerCode = customerCode,
                    deviceCode = deviceCode,
                    userCode = userCode,
                    lat = location.Latitude.ToString().Replace(',', '.'),
                    lang = location.Longitude.ToString().Replace(',', '.'),
                    datetime = DateTime.UtcNow
                };

                string json = JsonConvert.SerializeObject(geo);

                await apiService.PostGeoLocation(json,
                onSuccess: () =>
                {
                    Console.WriteLine("Konum başarıyla gönderildi.");
                },
                onFailure: (errorMessage) =>
                {
                    Console.WriteLine("Hata: " + errorMessage);
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Konum gönderilirken hata oluştu: " + ex.Message);
            }
        }
    }
}
