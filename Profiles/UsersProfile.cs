using AutoMapper;
using CounselApi.Dtos;
using CounselApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;

namespace CounselApi.Profiles
{
	public class UsersProfile : Profile
	{
		public UsersProfile()
		{
			CreateMap<User, UserReadDto>();
			CreateMap<UserCreateDto, User>();
		}
	}
}
