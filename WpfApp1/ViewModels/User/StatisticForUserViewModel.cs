using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;
using WpfApp1.Navigation;
using WpfApp1.UnitOfWorkAndRepository;

namespace WpfApp1.ViewModels.User
{
	class StatisticForUserViewModel : ViewModelBase, INavigationActions
	{
		#region Fields
		private NavigationManager _navigationManager;
		private NavigationManager _smallNavigationInfoManager;
		#endregion
		#region Properties
		public ObservableCollection<Goal> GoalsPlayers { get; set; }
		public ObservableCollection<Assist> AssistsPlayers { get; set; }
		#endregion
		#region Constructors
		public StatisticForUserViewModel(NavigationManager smallNavigationManager, NavigationManager navigationManager)
		{
			_smallNavigationInfoManager = smallNavigationManager;
			_navigationManager = navigationManager;
		}
		public StatisticForUserViewModel() { }
		#endregion
		#region Methods
		public void ActionsBeforeClosing() {}

		public void ActionsBeforeInsert(object parameters = null)
		{
			using (UnitOfWork db = new UnitOfWork())
			{
				GoalsPlayers = new ObservableCollection<Goal>(db.Goals.GetAll().OrderBy(t => t.Player.Team.TeamName).OrderByDescending(t =>Convert.ToInt32(t.CountOfGoals)));
				AssistsPlayers = new ObservableCollection<Assist>(db.Assists.GetAll().OrderBy(t => t.Player.Team.TeamName).OrderByDescending(t => Convert.ToInt32(t.CountOfAssists)));
			}
		}
		#endregion
}
}
