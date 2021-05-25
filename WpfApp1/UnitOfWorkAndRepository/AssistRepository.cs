using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.UnitOfWorkAndRepository
{
	class AssistRepository : IRepository<Assist>
	{
		private UserContext db;
		public AssistRepository(UserContext context)
		{
			this.db = context;
		}
		public IEnumerable<Assist> GetAll()
		{
			return db.Assists;
		}
		public Assist Get(int id)
		{
			return db.Assists.Find(id);
		}
		public void Create(Assist assist)
		{
			db.Assists.Add(assist);
		}
		public void Update(Assist assist)
		{
			db.Entry(assist).State = EntityState.Modified;
		}
		public void Delete(int id)
		{
			Assist assist = db.Assists.Find(id);
			if (assist != null)
				db.Assists.Remove(assist);
		}
	}
}
