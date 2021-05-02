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
    public partial class Register : ContentPage
    {
        public Register(bool popOrPush)
        {
            InitializeComponent();
            RegisterViewModel viewModel = new RegisterViewModel(popOrPush);
            viewModel.Pop += () => Navigation.PopAsync();
            viewModel.PushModal += (p) => Navigation.PushModalAsync(p);
            this.BindingContext = viewModel;
        }
    }
}