using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PetGallery.Core
{
    public static class ApiHelper
    {
        public static HttpClient Client { get; set; }

        static ApiHelper()
        {
            InitApi();    
        }

        private static void InitApi()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("https://api.thecatapi.com/v1/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}