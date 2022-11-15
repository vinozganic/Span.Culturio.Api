using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Span.Culturio.Api.Data;
using Span.Culturio.Api.Helpers;
using Span.Culturio.Api.Models;
using Span.Culturio.Api.Models.Authorization;
using Span.Culturio.Api.Models.User;
using Span.Culturio.Api.Services.UserService;

namespace Span.Culturio.Api.Services.User
{
    public class UserService : IUserService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public UserService(DataContext dataContext, IMapper mapper, IConfiguration config)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _config = config;
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _dataContext.Users.FindAsync(id);
            if (user is null) return null;

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UsersDto> GetUsersAsync(int pageSize, int pageIndex)
        {
            var users = await _dataContext.Users
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();

            var data = _mapper.Map<IEnumerable<UserDto>>(users);

            var usersDto = new UsersDto
            {
                Data = data,
                TotalCount = await _dataContext.Users.CountAsync()
            };

            return usersDto;
        }

        public async Task<UserDto> RegisterUser(RegisterUserDto registerUserDto)
        {
            var user = _mapper.Map<Data.Entities.User>(registerUserDto);

            if (user is null) return null;

            UserHelper.CreatePasswordHash(registerUserDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _dataContext.Add(user);
            await _dataContext.SaveChangesAsync();

            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }

        public async Task<TokenDto> Login(LoginDto loginUserDto)
        {
            var user = await _dataContext.Users.SingleOrDefaultAsync(x => x.Username == loginUserDto.Username);

            if (user is null) return null;

            if (!UserHelper.VerifyPasswordHash(loginUserDto.Password, user.PasswordHash, user.PasswordSalt)) return null;

            var token = UserHelper.CreateToken(loginUserDto, _config.GetSection("JWT_KEY").Value);

            return new TokenDto { Token = token };
        }
    }
}