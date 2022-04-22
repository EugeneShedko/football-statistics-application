using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
	public class User
	{
		[Key]
		public string LoginId { get; set; }
		public string Password { get; set; }
		public string FamilyName { get; set; }
		public string Name { get; set; }
		public string Age {get;set;}
		public string DateOfBirthd { get; set; }
		public string Country { get; set; }
		public string Town { get; set; }

		public User(string loginId, string password, string familyName, string name, string age = null, string dataOfBitrh = null,
			 string country = null, string town = null)
		{
			LoginId = loginId;
			Password = password;
			FamilyName = familyName;
			Name = name;
			Age = age;
			DateOfBirthd = dataOfBitrh;
			Country = country;
			Town = town;
		}
		public User() { }
		public virtual ICollection<Comment> Comments { get; set; }
		public virtual ICollection<BookedTicket> BookedTickets { get; set; }
	}
}
