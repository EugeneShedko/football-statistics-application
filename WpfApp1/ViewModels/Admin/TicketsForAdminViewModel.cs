using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Models;
using WpfApp1.Navigation;
using WpfApp1.UnitOfWorkAndRepository;

namespace WpfApp1.ViewModels.Admin
{
	class TicketsForAdminViewModel : ViewModelBase, INavigationActions, IDataErrorInfo
	{
		#region Fields
		private NavigationManager _navigationManager;
		private NavigationManager _smallNaviagtionInfoManager;
		private ObservableCollection<Ticket> _tickets;
		private string _insertFirstTeamName;
		private string _insertSecondTeamName;
		private string _insertTown;
		private string _insertStadium;
		private string _insertTime;
		private string _searchTicketId;
		private string _deleteTicketId;
		private string _countOfPlace;
		private string _mistake;
		public ObservableCollection<string> _time;

		Dictionary<string, string> errors;
		public string this[string propertyName] => errors.ContainsKey(propertyName) ? errors[propertyName] : null;
		public string Error => throw new NotImplementedException();

		#endregion
		#region Properties
		public string CountOfPlace
		{
			get { return _countOfPlace; }
			set 
			{ 
				Set(ref _countOfPlace, value);
				string str = @"[0-9]";
				if (CountOfPlace != null)
				{
					if (!Regex.IsMatch(CountOfPlace, str))
					{
						errors["CountOfPlace"] = "Неверный формат данных, возможны только цифры";
					}
					else
					{
						errors["CountOfPlace"] = null;
					}
				}
			}
		}
		public string Mistake
		{
			get { return _mistake; }
			set { Set(ref _mistake, value); }
		}
		public string InsertTime
		{
			get { return _insertTime; }
			set 
			{
				Set(ref _insertTime, value); 
			}
		}
		public string DeleteTicketId
		{
			get { return _deleteTicketId; }
			set
			{
				Set(ref _deleteTicketId, value);
				string str = @"[0-9]";
				if (DeleteTicketId != null)
				{
					if (!Regex.IsMatch(DeleteTicketId, str))
					{
						errors["DeleteTicketId"] = "Неверный формат данных, возможны только цифры";
					}
					else
					{
						errors["DeleteTicketId"] = null;
					}
				}
			}
		}
		public string InsertTown
		{
			get { return _insertTown; }
			set 
			{ 
				Set(ref _insertTown, value);
				string str = @"^[А-Яа-я]+|[А-Яа-я]+[' '][А-Яа-я]+ $";
				if (InsertTown != null)
				{
					if (!Regex.IsMatch(InsertTown, str))
					{
						errors["InsertTown"] = "Неверный формат данных";
					}
					else
					{
						errors["InsertTown"] = null;
					}
				}
			}
		}
		public string InsertStadium
		{
			get { return _insertStadium; }
			set 
			{
				Set(ref _insertStadium, value);
				string str = @"^[А-Яа-я]+|[А-Яа-я]+[' '][А-Яа-я]+ $";
				if (InsertStadium != null)
				{
					if (!Regex.IsMatch(InsertStadium, str))
					{
						errors["InsertStadium"] = "Неверный формат данных";
					}
					else
					{
						errors["InsertStadium"] = null;
					}
				}
			}
		}
		public string InsertFirstTeamName
		{
			get { return _insertFirstTeamName; }
			set 
			{
				Mistake = null;
				Set(ref _insertFirstTeamName, value);
				using (UnitOfWork db = new UnitOfWork())
				{
					Time = new ObservableCollection<string>(db.Games.GetAll().Where(t=>t.Team1.TeamName == InsertFirstTeamName && t.Team2.TeamName == InsertSecondTeamName).Select(t=>t.DateOfMatch));
				}
			}
		}
		public string InsertSecondTeamName
		{
			get { return _insertSecondTeamName; }
			set 
			{
				Mistake = null;
				Set(ref _insertSecondTeamName, value);
				using (UnitOfWork db = new UnitOfWork())
				{
					Time = new ObservableCollection<string>(db.Games.GetAll().Where(t => t.Team1.TeamName == InsertFirstTeamName && t.Team2.TeamName == InsertSecondTeamName).Select(t => t.DateOfMatch));
				}
				if (Time.Count == 0 && InsertFirstTeamName!= null && InsertSecondTeamName != null)
				{
					Mistake = "Такого матча нет";
				}
			}
		}
		public string SearchTicketId
		{
			get { return _searchTicketId; }
			set
			{
				Set(ref _searchTicketId, value);
				string str = @"[0-9]";
				if (SearchTicketId != null)
				{
					if (!Regex.IsMatch(SearchTicketId, str))
					{
						errors["SearchTicketId"] = "Неверный формат данных, возможны только цифры";
					}
					else
					{
						errors["SearchTicketId"] = null;
					}
				}
			}
		}
		public ObservableCollection<Ticket> UserTickets
		{
			get { return _tickets; }
			set { Set(ref _tickets, value); }
		}
		public ObservableCollection<string> SelectedTeams { get; set; }
		public ObservableCollection<string> Time
		{
			get { return _time; }
			set { Set(ref _time, value); }
		}
		#endregion
		#region Constructors
		public TicketsForAdminViewModel(NavigationManager smallNavigationInfoManager, NavigationManager navigationManager) : this()
		{
			_navigationManager = navigationManager;
			_smallNaviagtionInfoManager = smallNavigationInfoManager;
		}
		public TicketsForAdminViewModel()
		{
			errors = new Dictionary<string, string>();
			errors["SearchTicketId"] = null;
			errors["InsertStadium"] = null;
			errors["InsertTown"] = null;
			errors["DeleteTicketId"] = null;
			errors["CountOfPlace"] = null;
			SearchTicket = new DelegateCommand(SearchTicketCommand, CanSearchTicketCommand);
			Back = new DelegateCommand(BackCommand, CanBackCommand);
			CreateTicket = new DelegateCommand(CreateTicketCommand, CanCreateTicketCommand);
			DeleteTicket = new DelegateCommand(DeleteTicketCommand, CanDeleteTicketCommamd);
		}
		#endregion

