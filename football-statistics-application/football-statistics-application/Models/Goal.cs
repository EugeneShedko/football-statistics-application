using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
	public class Goal
	{
		//Первичный ключ id игрока из таблицы Игрок
		[Key]
		[ForeignKey("Player")]
		public int Id { get; set; }
		public string CountOfGoals { get; set; }
		public Goal(int id, string countOfGoals)
		{
			Id = id;
			CountOfGoals = countOfGoals;
		}
		public Goal() { }
		public virtual Player Player { get; set; }
	}
}
