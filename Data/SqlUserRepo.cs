using CounselApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CounselApi.Data
{
	public class SqlUserRepo : IUserRepo
	{
		private readonly CounselContext _context;

		public SqlUserRepo(CounselContext context)
		{
			_context = context;
		}

		public void CreateUser(User user)
		{
			if(user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}
			_context.Users.Add(user);
		}

		public IEnumerable<User> GetAllUsers()
		{
			return _context.Users.ToList();
		}

		public User GetUserById(int id)
		{
			return _context.Users.FirstOrDefault(u => u.Id == id);
		}

		public bool SaveChanges()
		{
			return (_context.SaveChanges() >= 0);
		}
	}
}
