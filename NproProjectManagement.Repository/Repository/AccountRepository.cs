using NproProjectManagement.Common.Models;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public  class AccountRepository : IAccountRepository
    {
        public readonly NproContext _context;
        public AccountRepository(NproContext context)
        {
            _context = context;
        }

        public async Task<bool> IsValidUserAsync(string username, string password)
        {
            var user = await _context.Users.FindAsync(username, password);
            if (user != null) 
            { 
                 return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<User> GetUserAsync(string username, string password)
        {
            var user =  _context.Users.Where(u=> u.Username == username && u.Password == password && u.IsActive == true).SingleOrDefault();
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public async Task<User> GetUserAsync(string username)
        {
            var user = _context.Users.Where(u => u.Username == username && u.IsActive == true).SingleOrDefault();
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<User>> GetAllUserAsync()
        {
            var user = _context.Users.Where(u => u.IsActive == true).ToList();
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }


        public async Task<int> GetTaskCountByProjectId(int projectId)
        {
            int count = _context.Tasks.Count(t => t.ProjectId == projectId);           
            if (count != 0)
            {
                return count;
            }
            else
            {
                return 0;
            }
        }

        public async Task<int> GetUserCountByProjectId(int projectId)
        {
            int count = _context.UserProjectMappings.Count(t => t.ProjectId == projectId);
            if (count != 0)
            {
                return count;
            }
            else
            {
                return 0;
            }
        }

        public async Task<List<Project>> GetAllProjectsAsync()
        {
            var project = _context.Projects.Where(u => u.IsActive == true).ToList();
            if (project != null)
            {
                return project;
            }
            else
            {
                return null;
            }
        }
    }
}
