using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
	public class Comment
	{
		//Первичный ключ 
		[Required]
		public int Id { get; set; }
		public string CommentDate { get; set; }
		public string CommentText { get; set; }

		//Вторичный ключ к таблицце Пользователь
		public string UserId { get; set; }

		public Comment(string userId, string commentDate, string commentText)
		{
			UserId = userId;
			CommentDate = commentDate;
			CommentText = commentText;
		}
		public Comment() { }

		public virtual User User { get; set; } 
	}
}
