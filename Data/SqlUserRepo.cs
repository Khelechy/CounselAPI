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

		public User Login(string email, string password)
		{
			if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
				return null;
			var user = _context.Users.SingleOrDefault(u => u.Email == email);
			if (user == null)
				return null;
			if (user.Password != password)
				return null;

			return user;
		}

		public bool SaveChanges()
		{
			return (_context.SaveChanges() >= 0);
		}
	}
}
