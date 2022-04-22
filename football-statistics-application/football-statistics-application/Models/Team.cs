using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
	public class Team
	{
		//Первичный ключ
		[Required]
		public int Id { get; set; }
		public string TeamName { get; set; }
		public string CountOfGame { get; set; }
		public int CountOfWins { get; set; }
		public int CountOfDraws { get; set; }
		public int CountOfLoses { get; set; }
		public int CountOfScoredGoals { get; set; }
		public int CountOfConsededGoals { get; set; }
		public int GoalsDifference { get; set; }
		public int Points { get; set; }

		public Team(string teamName, string countOfGame, int countOfWins, int countOfDraws, int countOfLoses, int countOfScoredGoals,
			int countOfConsededGoals)
		{
			TeamName = teamName;
			CountOfGame = countOfGame;
			CountOfWins = countOfWins;
			CountOfDraws = countOfDraws;
			CountOfLoses = countOfLoses;
			CountOfScoredGoals = countOfScoredGoals;
			CountOfConsededGoals = countOfConsededGoals;
			GoalsDifference = CountOfScoredGoals - CountOfConsededGoals;
			Points = CountOfWins * 3 + CountOfDraws * 1;
		}
		public Team() { }

		public virtual ICollection<Player> Players { get; set; }
		public virtual ICollection<Game> Games1 { get; set; }
		public virtual ICollection<Game> Games2 { get; set; }
	}
}
