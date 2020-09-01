using CounselApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CounselApi.Data
{
	public class SqlRequestRepo : IRequestRepo
	{
		private readonly CounselContext _context;

		public SqlRequestRepo(CounselContext context)
		{
			_context = context;
		}
		public void CreateRequest(Request request)
		{
			
			if (request == null)
			{
				throw new ArgumentNullException(nameof(request));
			}
			_context.Requests.Add(request);
		}

		public IEnumerable<Request> GetAllRequest()
		{
			return _context.Requests.ToList();
		}

		public Request GetRequestById(int id)
		{
			return _context.Requests.FirstOrDefault(r => r.Id == id);
		}

		public bool SaveChanges()
		{
			return (_context.SaveChanges() >= 0);
		}
	}
}
