using Common.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using System.Security.Claims;

namespace NproProjectManagement.Controllers
{
    [Route("userapi")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        public readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        /// <summary>
        /// Logins the specified login model.
        /// </summary>
        /// <param name="Authenticate">The login model.</param>
        /// <returns>IActionResult</returns>
        [HttpGet]
        [Route("Authenticate")]
        public async Task<IActionResult> Authenticate(string username, string password)
        {
            var result = await _accountService.AuthenticateAsync(username, password);
            return Ok(result);
        }
        [Authorize]
        [HttpGet]
        [Route("GetUserDetails")]
        public async Task<IActionResult> GetUserDetails()
        {
            string username = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
            var result = await _accountService.GetUserDetailsAsync(username);
            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        [Route("GetAllUserDetails")]
        public async Task<IActionResult> GetAllUserDetails()
        {          
            var result = await _accountService.GetAllUserDetailsAsync();
            return Ok(result);
        }

        //[Authorize]
        //[HttpGet]
        //[Route("CreateUpdateUser")]
        //public async Task<IActionResult> CreateUpdateUser(UserViewModel userViewModel)
        //{
        //    var result = await _accountService.GetAllUserDetailsAsync();
        //    return Ok(result);
        //}


        [Authorize]
        [HttpGet]
        [Route("GetProjectUserTaskMapping")]
        public async Task<IActionResult> GetProjectUserTaskMapping()
        {
            var result = await _accountService.GetProjectUserTaskMappingAsync();
            return Ok(result);
        }
    }
}
