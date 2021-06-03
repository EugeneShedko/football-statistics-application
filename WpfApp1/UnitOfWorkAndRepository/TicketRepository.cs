using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.UnitOfWorkAndRepository
{
	class TicketRepository : IRepository<Ticket>
	{
		private UserContext db;
		public TicketRepository(UserContext context)
		{
			db = context;
		}
		public void Create(Ticket item)
		{
			db.Tickets.Add(item);
		}

		public bool Delete(int id)
		{
			Ticket ticket = db.Tickets.Find(id);
			if (ticket != null)
			{
				db.Tickets.Remove(ticket);
				return true;
			}
			else
			{
				return false;
			}
		}

		public Ticket Get(int id)
		{
			return db.Tickets.Find(id);
		}

		public IEnumerable<Ticket> GetAll()
		{
			return db.Tickets.ToList();
		}

		public void Update(Ticket item)
		{
			db.Entry(item).State = EntityState.Modified;
		}
	}
}
