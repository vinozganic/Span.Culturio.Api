using Span.Culturio.Api.Models.User;

namespace Span.Culturio.Api.Models
{
    public class UsersDto
    {
        public IEnumerable<UserDto> Data { get; set; }
        public int TotalCount { get; set; }
    }
}