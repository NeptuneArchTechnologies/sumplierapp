using sumplierapp.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace sumplierapp.Api
{
    public class ApiService
    {
        public async Task<string> GetCustomerLogin(string customerEmail, string customerPassword)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.sumplier.com/SumplierAPI/Customer/GetCustomerLogin?Email="+ customerEmail + "&Password="+ customerPassword + "");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
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
