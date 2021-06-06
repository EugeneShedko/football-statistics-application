using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WpfApp1.Models
{
	public class UserContext : DbContext
	{
		public UserContext() : base("DbConnection")
		{ }
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Team>().HasMany(t => t.Games1).WithRequired(g => g.Team1).HasForeignKey(s => s.TeamId1);
			modelBuilder.Entity<Team>().HasMany(t => t.Games2).WithRequired(g => g.Team2).HasForeignKey(s => s.TeamId2).WillCascadeOnDelete(false);
			modelBuilder.Entity<User>().HasMany(t => t.Comments).WithRequired(g => g.User).HasForeignKey(s => s.UserId);
		}
		public DbSet<User> Users { get; set; }
		public DbSet<Team> Teams { get; set; }
		public DbSet<Game> Games { get; set; }
		public DbSet<Player> Players { get; set; }
		public DbSet<Goal> Goals { get; set; }
		public DbSet<Assist> Assists { get; set; }
		public DbSet<Ticket> Tickets { get; set; }
		public DbSet<BookedTicket> BookedTickets { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<News> Newses { get; set; }
	}
}
