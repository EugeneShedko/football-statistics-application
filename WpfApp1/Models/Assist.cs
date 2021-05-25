using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
	class Assist
	{
		//Первичный ключ id игрока из таблицы Игрок
		[Key]
		[ForeignKey("Player")]
		public int Id { get; set; }
		public string CountOfAssists { get; set; }
		public virtual Player Player { get; set; }
	}
}
