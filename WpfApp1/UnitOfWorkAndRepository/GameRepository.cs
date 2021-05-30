using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

		public void Delete(int id)
		{
			Game game = db.Games.Find(id);
			if (game != null)
				db.Games.Remove(game);
		}

		public Game Get(int id)
		{
			return db.Games.Find(id);
		}

		public IEnumerable<Game> GetAll()
		{
			return db.Games.Include(t => t.Team1).Include(p => p.Team2).ToList();
		}

		public void Update(Game item)
		{
			db.Entry(item).State = EntityState.Modified; ;
		}
	}
}
