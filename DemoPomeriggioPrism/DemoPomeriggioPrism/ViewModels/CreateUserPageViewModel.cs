using DemoPomeriggioPrism.Models;
using DemoPomeriggioPrism.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace DemoPomeriggioPrism.ViewModels
{
    public class CreateUserPageViewModel : BindableBase
    {
        private readonly IReqResService reqResService;
        private readonly INavigationService navigationService;

        public DelegateCommand CreateUserCommand { get; set; }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                SetProperty(ref name, value);
                //SetProperty(ref isEnabled, (Name?.Length > 0 && Job?.Length > 0));
                IsEnabled = (Name?.Length > 0 && Job?.Length > 0);
            }
        }

        private string job;
        public string Job
        {
            get { return job; }
            set
            {
                SetProperty(ref job, value);
                //SetProperty(ref isEnabled, (Name?.Length > 0 && Job?.Length > 0));
                IsEnabled = (Name?.Length > 0 && Job?.Length > 0);
            }
        }

        private bool isEnabled;
        public bool IsEnabled
        {
            get
            {
                //isEnabled = (Name?.Length > 0 && Job?.Length > 0);
                return isEnabled;
            }
            set { SetProperty(ref isEnabled, value); }
        }

        private bool responseSuccess;
        public bool ResponseSuccess
        {
            get { return responseSuccess; }
            set { SetProperty(ref responseSuccess, value); }
        }

        public CreateUserPageViewModel(IReqResService reqResService, INavigationService navigationService)
        {
            this.reqResService = reqResService;
            this.navigationService = navigationService;

            //CreateUser = new Command(async () =>
            //{

            //    UserCreate user = new UserCreate { Name = Name, Job = Job };

            //    await reqResService.CreateUser(user);

            //});

            CreateUserCommand = new DelegateCommand(Submit, CanSubmit).ObservesProperty(() => IsEnabled);

        }

        private bool CanSubmit()
        {
            return IsEnabled;
        }

        private async void Submit()
        {
            UserCreate user = new UserCreate { Name = Name, Job = Job };

            ResponseSuccess = await reqResService.CreateUser(user);

            if (ResponseSuccess == true)
            {
                await navigationService.NavigateAsync("SecondPage");
            }

        }
    }
}
