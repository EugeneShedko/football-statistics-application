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
		private string _selectedPlace;
		private ObservableCollection<string> _matches;
		private ObservableCollection<int> _freePlaces;
		#endregion
		#region Properties
		public ObservableCollection<int> FreePlaces
		{
			get { return _freePlaces; }
			set { Set(ref _freePlaces, value); }
		}
		public string SelectedPlace
		{
			get { return _selectedPlace; }
			set { Set(ref _selectedPlace, value); }
		}
		public string SelectedMatch
		{
			get { return _selectedMatch; }
			set 
			{
				Set(ref _selectedMatch, value);
				if (SelectedMatch != null)
				{
					FreePlacesForMatch();
				}
			}
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
				BookedTicket orderTicket = new BookedTicket(currentUser, id, "Обрабатывается", SelectedPlace);
				db.BookedTickets.Create(orderTicket);
				db.Save();
				MessageBox.Show("Ваш билет заказан!");
			}
			SelectedMatch = null;
			SelectedPlace = null;
			FreePlaces.Clear();
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
		private void FreePlacesForMatch()
		{
			using (UnitOfWork db = new UnitOfWork())
			{
				FreePlaces = new ObservableCollection<int>();
				//Находим билет, который создал админ
				int id = db.Tickets.GetAll().Where(t => t.Game.Team1.TeamName + " - " + t.Game.Team2.TeamName == SelectedMatch).Select(t => t.Id).First();
				//Затем узнаем количество мест в этом билете
				int countOfPlace = db.Tickets.GetAll().Where(t => t.Id == id).Select(t => t.CountOfPlace).First();
				//Затем создаю коллецию размером с количеством мест в билете, созданным администартором
				for (int i = 1; i <= countOfPlace; i++)
				{
					FreePlaces.Add(i);
				}
				//Затем получаем все заказанные места из заказанных билетов, которые соответсвуют выбраному типу
				IEnumerable<string> occupiedPlaces = db.BookedTickets.GetAll().Where(t => t.TicketId == id).Select(t => t.Place);
				//Затем удаляю из созданной коллекции все заказанные места, тем самым получаю все свободные
				for (int i = 0; i < occupiedPlaces.ToList().Count; i++)
				{
					FreePlaces.Remove(Convert.ToInt32(occupiedPlaces.ToList()[i]));
				}
			}
		}
		#endregion
	}
}
