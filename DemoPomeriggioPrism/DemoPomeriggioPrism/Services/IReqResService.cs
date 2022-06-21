using DemoPomeriggioPrism.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoPomeriggioPrism.Services
{
    public interface IReqResService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<bool> CreateUser(UserCreate user);
    }
}
