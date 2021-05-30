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
	class TournamentTableUserViewModel : ViewModelBase, INavigationActions
	{
		#region Fields
		private NavigationManager _navigationManager;
		private NavigationManager _smallNavigationManager;
		#endregion
		#region Properties
		public ObservableCollection<Team> Teams { get; set; }
		public ObservableCollection<int> Number { get; set; }
		#endregion
		#region Constructors
		public TournamentTableUserViewModel(NavigationManager smallNaviagtionManager, NavigationManager navigationManager) : this()
		{
			_smallNavigationManager = smallNaviagtionManager;
			_navigationManager = navigationManager;
		}
		public TournamentTableUserViewModel(){}
		#endregion
		#region Methods
		public void ActionsBeforeClosing(){}

		public void ActionsBeforeInsert(object parameters = null)
		{
			Number = new ObservableCollection<int>();
			using (UnitOfWork db = new UnitOfWork())
			{
				Teams = new ObservableCollection<Team>(db.Teams.GetAll().OrderByDescending(p => p.Points));
			}
			for (int i = 0; i < Teams.Count; i++)
			{
				Number.Add(i);
			}
		}
		#endregion
	}
}
