using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CounselApi.Dtos
{
	public class UserReadDto
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MatricNo { get; set; }
		public string Department { get; set; }
		public string Email { get; set; }
		public bool IsAdmin { get; set; }
	}
}
