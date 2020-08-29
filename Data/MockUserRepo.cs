using CounselApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CounselApi.Data
{
	public class MockUserRepo : IUserRepo
	{
		public void CreateUser(User user)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<User> GetAllUsers()
		{
			var users = new List<User>
			{
				new User { Id=0, FirstName="Kelechi", LastName="Onyekwere", Department="Computer Science", Email="myemail@email.com", IsAdmin=false, MatricNo="2017/246354", Password="qwerty"},
				new User { Id=1, FirstName="Peace", LastName="Onyisi", Department="Mathematics", Email="peacemyemail@email.com", IsAdmin=false, MatricNo="2017/244654", Password="qwerty123"},
				new User { Id=2, FirstName="John", LastName="Doe", Department="Statistics", Email="elmmmyemail@email.com", IsAdmin=false, MatricNo="2017/237854", Password="123qwerty"}
			};

			return users;
		}

		public User GetUserById(int id)
		{
			return new User { Id = 0, FirstName = "Kelechi", LastName = "Onyekwere", Department = "Computer Science", Email = "myemail@email.com", IsAdmin = false, MatricNo = "2017/246354", Password = "qwerty" };
		}

		public bool SaveChanges()
		{
			throw new NotImplementedException();
		}
	}
}
