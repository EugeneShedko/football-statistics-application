using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
	public class BookedTicket
	{
		//Первичный ключ 
		[Required]
		public int Id { get; set; }
		//Вторичный ключ к таблице Пользователь
		public string UserId { get; set; }
		//Вторичный ключ к таблице Билеты
		public int TicketId { get; set; }
		public string Status { get; set; }

		public BookedTicket(string userId, int ticketId, string status)
		{
			UserId = userId;
			TicketId = ticketId;
			Status = status;
		}
		public BookedTicket() { }
		public virtual Ticket Ticket { get; set; }
		public virtual User User { get; set; }
	}
}
