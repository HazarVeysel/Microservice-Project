using Core.JWT;
using Core.Models;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
   

    public interface IAuthApiService
    {
        Task<string> GetToken(Login user);
        Task<string> GetUser(string method, Users user);
        void SetToken(AccessToken token);
        Task<string> GetCompany();
        void DeleteToken();
        Task<string> GetAddressCardList();

    }

    class AuthApiService : IAuthApiService
    {

        string url = "http://localhost:7231/"; //Burası localde çalıştırılırken servisler docker'da ise şöyle olacak; http://localhost:7231/. Servisler docker'da değilse https ile başlayacak.
        string serviceUrl = "";
        string existtoken = "";
        string UserInfo = "";
        HttpClient client = new HttpClient();

        public async Task<string> GetToken(Login user)
        {
            
            serviceUrl = $"{url}gate/login";
            //veriyi form olarak gönderdiğimiz için hata veriyordu. Json tipine çevirdik. Api'ye json olarak gönderdik.
            var json = new JavaScriptSerializer().Serialize(user);

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            //HttpContent c = new StringContent(pairs, Encoding.UTF8, "application/json");


                HttpResponseMessage responseMessage = null;
                try
                {
                    responseMessage = await client.PostAsync(serviceUrl, content);
                }
                catch (Exception ex)
                {
                    if (responseMessage == null)
                    {
                        responseMessage = new HttpResponseMessage();
                    }
                    responseMessage.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                    responseMessage.ReasonPhrase = string.Format("RestHttpClient.SendRequest failed: {0}", ex);
                }



                return await responseMessage.Content.ReadAsStringAsync();
            
            

        }

        public void SetToken(AccessToken token)
        {

            if (token != null)
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.Token);
            existtoken = token.Token;
        }

        

        public async Task<string> GetUser(string method, Users user)
        {

            var json = new JavaScriptSerializer().Serialize(user);

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            serviceUrl = $"{url}api/user/{method}";
            using (HttpResponseMessage response = await client.PostAsync(serviceUrl, content))
                return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> GetCompany()
        {
            
            serviceUrl = $"{url}gate/company";
            using (HttpResponseMessage response = await client.GetAsync(serviceUrl))
                return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> GetAddressCardList()
        {
            serviceUrl = $"{url}gate/getcardslist";
            using (HttpResponseMessage response = await client.GetAsync(serviceUrl))
                return await response.Content.ReadAsStringAsync();
        }

        public void DeleteToken()
        {

            client.DefaultRequestHeaders.Authorization=null;
        }

        
    }

}
