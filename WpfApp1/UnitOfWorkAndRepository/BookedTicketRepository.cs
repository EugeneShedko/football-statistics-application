using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.UnitOfWorkAndRepository
{
	class BookedTicketRepository : IRepository<BookedTicket>
	{
		private UserContext db;
		public BookedTicketRepository(UserContext context)
		{
			db = context;
		}
		public void Create(BookedTicket item)
		{
			db.BookedTickets.Add(item);
		}

		public void Delete(int id)
		{
			BookedTicket bookedTicket = db.BookedTickets.Find(id);
			if (bookedTicket != null)
				db.BookedTickets.Remove(bookedTicket);
		}

		public BookedTicket Get(int id)
		{
			return db.BookedTickets.Find(id);
		}

		public IEnumerable<BookedTicket> GetAll()
		{
			return db.BookedTickets;
		}

		public void Update(BookedTicket item)
		{
			db.Entry(item).State = EntityState.Modified;          //?????????????
		}
	}
}
