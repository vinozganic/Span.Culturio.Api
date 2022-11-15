using Microsoft.AspNetCore.Mvc;
using Span.Culturio.Api.Models;
using Span.Culturio.Api.Models.Authorization;
using Span.Culturio.Api.Models.User;
using Span.Culturio.Api.Services.User;
using Span.Culturio.Api.Services.UserService;
using System.ComponentModel.DataAnnotations;

namespace Span.Culturio.Api.Controllers
{

    [Route("/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get users
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<UsersDto>> GetUsersAsync([Required][FromQuery] int pageSize, [Required][FromQuery] int pageIndex)
        {
            var users = await _userService.GetUsersAsync(pageSize, pageIndex);
            return Ok(users);
        }

        /// <summary>
        /// Get single user by Id
        /// </summary>
        [HttpGet("/users/{id}")]
        public async Task<ActionResult<UserDto>> GetUserByIdAsync(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user is null) return NotFound();
            return Ok(user);
        }

       
    }
}