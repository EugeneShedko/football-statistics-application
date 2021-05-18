using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Navigation;

namespace WpfApp1.ViewModels.User
{
	class TournamentTableUserViewModel : ViewModelBase, INavigationActions
	{
		#region Удалить
		private ObservableCollection<Team> teams;
		public ObservableCollection<Team> Teams
		{
			get { return teams; }
			set { Set(ref teams, value); }
		}
		public class Team
		{
			public string Position { get; set; } = "1";
			public string TeamName { get; set; } = "Динамо Минск";
			public string CountOfGame { get; set; } = "9";
			public string CountOfWinGame { get; set; } = "6";
			public string CountOfDraws { get; set; } = "2";
			public string CountOfLoses { get; set; } = "1";
			public string CountOfGoalsScored { get; set; } = "16";
			public string CountOfGoalsConseded { get; set; } = "5";
			public string GoalsDifference { get; set; } = "11";
			public string Points { get; set; } = "20";
			public Team() { }
		}
		#endregion
		#region Fields
		private NavigationManager _navigationManager;
		private NavigationManager _smallNavigationManager;
		#region Constructors
		public TournamentTableUserViewModel(NavigationManager smallNaviagtionManager, NavigationManager navigationManager)
		{
			_smallNavigationManager = smallNaviagtionManager;
			_navigationManager = navigationManager;
		}
		public TournamentTableUserViewModel() { }
		#endregion
		#endregion
		#region Methods
		public void ActionsBeforeClosing(){}

		public void ActionsBeforeInsert(object parameters = null)
		{
			Teams = new ObservableCollection<Team>()
			{
				new Team(), new Team(), new Team(), new Team(), new Team(), new Team(), new Team(), new Team(),new Team(), new Team(), new Team(), new Team(), new Team(), new Team(), new Team(), new Team()
			};
		}
		#endregion
	}
}
