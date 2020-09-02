using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CounselApi.Data;
using CounselApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CounselApi.Controllers
{
	[Route("api/requests")]
	[ApiController]
	public class RequestsController : ControllerBase
	{
		private readonly IRequestRepo _repository;
		private readonly IMapper _mapper;
		private readonly IUserRepo _userRepo;

		public RequestsController(IRequestRepo repository, IMapper mapper, IUserRepo userRepo)
		{
			_repository = repository;
			_mapper = mapper;
			_userRepo = userRepo;
		}

		//Get api/request
		[HttpGet]
		public ActionResult<IEnumerable<Request>> GetAllRequest()
		{
			var userItems = _repository.GetAllRequest();
			return Ok(userItems);
		}

		//Get api/request/{id}
		[HttpGet("{id}", Name = "GetRequestById")]
		public ActionResult<Request> GetRequestById(int id)
		{
			var userItem = _repository.GetRequestById(id);
			if (userItem != null)
			{
				return Ok(userItem);
			}
			return NotFound();

		}

		//Post api/request
		[HttpPost("create")]
		public ActionResult<Request> CreateRequest([FromBody] RequestModel request)
		{
			
			var user = _userRepo.GetUserById(request.UserId);
			var requestBody = new Request
			{
				UserId = user.Id,
				FullName = user.FirstName + " " + user.LastName,
				Department = user.Department,
				Email = user.Email,
				MatricNo = user.MatricNo,
				IsActive = false,
				Problem = request.Problem
			};
			_repository.CreateRequest(requestBody);
			var isRequested = _repository.SaveChanges();

			if (isRequested != true)
				return BadRequest(new { message = "could not make request" });

			return CreatedAtRoute(nameof(GetRequestById), new { Id = requestBody.Id }, requestBody);
		}
	}
}
