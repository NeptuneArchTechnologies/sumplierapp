using Newtonsoft.Json;
using sumplierapp.Configs;
using sumplierapp.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace sumplierapp.Api
{
    public class WeatherApiService
    {
        public async Task GetWeather(string latitude, string longitude,Action<Weather> onSuccess, Action<string> onFail)
        {
            var client = new HttpClient();
            string apiKey = "b6c62ebce4034ea4a3d191911240308";
            string lang = "tr";

            var requestUrl = $"http://api.weatherapi.com/v1/current.json?key={Uri.EscapeDataString(apiKey)}&q={latitude},{longitude}&lang={lang}";

            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);

            try
            {
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();

                Weather weatherData = JsonConvert.DeserializeObject<Weather>(responseBody);
                onSuccess?.Invoke(weatherData);
            }
            catch (Exception ex)
            {
                onFail?.Invoke(ex.Message);
            }
        }
    }
}