		#region Commands
		public ICommand SearchTicket { get; set; }
		public ICommand Back { get; set; }
		public ICommand CreateTicket { get; set; }
		public ICommand DeleteTicket { get; set; }
		//-------------------------------------------------------------------------
		private bool CanDeleteTicketCommamd(object parameters)
		{
			if (errors["DeleteTicketId"] == null && DeleteTicketId != null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		private void DeleteTicketCommand(object parameters)
		{
			using (UnitOfWork db = new UnitOfWork())
			{
				if (db.Tickets.Delete(Convert.ToInt32(DeleteTicketId)))
				{
					db.Save();
					UserTickets = new ObservableCollection<Ticket>(db.Tickets.GetAll());
					MessageBox.Show("Данные успешно удалены!");
				}
				else
				{
					MessageBox.Show("Не удалось найти билет с указанным Id");
				}
				DeleteTicketId = null;
			}
		}
		//-------------------------------------------------------------------------
		//-------------------------------------------------------------------------
		private bool CanCreateTicketCommand(object parameter)
		{
			if ((errors["InsertStadium"] == null && InsertStadium != null) && 
				(errors["InsertTown"] == null && InsertTown != null) &&
				(InsertFirstTeamName != null && InsertSecondTeamName != null && InsertTime != null))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		private void CreateTicketCommand(object parameter)
		{
			using (UnitOfWork db = new UnitOfWork())
			{
				try
				{
					bool isGame = db.Games.GetAll().Any(t => t.Team1.TeamName == InsertFirstTeamName && t.Team2.TeamName == InsertSecondTeamName);
					if (isGame == true)
					{
						IEnumerable<Game> allid = db.Games.GetAll().Where(t => t.Team1.TeamName == InsertFirstTeamName && t.Team2.TeamName == InsertSecondTeamName);
						int id = allid.Where(t => t.DateOfMatch == InsertTime).Select(t => t.Id).First();
						//Поменять немного класс и конструктор
						Ticket newTicket = new Ticket(id, InsertTown, InsertStadium, Convert.ToInt32(CountOfPlace));
						db.Tickets.Create(newTicket);
						db.Save();
						UserTickets = new ObservableCollection<Ticket>(db.Tickets.GetAll().OrderByDescending(t => t.Id));
						MessageBox.Show("Билет создан!");
					}
					else
					{
						MessageBox.Show("Не удалось найти матч с указанными командами");
					}
					InsertFirstTeamName = null;
					InsertSecondTeamName = null;
					InsertStadium = null;
					InsertTown = null;
					CountOfPlace = null;
				}
				catch { }
			}
		}
		//-------------------------------------------------------------------------
		//-------------------------------------------------------------------------
		public bool CanBackCommand(object parameter)
		{
			return true;
		}
		public void BackCommand(object parameter)
		{
			using (UnitOfWork db = new UnitOfWork())
			{
				UserTickets = new ObservableCollection<Ticket>(db.Tickets.GetAll().OrderByDescending(p => p.Id));
			}
		}
		//-------------------------------------------------------------------------
		//-------------------------------------------------------------------------
		public bool CanSearchTicketCommand(object parameter)
		{
			if (errors["SearchTicketId"] == null && SearchTicketId != null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public void SearchTicketCommand(object parameter)
		{
			using (UnitOfWork db = new UnitOfWork())
			{
				Ticket searchTicket = db.Tickets.GetAll().Where(t => t.Id == Convert.ToInt32(SearchTicketId)).First();
				if (searchTicket != null)
				{
					UserTickets = new ObservableCollection<Ticket>() { searchTicket };
				}
				else
				{
					MessageBox.Show("Не удалось новость с указанным Id");
				}
				SearchTicketId = null;
			}
		}
		//-------------------------------------------------------------------------
		#endregion

		#region Methods
		public void ActionsBeforeClosing(){}

		public void ActionsBeforeInsert(object parameters = null)
		{
			using (UnitOfWork db = new UnitOfWork())
			{
				UserTickets = new ObservableCollection<Ticket>(db.Tickets.GetAll().OrderByDescending(t=>t.Id));
				SelectedTeams = new ObservableCollection<string>(db.Teams.GetAll().Select(t => t.TeamName));
			}
		}
		#endregion
	}
}
