using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.UnitOfWorkAndRepository
{
	class CommentRepository : IRepository<Comment>
	{
		private UserContext db;
		public CommentRepository(UserContext context)
		{
			db = context;
		}
		public void Create(Comment item)
		{
			db.Comments.Add(item);
		}

		public void Delete(int id)
		{
			Comment comment = db.Comments.Find(id);
			if (comment != null)
				db.Comments.Remove(comment);
		}

		public Comment Get(int id)
		{
			return db.Comments.Find(id);
		}

		public IEnumerable<Comment> GetAll()
		{
			return db.Comments;
		}

		public void Update(Comment item)
		{
			db.Entry(item).State = EntityState.Modified;
		}
	}
}
