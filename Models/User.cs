﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CounselApi.Models
{
	public class User
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string  FirstName { get; set; }

		[Required]
		public string LastName { get; set; }
		public string MatricNo { get; set; }

		[Required]
		public string Password { get; set; }
		public string Department { get; set; }

		[Required]
		public string Email { get; set; }
		public bool IsAdmin { get; set; }
	}
}
