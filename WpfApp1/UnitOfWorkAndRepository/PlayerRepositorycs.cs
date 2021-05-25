using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.UnitOfWorkAndRepository
{
	class PlayerRepositorycs : IRepository<Player>
	{
		private UserContext db;
		public PlayerRepositorycs(UserContext context)
		{
			db = context;
		}
		public void Create(Player item)
		{
			db.Players.Add(item);
		}

		public void Delete(int id)
		{
			Player player = db.Players.Find(id);
			if (player != null)
				db.Players.Remove(player);
		}

		public Player Get(int id)
		{
			return db.Players.Find(id);
		}

		public IEnumerable<Player> GetAll()
		{
			return db.Players;
		}

		public void Update(Player item)
		{
			db.Entry(item).State = EntityState.Modified;
		}
	}
}
