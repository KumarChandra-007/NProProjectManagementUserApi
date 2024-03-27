using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IAccountService
    {
        Task<LoginResponse> AuthenticateAsync(string username, string password);
        Task<UserViewModel> GetUserDetailsAsync(string username);
        Task<List<UserViewModel>> GetAllUserDetailsAsync();
    }
}
