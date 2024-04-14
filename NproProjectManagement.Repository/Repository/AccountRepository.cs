using NproProjectManagement.Common.Models;
using NproProjectManagement.Common.ViewModels;
using Repositories.Interface;

namespace Repositories.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public readonly NproContext _context;
        public AccountRepository(NproContext context)
        {
            _context = context;
        }

        public async Task<bool> IsValidUserAsync(string username, string password)
        {
            var user = await _context.Users.FindAsync(username, password);
            return user != null ? true : false;
        }
        public async Task<User> GetUserAsync(string username, string password)
        {
            var user = _context.Users.Where(u => u.Username == username && u.Password == password && u.IsActive == true).SingleOrDefault();
            return user ?? null;
        }

        public async Task<User> GetUserAsync(string username)
        {
            var user = _context.Users.Where(u => u.Username == username && u.IsActive == true).SingleOrDefault();
            return user ?? null;
        }

        public async Task<List<User>> GetAllUserAsync()
        {
            var users = _context.Users.Where(u => u.IsActive == true).ToList();
            return users ?? null;
        }

        public async Task<int> GetTaskCountByProjectId(int projectId)
        {
            int count = _context.Tasks.Count(t => t.ProjectId == projectId);
            return count != 0 ? count : 0;
        }
        public async Task<AllProjectInfo> GetAllProjectInfo()
        {
            try
            {
                AllProjectInfo info = new AllProjectInfo();
                var tasks = _context.Tasks.ToList();
                var projects = _context.Projects.Where(p => p.IsActive == true).ToList();
                info.AllTaskCount = tasks.Count();
                info.CompletedTaskCount = tasks.Count(t => t.Status.ToLower().Contains("completed"));
                info.PendingTaskCount = tasks.Count(t => !t.Status.ToLower().Contains("completed"));
                info.AllProjectCount = projects.Count();
                info.ProjectUserTaskGridInfo = new List<ProjectUserTask>();
                var statuses = _context.Statuses.ToList();

                projects.ForEach(project =>
                {
                    string statusPercentage = string.Empty;
                    ProjectUserTask userTask = new ProjectUserTask();
                    statuses.ForEach(status =>
                    {
                        var count = tasks.Count(task => project.ProjectId == task.ProjectId && task.Status.ToLower() == status.StatusId.ToString().ToLower());
                        statusPercentage += status.StatusName + ":" + count.ToString() + ",";
                    });
                    if (statusPercentage != string.Empty)
                    {
                        statusPercentage = statusPercentage.Remove(statusPercentage.Length - 1);
                    }
                    userTask.ProjectId = project.ProjectId;
                    userTask.Title = project.Title;
                    userTask.UserCount = _context.UserProjectMappings.Count(t => t.ProjectId == project.ProjectId);
                    userTask.TaskCount = tasks.Count(t => t.ProjectId == project.ProjectId);
                    userTask.StatusPercentage = statusPercentage;
                    info.ProjectUserTaskGridInfo.Add(userTask);
                });

                return info;
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                return null;
            }
        }
        public async Task<int> GetUserCountByProjectId(int projectId)
        {
            int count = _context.UserProjectMappings.Count(t => t.ProjectId == projectId);
            return count != 0 ? count : 0;
        }
        public async Task<int> SaveUser(User user)
        {
            await _context.Users.AddAsync(user);
            int rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected;
        }

        public async Task<int> UpdateUser(User user)
        {
            _context.Users.Update(user);
            int rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected;
        }

        public async Task<int> DeleteUser(User user)
        {
            _context.Users.Remove(user);
            int rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected;
        }

        public async Task<List<Project>> GetAllProjectsAsync()
        {
            var project = _context.Projects.Where(p => p.IsActive == true).ToList();
            return project ?? null;
        }

        public async Task<string> GetRoleByIdAsync(int id)
        {
            var role = _context.Roles.Where(r => r.IsActive == true && r.RoleId == id).Select(r => r.RoleName).SingleOrDefault();
            return role ?? null;
        }
    }
}
