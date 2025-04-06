using sumplierapp.Interface;
using sumplierapp.Model;
using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

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

        public async void PutIsMenuActive(long CompanyCode, long ResellerCode, long CustomerCode, long MenuCode, bool IsActive)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Put, "https://api.sumplier.com/SumplierAPI/CustomerMenu/PutMenuIsActive?CompanyCode="+ CompanyCode + "&ResellerCode="+ ResellerCode + "&CustomerCode="+ CustomerCode + "&MenuCode="+ MenuCode + "IsActive="+ IsActive + "");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }

        public async void PostTicket(string ticketJson)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.sumplier.com/SumplierAPI/Ticket/PostTicket");
            var content = new StringContent(ticketJson, null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }

        public async Task<string> PostGeoLocation(string geoLocationJson)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.sumplier.com/SumplierAPI/UsersGeoLocation/PostGeoLocation");
            var content = new StringContent(geoLocationJson, null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            return "Durum:" + response.Content.ReadAsStringAsync();
        }
    }
}
