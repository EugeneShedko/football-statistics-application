using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
	public class Player
	{
		[Required]
		public int Id { get; set; }
		public string PlayerName { get; set; }
		
		//Вторичный ключ к таблице Команда
		public int TeamId { get; set; }

		public Player(string playerName, int teamId)
		{
			PlayerName = playerName;
			TeamId = teamId;
		}
		public Player() { }

		public virtual Team Team { get; set; }
		public virtual Goal Goal { get; set; }
		public virtual Assist Assist { get; set; }
	}
}
