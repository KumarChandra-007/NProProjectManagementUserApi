using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IAccountRepository
    {
        Task<bool> IsValidUserAsync(string username, string password);
        Task<User> GetUserAsync(string username, string password);
        Task<User> GetUserAsync(string username);
        Task<List<User>> GetAllUserAsync();
    }
}
