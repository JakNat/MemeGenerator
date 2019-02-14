using Caliburn.Micro;
using MemeGenerator.Client.Extensions;
using MemeGenerator.Client.Services;
using System.Threading.Tasks;
using System.Windows;

namespace MemeGenerator.Client.ViewModels
{
    public class RegisterViewModel : Screen
    {
        private readonly IAuthService _authService;
        public RegisterViewModel(IAuthService authService)
        {
            _authService = authService;
        }

        #region private properties
        private string _userName;
        private string _password;
        private string _confirmPassword;
        #endregion

        #region public properties
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
           
                NotifyOfPropertyChange(() => UserName);
                NotifyOfPropertyChange(() => CanRegister);
            }
        }
        
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanRegister);
            }
        }
       
        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set
            {
                _confirmPassword = value;
                NotifyOfPropertyChange(() => ConfirmPassword);
                NotifyOfPropertyChange(() => CanRegister);
            }
        }
        #endregion

        #region Buttons
        /// <summary>
        /// Register button
        /// </summary>
        public async Task Register()
        {
            var response = await _authService.Register(UserName, Password);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("You are registered.");
            }
            else
            {
                MessageBox.Show("Error ocured.");
            }
        }
        #endregion

        #region Validators
        /// <summary>
        /// Validator -> Register button
        /// </summary>
        public bool CanRegister =>
            !UserName.IsEmpty() &&
            !Password.IsEmpty() &&
            Password.Equals(ConfirmPassword);
        #endregion
    }
}
