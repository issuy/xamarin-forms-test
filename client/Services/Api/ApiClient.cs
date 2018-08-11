using System;
using System.Net.Http;


namespace client.Services.Api
{
    public static class ApiClient
    {
        static HttpClient _client;

        public static HttpClient Client
        {
            get
            {
                if (_client == null) Initialize();
                return _client;
            }
        }

        static void Initialize()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri($"{Configs.Local.Api.BaseAddress}/");
        }
    }
}
