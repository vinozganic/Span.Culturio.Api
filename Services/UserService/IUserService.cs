using System;
using Span.Culturio.Api.Models;
using Span.Culturio.Api.Models.Authorization;
using Span.Culturio.Api.Models.User;

namespace Span.Culturio.Api.Services.UserService
{
	public interface IUserService
	{
        Task<UsersDto> GetUsersAsync(int pageSize, int pageIndex);
        Task<UserDto> GetUserByIdAsync(int id);
        Task<UserDto> RegisterUser(RegisterUserDto registerUserDto);
        Task<TokenDto> Login(LoginDto loginUserdto);
    }
}

