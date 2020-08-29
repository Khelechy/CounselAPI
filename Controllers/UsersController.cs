using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CounselApi.Data;
using CounselApi.Dtos;
using CounselApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CounselApi.Controllers
{
	[Route("api/users")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserRepo _repository;
		private readonly IMapper _mapper;

		public UsersController(IUserRepo repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		//Get api/users
		[HttpGet]
		public ActionResult <IEnumerable<UserReadDto>> GetAllUsers()
		{
			var UserItems = _repository.GetAllUsers();
			return Ok(_mapper.Map<IEnumerable<UserReadDto>>(UserItems));
		}

		//Get api/users/{id}
		[HttpGet("{id}", Name = "GetUserById")]
		public ActionResult <UserReadDto> GetUserById(int id)
		{
			var userItem = _repository.GetUserById(id);
			if(userItem != null) {
				return Ok(_mapper.Map<UserReadDto>(userItem));
			}
			return NotFound();
			
		}

		//Post api/users
		[HttpPost]
		public ActionResult<UserReadDto> CreateUser(UserCreateDto userCreateDto)
		{
			var userModel = _mapper.Map<User>(userCreateDto);
			_repository.CreateUser(userModel);
			_repository.SaveChanges();

			var userReadDto = _mapper.Map<UserReadDto>(userModel);

			return CreatedAtRoute(nameof(GetUserById), new { Id = userReadDto.Id }, userReadDto);
			//return Ok(userReadDto);
		}
	}
}
