using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.UnitOfWorkAndRepository
{
	class TeamRepository : IRepository<Team>
	{
		private UserContext db;
		public TeamRepository(UserContext context)
		{
			db = context;
		}
		public  IEnumerable<Team> GetAll()
		{

			return db.Teams.ToList();
		}

		public Team Get(int id)
		{
			return db.Teams.Find(id);
		}

		public void Create(Team item)
		{
			db.Teams.Add(item);
		}

		public void Update(Team item)
		{
			db.Entry(item).State = EntityState.Modified;
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}
	}
}
