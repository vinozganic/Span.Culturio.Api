using System;
using AutoMapper;
using Span.Culturio.Api.Data.Entities;
using Span.Culturio.Api.Models.Authorization;
using Span.Culturio.Api.Models.User;

namespace Span.Culturio.Api.Profiles
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<Data.Entities.User, UserDto>();
			CreateMap<RegisterUserDto, User>();
		}
	}
}

