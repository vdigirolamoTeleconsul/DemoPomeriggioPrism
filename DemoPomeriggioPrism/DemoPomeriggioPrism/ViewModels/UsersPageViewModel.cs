using DemoPomeriggioPrism.Models;
using DemoPomeriggioPrism.Services;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace DemoPomeriggioPrism.ViewModels
{
    public class UsersPageViewModel : BindableBase, INavigationAware
    {
        private ObservableCollection<User> users = new ObservableCollection<User>();
        private readonly IReqResService reqResService;
        private readonly INavigationService navigationService;

        public ICommand CreateUser { get; set; }

        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        public ObservableCollection<User> Users
        {
            get { return users; }
            set { SetProperty(ref users, value); }
        }

        public UsersPageViewModel(IReqResService reqResService, INavigationService navigationService)
        {
            this.reqResService = reqResService;
            this.navigationService = navigationService;

            CreateUser = new Command(async () => await navigationService.NavigateAsync("CreateUserPage"));
            
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            //throw new System.NotImplementedException();
        }

        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            IsBusy = true;

            var data = await reqResService.GetUsers();

            Users.Clear();

            data.ForEach(x => Users.Add(x));

            IsBusy = false;

            //foreach (var item in data)
            //{
            //    Users.Add(item);
            //}

        }

        

    }
}
