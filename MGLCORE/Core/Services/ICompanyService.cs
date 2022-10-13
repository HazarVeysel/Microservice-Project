using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ICompanyService
    {
        Task<string> GetCompany();
        Task<string> GetAddressCardList();
    }
    class CompanyService : ICompanyService
    {
        static string url = "http://localhost:7231/"; //Burası localde çalıştırılırken servisler docker'da ise şöyle olacak; http://localhost:7231/. Servisler docker'da değilse https ile başlayacak.
        static string serviceUrl = "";
        static HttpClient client = new HttpClient();
        public async Task<string> GetCompany()
        {
            string result = await client.GetStringAsync(serviceUrl);
            serviceUrl = $"{url}api/company";
            using (HttpResponseMessage response = await client.GetAsync(serviceUrl))
                return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> GetAddressCardList()
        {
            string result = await client.GetStringAsync(serviceUrl);
            serviceUrl = $"{url}api/AddressCard/getadresscardlist";
            using (HttpResponseMessage response = await client.GetAsync(serviceUrl))
                return await response.Content.ReadAsStringAsync();
        }

        
    }
}
