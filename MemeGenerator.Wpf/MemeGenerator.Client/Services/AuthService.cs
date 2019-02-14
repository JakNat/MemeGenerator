using MemeGenerator.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MemeGenerator.Client.Services
{
    public class AuthService : IAuthService
    {
        private readonly RestClientSetting _restClientSetting;
        private readonly IRestClientApp _restClientApp;

        public AuthService(IRestClientApp restClientApp, RestClientSetting restClientSetting)
        {
            _restClientSetting = restClientSetting;
            _restClientApp = restClientApp;
        }

        public async Task<HttpResponseMessage> Login(string email, string password)
        {
            dynamic client = await _restClientApp.Build();
            var user = new { Email = email, Password = password };
            var result = await client.Login.Post(user);

            HttpResponseMessage httpResponseMessage = result.HttpResponseMessage;
            if (httpResponseMessage.IsSuccessStatusCode)
                _restClientSetting.Token = result.token;

            return result.HttpResponseMessage;
        }

        public async Task<HttpResponseMessage> Register(string userName, string password)
        {
            dynamic client = await _restClientApp.Build();
            var user = new { Email = userName, Password = password, Role = "admin" };
            var result = await client.Users.Post(user);
            return result.HttpResponseMessage;
        }
    }
}
