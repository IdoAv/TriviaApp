using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TriviaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogIn : ContentPage
    {
        public LogIn()
        {
            InitializeComponent();
            LogInViewModel viewModel = new LogInViewModel();
            viewModel.Push += (p) => Navigation.PushAsync(p);
            viewModel.PushModal += (p) => Navigation.PushModalAsync(p);
            this.BindingContext = viewModel;
        }
    }
}