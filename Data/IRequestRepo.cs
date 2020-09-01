using CounselApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CounselApi.Data
{
	public interface IRequestRepo
	{
		bool SaveChanges();
		IEnumerable<Request> GetAllRequest();
		Request GetRequestById(int id);
		void CreateRequest(Request request);
	}
}
