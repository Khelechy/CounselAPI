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
			var userItems = _repository.GetAllUsers();
			return Ok(_mapper.Map<IEnumerable<UserReadDto>>(userItems));
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
		[HttpPost("register")]
		public ActionResult<UserReadDto> CreateUser(UserCreateDto userCreateDto)
		{
			var userModel = _mapper.Map<User>(userCreateDto);
			_repository.CreateUser(userModel);
			var isRegistered = _repository.SaveChanges();

			if (isRegistered != true)
				return BadRequest(new { message = "could not register" });

			var userReadDto = _mapper.Map<UserReadDto>(userModel);

			return CreatedAtRoute(nameof(GetUserById), new { Id = userReadDto.Id }, userReadDto);
			//return Ok(userReadDto);
		}

		[HttpPost("login")]
		public ActionResult<UserReadDto> Login([FromBody] LoginModel model)
		{
			var user = _repository.Login(model.Email, model.Password);
			if (user == null)
				return NotFound(new { message = "Email or Password is Incorrect" });
			var loginDto = _mapper.Map<UserReadDto>(user);
			return Ok(loginDto);
			
		}
	}
}
