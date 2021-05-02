using System;
using TriviaApp.Models;
using TriviaApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TriviaApp
{
    public partial class App : Application
    {

        public User User { get; set; }
        public App()
        {
            InitializeComponent();
            NavigationPage page = new NavigationPage(new LogIn());
            page.BarBackgroundColor = Color.CadetBlue;
            MainPage = page;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
