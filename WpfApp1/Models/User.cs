using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
	class User
	{
		[Required]
		public int Id { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public string FamilyName { get; set; }
		public string Name { get; set; }
		public string Age {get;set;}
		public string DateOfBirthd { get; set; }
		public string Email { get; set; }
		public string Country { get; set; }
		public string Town { get; set; }
		public virtual ICollection<Comment> Comments { get; set; }
		public virtual ICollection<BookedTicket> BookedTickets { get; set; }
	}
}
