using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.UnitOfWorkAndRepository
{
	class NewsRepository : IRepository<News>
	{
		private UserContext db;
		public NewsRepository(UserContext context)
		{
			db = context;
		}
		public void Create(News item)
		{
			db.Newses.Add(item);
		}

		public void Delete(int id)
		{
			News news = db.Newses.Find(id);
			if (news != null)
				db.Newses.Remove(news);
		}

		public News Get(int id)
		{
			return db.Newses.Find(id);
		}

		public IEnumerable<News> GetAll()
		{
			return db.Newses.ToList();
		}

		public void Update(News item)
		{
			db.Entry(item).State = EntityState.Modified;
		}
	}
}
