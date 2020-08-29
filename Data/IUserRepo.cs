using CounselApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CounselApi.Data
{
	public interface IUserRepo
	{
		bool SaveChanges();
		IEnumerable<User> GetAllUsers();
		User GetUserById(int id);
		void CreateUser(User user);
	}
}
