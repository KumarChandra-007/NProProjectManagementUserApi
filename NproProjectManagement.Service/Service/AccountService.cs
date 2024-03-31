using AutoMapper;
using Common.ViewModels;
using Microsoft.Data.SqlClient;
using NproProjectManagement.Common.Models;
using NproProjectManagement.Common.ViewModels;
using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class AccountService : IAccountService
    {
        public readonly IAccountRepository _accountRepository;
        public readonly AuthHelpers _authHelpers;
        private readonly IMapper _mapper;
        public AccountService(IAccountRepository accountRepository, AuthHelpers authHelpers)
        {
            _accountRepository = accountRepository;
            _authHelpers = authHelpers;
        }


        public async Task<LoginResponse> AuthenticateAsync(string username, string password)
        {

            var user = await _accountRepository.GetUserAsync(username, password);
            if (user == null)
            {
                var res = new LoginResponse();
                res.Message = "Invalid User";

                return res;
            }
            else
            {
                return _authHelpers.GenerateToken(user);
            }
        }
        public async Task<UserViewModel> GetUserDetailsAsync(string username)
        {
            var res = new UserViewModel();
            var user = await _accountRepository.GetUserAsync(username);
            if (user != null)
            {
                res.UserId = user.UserId;
                res.Username = user.Username;
                res.Role = user.Role;
                res.Email = user.Email;
                res.FirstName = user.FirstName;
                res.LastName = user.LastName;
                res.PhoneNumber = user.PhoneNumber;
                res.EmployeeCode = user.EmployeeCode;
                res.Region = user.Region;

                //var res = _mapper.Map(user, viewModel);
                //var result = _mapper.Map<UserViewModel>(user);

                return res;
            }
            else
            {
                return null;
            }
        }
        public async Task<List<UserViewModel>> GetAllUserDetailsAsync()
        {
            var result = new List<UserViewModel>();
            var user = await _accountRepository.GetAllUserAsync();
            if (user != null)
            {


                foreach (var item in user)
                {
                    var res = new UserViewModel();
                    res.UserId = item.UserId;
                    res.Username = item.Username;
                    res.Role = item.Role;
                    res.Email = item.Email;
                    res.FirstName = item.FirstName;
                    res.LastName = item.LastName;
                    res.PhoneNumber = item.PhoneNumber;
                    res.EmployeeCode = item.EmployeeCode;
                    res.Region = item.Region;
                    result.Add(res);
                }
                // return _mapper.Map<List<UserViewModel>>(user);
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<AllProjectInfo> GetProjectUserTaskMappingAsync()
        {
            var allProjectInfo = new AllProjectInfo();
            var result = new List<ProjectUserTask>();
            allProjectInfo = await _accountRepository.GetAllProjectInfo();

            //var project = await _accountRepository.GetAllProjectsAsync();
            //if (project != null)
            //{
            //    foreach (var item in project)
            //    {
            //        var res = new ProjectUserTask();

            //        res.ProjectId = item.ProjectId;
            //        res.Title = item.Title;
            //        res.UserCount = await _accountRepository.GetUserCountByProjectId(item.ProjectId);
            //        res.TaskCount = await _accountRepository.GetTaskCountByProjectId(item.ProjectId);
            //        result.Add(res);
            //    }

            //    allProjectInfo.ProjectUserTaskGridInfo = result;

                return allProjectInfo;
            //}
            //else
            //{
            //    return null;
            //}
        }
        public async Task<int> SaveUser(User user){
            return await _accountRepository.SaveUser(user);
        }
        public async Task<int> UpdateUser(User user) {
            return await _accountRepository.UpdateUser(user);
        }
        public async Task<int> DeleteUser(User user) {
            return await _accountRepository.DeleteUser(user);
        }
    }
}
