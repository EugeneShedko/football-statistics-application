using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
	public class Ticket
	{
		//Первичный клю Id из таблицы Игра
		[Key]
		[ForeignKey("Game")]
		public int Id { get; set; }
		public string Town { get; set; }
		public string Stadium { get; set; }
		
		public int CountOfPlace { get; set; }
		public int GameId { get; set; }

		public Ticket(int id, string town, string stadium, int countOfPlace)
		{
			Id = id;
			Town = town;
			Stadium = stadium;
			CountOfPlace = countOfPlace;
		}
		public Ticket() { }

		public virtual ICollection<BookedTicket> BookedTickets { get; set; }
		public virtual Game Game { get; set; }
	}
}
