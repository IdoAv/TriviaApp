using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TriviaApp.Models;
using TriviaApp.Services;
using TriviaApp.Views;
using Xamarin.Forms;

namespace TriviaApp.ViewModels
{
    class RegisterViewModel : INotifyPropertyChanged
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
        private string nickName;
        private string error;
        //pop - true  push - false
        private bool popOrPush;
        #endregion
        #region events
        public event Action<Page> PushModal;
        public event Action Pop;
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
        public string Nickname
        {
            get
            {
                return nickName;
            }
            set
            {
                if (nickName != value)
                {
                    nickName = value;
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
        public ICommand RegisterCommand { get; set; }
        #endregion
        #region constructor
        public RegisterViewModel(bool popOrPush)
        {
            Email = string.Empty;
            Password = string.Empty;
            Error = string.Empty;
            Nickname = string.Empty;
            this.popOrPush = popOrPush;
            RegisterCommand = new Command(Register);
        }
        #endregion
        #region functions
        private async void Register()
        {
            TriviaWebAPIProxy proxy = TriviaWebAPIProxy.CreateProxy();
            User user = new User()
            {
                Email = Email,
                NickName = Nickname,
                Password = Password
            };
            Task<bool> registerTask = Task.Run(() => proxy.RegisterUser(user));
            await registerTask;
            if (registerTask.Result)
            {
                ((App)App.Current).User = user;
                if (!popOrPush)
                    PushModal?.Invoke(new QuestioningPage());
                else
                    Pop?.Invoke();
            }
            else
                Error = "Email or NickName Exists";

        }
        #endregion
    }
}
