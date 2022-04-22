using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.UnitOfWorkAndRepository
{
	class GoalRepositorycs : IRepository<Goal>
	{
		private UserContext db;
		public GoalRepositorycs(UserContext context)
		{
			db = context;
		}
		public void Create(Goal item)
		{
			db.Goals.Add(item);
		}

		public bool Delete(int id)
		{
			Goal goal = db.Goals.Find(id);
			if (goal != null)
			{
				db.Goals.Remove(goal);
				return true;
			}
			else
			{
				return false;
			}
		}

		public Goal Get(int id)
		{
			return db.Goals.Find(id);
		}

		public IEnumerable<Goal> GetAll()
		{
			return db.Goals.Include(t=>t.Player).Include(t=>t.Player.Team).ToList();
		}

		public void Update(Goal item)
		{
			db.Entry(item).State = EntityState.Modified;
		}
	}
}
