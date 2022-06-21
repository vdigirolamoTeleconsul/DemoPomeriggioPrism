using Xamarin.Essentials;

namespace DemoPomeriggioPrism.Services
{
    public class ApplicationContext : IApplicationContext
    {
        public string GetReqResAdress()
        {
            return Preferences.Get("ReqResAdress", "https://reqres.in/api/users");
        }

        public void SetReqResAdress(string ReqResAdress)
        {
            Preferences.Set("ReqResAdress", ReqResAdress);
        }
    }
}
