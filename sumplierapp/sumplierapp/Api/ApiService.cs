using sumplierapp.Interface;
using sumplierapp.Model;
using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

namespace sumplierapp.Api
{
    public class ApiService
    {
        public async void GetCustomerLogin(string customerEmail, string customerPassword, Action<Customer> onSuccess, Action<string> onFail)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.sumplier.com/SumplierAPI/Customer/GetCustomerLogin?Email={customerEmail}&Password={customerPassword}");

            try
            {
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();

                var customer = JsonConvert.DeserializeObject<Customer>(responseBody);
                onSuccess?.Invoke(customer); // Başarı durumunda onSuccess delegate'ini çağır

                
            }
            catch (Exception ex)
            {
                onFail?.Invoke(ex.Message); // Hata durumunda onFail delegate'ini çağır
            }

        }

        public async void GetUserLogin(string userMail, string userPassword, Action<User> onSuccess, Action<string> onFail)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.sumplier.com/SumplierAPI/Users/GetUserLogin?Email={userMail}&Password={userPassword}");

            try
            {
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();

                var user = JsonConvert.DeserializeObject<User>(responseBody);
                onSuccess?.Invoke(user); // Başarı durumunda onSuccess delegate'ini çağır
            }
            catch (Exception ex)
            {
                onFail?.Invoke(ex.Message); // Hata durumunda onFail delegate'ini çağır
            }
        }

        public async void GetMenus(long companyCode, long resellerCode, long customerCode, Action<List<CustomerMenu>> onSuccess, Action<string> onFail)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.sumplier.com/SumplierAPI/CustomerMenu/GetMenu?CompanyCode={companyCode}&ResellerCode={resellerCode}&CustomerCode={customerCode}");

            try
            {
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();

                List<CustomerMenu> menus = JsonConvert.DeserializeObject<List<CustomerMenu>>(responseBody);
                onSuccess?.Invoke(menus); // Başarı durumunda onSuccess delegate'ini çağır
            }
            catch (Exception ex)
            {
                onFail?.Invoke(ex.Message); // Hata durumunda onFail delegate'ini çağır
            }
        }

        public async void GetCategories(long companyCode, long resellerCode, long customerCode, Action<List<CustomerCategory>> onSuccess, Action<string> onFail)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.sumplier.com/SumplierAPI/CustomerCategory/GetCategory?CompanyCode={companyCode}&ResellerCode={resellerCode}&CustomerCode={customerCode}");

            try
            {
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();

                List<CustomerCategory> categories = JsonConvert.DeserializeObject<List<CustomerCategory>>(responseBody);
                onSuccess?.Invoke(categories); // Başarı durumunda onSuccess delegate'ini çağır
            }
            catch (Exception ex)
            {
                onFail?.Invoke(ex.Message); // Hata durumunda onFail delegate'ini çağır
            }
        }  
        
        public async void GetProducts(long companyCode, long resellerCode, long customerCode, Action<List<CustomerProduct>> onSuccess, Action<string> onFail)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.sumplier.com/SumplierAPI/CustomerProduct/GetProductAll?CompanyCode={companyCode}&ResellerCode={resellerCode}&CustomerCode={customerCode}");

            try
            {
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();

                List<CustomerProduct> products = JsonConvert.DeserializeObject<List<CustomerProduct>>(responseBody);
                onSuccess?.Invoke(products); // Başarı durumunda onSuccess delegate'ini çağır
            }
            catch (Exception ex)
            {
                onFail?.Invoke(ex.Message); // Hata durumunda onFail delegate'ini çağır
            }
        }

        public async void GetAccounts(long companyCode, long resellerCode, long customerCode, Action<List<CustomerAccount>> onSuccess, Action<string> onFail)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.sumplier.com/SumplierAPI/CustomerAccount/GetCustomerAccountAll?CompanyCode={companyCode}&ResellerCode={resellerCode}&CustomerCode={customerCode}");

            try
            {
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();

                List<CustomerAccount> accounts = JsonConvert.DeserializeObject<List<CustomerAccount>>(responseBody);
                onSuccess?.Invoke(accounts); // Başarı durumunda onSuccess delegate'ini çağır
            }
            catch (Exception ex)
            {
                onFail?.Invoke(ex.Message); // Hata durumunda onFail delegate'ini çağır
            }
        }

        public async Task PostGeoLocation(string geoLocationJson, Action onSuccess, Action<string> onFailure)
        {
            var client = new HttpClient();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, "https://api.sumplier.com/SumplierAPI/UsersGeoLocation/PostGeoLocation");
                request.Content = new StringContent(geoLocationJson, Encoding.UTF8, "application/json");

                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode(); // 2xx status codes

                string responseContent = await response.Content.ReadAsStringAsync();

                // Başarılı işlemde OnSuccess callback çağrılır
                onSuccess?.Invoke();
                Console.WriteLine("Konum gönderildi, cevap: " + responseContent);
            }
            catch (Exception ex)
            {
                // Başarısız işlemde OnFailure callback çağrılır
                onFailure?.Invoke($"Konum gönderimi sırasında hata: {ex.Message}");
                Console.WriteLine("Konum gönderimi sırasında hata: " + ex.Message);
            }
        }

        public async void PostCustomerDevice(string deviceJson, Action<CustomerDevice> onSuccess, Action<string> onFailure)
        {
            var client = new HttpClient();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, "https://api.sumplier.com/SumplierAPI/CustomerDevice/PostCompanyDevice");
                request.Content = new StringContent(deviceJson, Encoding.UTF8, "application/json");

                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                string responseContent = await response.Content.ReadAsStringAsync();
                CustomerDevice device = JsonConvert.DeserializeObject<CustomerDevice>(responseContent);
                onSuccess?.Invoke(device);

            }
            catch (Exception ex)
            {
                // Başarısız işlemde OnFailure callback çağrılır
                onFailure?.Invoke($"Cihaz gönderilirken bir hata oluştu: {ex.Message}");
            }
        }

    }
}
