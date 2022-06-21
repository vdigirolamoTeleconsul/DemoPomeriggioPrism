using DemoPomeriggioPrism.Services;
using DemoPomeriggioPrism.ViewModels;
using DemoPomeriggioPrism.Views;
using Prism;
using Prism.Ioc;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace DemoPomeriggioPrism
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.Register<IMonkeysService, MonkeyAPIService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<SecondPage, SecondPageViewModel>();

            containerRegistry.RegisterSingleton<IApplicationContext, ApplicationContext>();
            containerRegistry.Register<IReqResService, ReqResService>();

            containerRegistry.RegisterForNavigation<UsersPage, UsersPageViewModel>();
            containerRegistry.RegisterForNavigation<CreateUserPage, CreateUserPageViewModel>();
        }
    }
}
