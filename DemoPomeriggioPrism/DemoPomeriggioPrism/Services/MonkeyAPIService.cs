using DemoPomeriggioPrism.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DemoPomeriggioPrism.Services
{
    public class MonkeyAPIService : IMonkeysService
    {
        public async Task<IEnumerable<Monkey>> GetMonkeys()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://montemagno.com/monkeys.json");
            return JsonConvert.DeserializeObject<List<Monkey>>(json);
        }
    }
}
