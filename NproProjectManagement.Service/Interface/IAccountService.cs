using Common.ViewModels;
using NproProjectManagement.Common.Models;
using NproProjectManagement.Common.ViewModels;
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
        Task<AllProjectInfo> GetProjectUserTaskMappingAsync();
        Task<int> SaveUser(User user);
        Task<int> UpdateUser(User user);
        Task<int> DeleteUser(User user);
    }
}
