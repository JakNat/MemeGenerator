using Caliburn.Micro;
using DalSoft.RestClient;
using MemeGenerator.Client.Services;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace MemeGenerator.Client.ViewModels
{
    public class RestClientSetting
    {
        public string Token { get; set; }
        public string address { get; set; }
    }
    public class RestClientApp : IRestClientApp
    {
        private readonly RestClientSetting restClientSetting;

        public RestClientApp(RestClientSetting restClientSetting)
        {
            this.restClientSetting = restClientSetting;
        }
        public async Task<RestClient> Build()
        {
            if (restClientSetting.Token != null)
            {
                return new RestClient(restClientSetting.address, new Config()
                .UseHandler(async (request, token, next) =>
                {
                    request.Headers.Add("Authorization", "Bearer " + restClientSetting.Token);
                    return await next(request, token);

                }));
            }
            else
            {
                return new RestClient(restClientSetting.address);
            }
        }
    }
    public interface IRestClientApp
    {
        Task<RestClient> Build();
    }


    public class LoginViewModel : Screen
    {

        private readonly IAuthService _authService;
        public LoginViewModel(IAuthService authService)
        {
            _authService = authService;
        }

        #region private properties
        private string _userName;
        private string _password;
        #endregion

        #region public properties
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                NotifyOfPropertyChange(() => UserName);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }
        #endregion

        #region Buttons
        /// <summary>
        /// button -> login to server
        /// </summary>
        public async Task Login()
        {
            var response = await _authService.Login(UserName, Password);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("You are logged.");
            }
            else
            {
                MessageBox.Show("Error ocured.");
            }
        }
        #endregion

        #region Validators
        /// <summary>
        /// validator -> Login button
        /// </summary>
        public bool CanLogin
        {
            get
            {
                return true;
               // return client?.ServerConnection != null
               // && !String.IsNullOrWhiteSpace(UserName)
               // && !String.IsNullOrWhiteSpace(Password);
            }
        }
        #endregion
    }
}
