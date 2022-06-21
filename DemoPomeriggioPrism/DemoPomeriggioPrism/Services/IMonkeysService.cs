using DemoPomeriggioPrism.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoPomeriggioPrism.Services
{
    public interface IMonkeysService
    {
        Task<IEnumerable<Monkey>> GetMonkeys();
    }
}
