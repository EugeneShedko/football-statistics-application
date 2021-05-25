﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
	class Ticket
	{
		//Первичный клю Id из таблицы Игра
		[Key]
		[ForeignKey("Game")]
		public int Id { get; set; }
		public string Town { get; set; }
		public string Stadium { get; set; }
		public virtual ICollection<BookedTicket> BookedTickets { get; set; }
		public virtual Game Game { get; set; }
	}
}
