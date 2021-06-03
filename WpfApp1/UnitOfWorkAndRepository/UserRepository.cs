using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.UnitOfWorkAndRepository
{
	class UserRepository : IRepository<User>
	{
		private UserContext db;
		public UserRepository(UserContext context)
		{
			db = context;
		}
		public void Create(User item)
		{
			db.Users.Add(item);
		}

		public bool Delete(int id)
		{
			User user = db.Users.Find(id);
			if (user != null)
			{
				db.Users.Remove(user);
				return true;
			}
			else
			{
				return false;
			}
		}

		public User Get(int id)
		{
			return db.Users.Find(id);
		}

		public IEnumerable<User> GetAll()
		{
			return db.Users.ToList();
		}

		public void Update(User item)
		{
			db.Entry(item).State = EntityState.Modified;
		}
	}
}
