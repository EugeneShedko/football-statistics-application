using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
	public class Game
	{
		//Первичный ключ
		[Required]
		public int Id { get; set; }
		public string DateOfMatch { get; set; }
		public string FirstTeamCountOfGoals { get; set; }
		public string SecondTeamCountOfGoals { get; set; }
		public string Tour { get; set; }
		
		//2 вторичных ключа к таблице Team
		public int TeamId1 { get; set; }
		public int TeamId2 { get; set; }
		//навигационные свойства
		public virtual Team Team1 { get; set; }
		public virtual Team Team2 { get; set; }

		public virtual Ticket Ticket { get; set; }

	}
}
