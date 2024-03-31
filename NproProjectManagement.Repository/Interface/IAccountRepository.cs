using NproProjectManagement.Common.Models;
using NproProjectManagement.Common.ViewModels;
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
        Task<int> GetUserCountByProjectId(int projectId);
        Task<int> GetTaskCountByProjectId(int projectId);
        Task<List<Project>> GetAllProjectsAsync();
        Task<AllProjectInfo> GetAllProjectInfo();
        Task<int> SaveUser(User user);
        Task<int> UpdateUser(User user);
        Task<int> DeleteUser(User user);
    }
}
