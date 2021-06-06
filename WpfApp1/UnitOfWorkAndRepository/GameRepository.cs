using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Models;

namespace WpfApp1.UnitOfWorkAndRepository
{
	class GameRepository : IRepository<Game>
	{
		private UserContext db;
		public GameRepository(UserContext context)
		{
			db = context;
		}
		public void Create(Game item)
		{
			db.Games.Add(item);
		}

		public bool Delete(int id)
		{
			Game game = db.Games.Find(id);
			if (game != null)
			{
				db.Games.Remove(game);
				return true;
			}
			else
			{
				return false;
			}
		}

		public Game Get(int id)
		{
			return db.Games.Find(id);
		}

		public IEnumerable<Game> GetAll()
		{
			return db.Games.Include(p => p.Team1).Include(p => p.Team2).ToList();
		}

		public void Update(Game item)
		{
			db.Entry(item).State = EntityState.Modified;
		}
	}
}
