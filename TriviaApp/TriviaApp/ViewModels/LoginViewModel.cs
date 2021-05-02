using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using TriviaApp.Views;
using Xamarin.Forms;
using System.Threading.Tasks;
using TriviaApp.Services;
using TriviaApp.Models;
namespace TriviaApp.ViewModels
{
    class LogInViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #region fields
        private string email;
        private string password;
        private string error;

        #endregion
        #region events
        public event Action<Page> Push;
        public event Action<Page> PushModal;
        #endregion
        #region properties
        public string Error
        {
            get
            {
                return error;
            }
            set
            {
                if (error != value)
                {
                    error = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged();
                }
            }
        }
        public ICommand LoginCommand { get; set; }
        public ICommand ContinueAsGuestCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        #endregion
        #region constructor
        public LogInViewModel()
        {
            Email = string.Empty;
            Password = string.Empty;
            Error = string.Empty;
            LoginCommand = new Command(Login);
            ContinueAsGuestCommand = new Command(ContinueAsGuest);
            RegisterCommand = new Command(Register);
        }
        #endregion
        #region functions
        private async void Login()
        {
            TriviaWebAPIProxy proxy = TriviaWebAPIProxy.CreateProxy();
            Task<User> loginTask = proxy.LoginAsync(Email, Password);
            await loginTask;
            if (loginTask.Result != null)
            {
                ((App)App.Current).User = loginTask.Result;
                PushModal?.Invoke(new QuestioningPage());
            }
            else
                Error = "Email or NickName Does Not Match";
        }
        private void ContinueAsGuest()
        {
            PushModal?.Invoke(new QuestioningPage());
        }
        private void Register()
        {
            Push?.Invoke(new Register(false));
        }
        #endregion
    }
}
