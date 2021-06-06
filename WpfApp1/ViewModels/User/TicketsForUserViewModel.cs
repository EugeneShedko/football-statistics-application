using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Models;
using WpfApp1.Navigation;
using WpfApp1.UnitOfWorkAndRepository;

namespace WpfApp1.ViewModels.User
{
	class TicketsForUserViewModel : ViewModelBase, INavigationActions
	{
		#region Fields
		private NavigationManager _navigationManager;
		private NavigationManager _smallNavigationInfoManager;
		private string currentUser;
		private string _selectedMatch;
		private ObservableCollection<string> _matches;
		#endregion
		#region Properties
		public string SelectedMatch
		{
			get { return _selectedMatch; }
			set { Set(ref _selectedMatch, value); }
		}
		public ObservableCollection<string> Matches
		{
			get { return _matches; }
			set { Set(ref _matches, value); }
		}
		#endregion
		#region Constructors
		public TicketsForUserViewModel(NavigationManager smallNavigationManager, NavigationManager navigationManager) : this()
		{
			_smallNavigationInfoManager = smallNavigationManager;
			_navigationManager = navigationManager;
		}
		public TicketsForUserViewModel() 
		{
			CreateOrder = new DelegateCommand(CreateOrderCommand, CanCreateOrderCommand);
		}
		#endregion
		#region Commands
		public ICommand CreateOrder { get; set; }
		private bool CanCreateOrderCommand(object parameters)
		{
			if (SelectedMatch != null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		private void CreateOrderCommand(object parameters)
		{
			using (UnitOfWork db = new UnitOfWork())
			{
				int id = db.Tickets.GetAll().Where(t => t.Game.Team1.TeamName + " - " + t.Game.Team2.TeamName == SelectedMatch).Select(t=>t.Id).First();
				BookedTicket orderTicket = new BookedTicket(currentUser, id, "Обрабатывается" );
				db.BookedTickets.Create(orderTicket);
				db.Save();
				MessageBox.Show("Ваш билет заказан!");
			}
		}
		#endregion
		#region Methods
		public void ActionsBeforeClosing(){}

		public void ActionsBeforeInsert(object parameters = null)
		{
			currentUser = (string)parameters;
			using (UnitOfWork db = new UnitOfWork())
			{
				Matches = new ObservableCollection<string>(db.Tickets.GetAll().Select(t=>t.Game.Team1.TeamName + " - " + t.Game.Team2.TeamName));
			}

		}
		#endregion
	}
}
