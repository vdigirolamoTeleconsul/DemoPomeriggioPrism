using DemoPomeriggioPrism.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DemoPomeriggioPrism.Services
{
    internal class ReqResService : IReqResService
    {
        private readonly IApplicationContext context;
        private readonly HttpClient httpClient;

        public ReqResService(IApplicationContext context)
        {
            this.context = context;
            this.httpClient = new HttpClient();
        }

        public async Task<bool> CreateUser(UserCreate user)
        {
            JsonSerializerOptions option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var response = await httpClient.PostAsJsonAsync<UserCreate>(context.GetReqResAdress(), user, option);

            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            List<User> users = null;

            //var json = await httpClient.GetStringAsync(context.GetReqResAdress());

            var response = await httpClient.GetAsync(context.GetReqResAdress());

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                users = JsonConvert.DeserializeObject<ReqResResponse>(json).data;
            }

            return users;
        }


    }
}
