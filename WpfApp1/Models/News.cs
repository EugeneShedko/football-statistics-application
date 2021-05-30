using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
	public class News
	{
		//Первичный ключ
		[Required]
		public int Id { get; set; }
		public string Header { get; set; }
		public string NewsText { get; set; }
	}
}
