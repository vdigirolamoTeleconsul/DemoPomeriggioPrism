using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace DemoPomeriggioPrism.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;

        public ICommand NavigaCommand { get; set; }
        public ICommand UsersCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            NavigaCommand = new Command(Naviga);
            UsersCommand = new Command(async () => await navigationService.NavigateAsync("UsersPage"));
            this.navigationService = navigationService;

        }

        public async void Naviga()
        {
            var navigationParameters = new NavigationParameters();
            navigationParameters.Add("parametro1", "valore1");
            await navigationService.NavigateAsync("SecondPage", navigationParameters);
        }
    }
}
