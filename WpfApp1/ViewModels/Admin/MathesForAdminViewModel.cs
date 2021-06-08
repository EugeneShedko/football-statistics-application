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
	class MathesForAdminViewModel : ViewModelBase, INavigationActions, IDataErrorInfo
	{
		#region Fields
		private string _insertDate;
		private string _insertTime;
		private string _insertFirstTeam;
		private string _insertSecondTeam;
		private string _insertFirstTeamGoals;
		private string _insertSecondTeamGoals;
		private string _inserTour;
		private string _deleteTeamId;
		private string _searchTeamId;
		private NavigationManager _navigationManager;
		private NavigationManager _smallNavigationInfoManager;
		private ObservableCollection<Game> _games;
		Dictionary<string, string> errors;
		public string this[string propertyName] => errors.ContainsKey(propertyName) ? errors[propertyName] : null;
		public string Error => throw new NotImplementedException();
		#endregion
		#region Properties
		public string SearchTeamId
		{
			get { return _searchTeamId; }
			set { 
				Set(ref _searchTeamId, value);
				string str = @"[0-9]";
				if (SearchTeamId != null)
				{
					if (!Regex.IsMatch(SearchTeamId, str))
					{
						errors["SearchTeamId"] = "Неверный формат данных, возможны только цифры";
					}
					else
					{
						errors["SearchTeamId"] = null;
					}
				}
			}
		}
		public string DeleteTeamId
		{
			get { return _deleteTeamId; }
			set {
					Set(ref _deleteTeamId, value);
					string str = @"[0-9]";
					if (DeleteTeamId != null)
					{
					if (!Regex.IsMatch(DeleteTeamId, str))
					{
						errors["DeleteTeamId"] = "Неверный формат данных, возможны только цифры";
					}
					else
					{
						errors["DeleteTeamId"] = null;
					}
				}	
			}
		}
		public string InsertTour
		{
			get { return _inserTour; }
			set 
			{ 
				Set(ref _inserTour, value);
				string str = @"[0-9]";
				if (InsertTour != null)
				{
					if (!Regex.IsMatch(InsertTour, str))
					{
						errors["InsertTour"] = "Неверный формат данных, возможны только цифры";
					}
					else
					{
						errors["InsertTour"] = null;
					}
				}
			}
		}
		public string InsertSecondTeamGoals
		{
			get { return _insertSecondTeamGoals; }
			set { 
				Set(ref _insertSecondTeamGoals, value);
				string str = @"[0-9]";
				if (InsertSecondTeamGoals != null)
				{
					if (!Regex.IsMatch(InsertSecondTeamGoals, str))
					{
						errors["InsertSecondTeamGoals"] = "Неверный формат данных, возможны только цифры";
					}
					else
					{
						errors["InsertSecondTeamGoals"] = null;
					}
				}
			}
		}
		public string InsertFirstTeamGoals
		{
			get { return _insertFirstTeamGoals; }
			set
			{
				Set(ref _insertFirstTeamGoals, value);
				string str = @"[0-9]";
				if (InsertFirstTeamGoals != null)
				{
					if (!Regex.IsMatch(InsertFirstTeamGoals, str))
					{
						errors["InsertFirstTeamGoals"] = "Неверный формат данных, возможны только цифры";
					}
					else
					{
						errors["InsertFirstTeamGoals"] = null;
					}
				}
			}
		}
		public string InsertDate
		{
			get { return _insertDate; }
			set 
			{
				Set(ref _insertDate, value);
				string str = @"(0[1-9]|[12][0-9]|3[01])[.](0[1-9]|1[012])[.](20)\d\d";
				if (InsertDate != null)
				{
					if (!Regex.IsMatch(InsertDate, str))
					{
						errors["InsertDate"] = "Неверный формат данных, воозможно dd.mm.yy";
					}
					else
					{
						errors["InsertDate"] = null;
					}
				}
			}
		}
		public string InsertTime
		{
			get { return _insertTime; }
			set
			{
				Set(ref _insertTime, value);
				string str = @"(0[1-9]|1[0-9]|2[0-4])[:](0[1-9]|[012345][0-9])";
				if (InsertTime != null)
				{
					if (!Regex.IsMatch(InsertTime, str))
					{
						errors["InsertTime"] = "Неверный формат данных, воозможно hh.mm";
					}
					else
					{
						errors["InsertTime"] = null;
					}
				}
			}
		}
		public string InsertFirstTeam
		{
			get { return _insertFirstTeam; }
			set { Set(ref _insertFirstTeam, value); }
		}
		public string InsertSecondTeam
		{
			get { return _insertSecondTeam; }
			set { Set(ref _insertSecondTeam, value); }
		}
		public ObservableCollection<string> SelectedTeams { get; set; }
		public ObservableCollection<Game> UserGames
		{
			get { return _games; }
			set { Set(ref _games, value);}
		}
		#endregion
		#region Constructors
		public MathesForAdminViewModel(NavigationManager smallNavigationInfoMnager, NavigationManager navigationManager) : this()
		{
			_navigationManager = navigationManager;
			_smallNavigationInfoManager = smallNavigationInfoMnager;
		}
		public MathesForAdminViewModel() 
		{
			errors = new Dictionary<string, string>();
			errors["SearchTeamId"] = null;
			errors["InsertSecondTeamGoals"] = null;
			errors["InsertFirstTeamGoals"] = null;
			errors["InsertTour"] = null;
			errors["DeleteTeamId"] = null;
			errors["InsertDate"] = null;
			errors["InsertTime"] = null;
			CreateGames = new DelegateCommand(CreateGamesCommand, CanCreateGamesCommand);
			DeleteGames = new DelegateCommand(DeleteGamesCommand, CanDeleteGamesCommamd);
			SearchGames = new DelegateCommand(SearchGamesCommand, CanSearchGamesCommand);
			Back = new DelegateCommand(BackCommand, CanBackCommand);
		}
		#endregion
		#region Commands
		public ICommand CreateGames { get; set; }
		public ICommand DeleteGames { get; set; }
		public ICommand SearchGames { get; set; }
		public ICommand Back { get; set; }

		//---------------------------------------------------------
		public bool CanBackCommand(object parameter)
		{
			return true;
		}
		public void BackCommand(object parameter)
		{
			using (UnitOfWork db = new UnitOfWork())
			{
				UserGames = new ObservableCollection<Game>(db.Games.GetAll().OrderBy(p => p.Id));
			}
		}
		//---------------------------------------------------------
		//----------------------------------------------------------
		public bool CanSearchGamesCommand(object parameter)
		{
			if (errors["SearchTeamId"] == null && SearchTeamId != null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public void SearchGamesCommand(object parameter)
		{
			using (UnitOfWork db = new UnitOfWork())
			{
				Game searchGame = db.Games.GetAll().Where(t=>t.Id == Convert.ToInt32(SearchTeamId)).First();             
				if (searchGame != null)
				{
					UserGames = new ObservableCollection<Game>() { searchGame };
				}
				else
				{
					MessageBox.Show("Не удалось найти матч с указанным Id");
				}
				SearchTeamId = null;
			}
		}
		//----------------------------------------------------------
		//--------------------------------------------------------
		private bool CanDeleteGamesCommamd(object parameters)
		{
			if (errors["DeleteTeamId"] == null && DeleteTeamId != null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		private void DeleteGamesCommand(object parameters)
		{
			using (UnitOfWork db = new UnitOfWork())
			{
				bool isTickets = db.Tickets.GetAll().Any(t => t.Id == Convert.ToInt32(DeleteTeamId));
				if (isTickets == true)
				{
					if (db.Tickets.Delete(Convert.ToInt32(DeleteTeamId)))
					{
						if (db.Games.Delete(Convert.ToInt32(DeleteTeamId)))
						{
							db.Save();
							UserGames = new ObservableCollection<Game>(db.Games.GetAll().OrderBy(p => Convert.ToInt32(p.Tour.Substring(4))));
							MessageBox.Show("Данные успешно удалены!");
						}
						else
						{
							MessageBox.Show("Не удалось найти матч с указанным Id");
						}
						DeleteTeamId = null;
					}
				}
				else
				{
					if (db.Games.Delete(Convert.ToInt32(DeleteTeamId)))
					{
						db.Save();
						UserGames = new ObservableCollection<Game>(db.Games.GetAll().OrderBy(p => Convert.ToInt32(p.Tour.Substring(4))));
						MessageBox.Show("Данные успешно удалены!");
					}
					else
					{
						MessageBox.Show("Не удалось найти матч с указанным Id");
					}
					DeleteTeamId = null;
				}
			}
		}
		//--------------------------------------------------------
		private bool CanCreateGamesCommand(object parameter)
		{
			if ((errors["InsertDate"] == null && InsertDate != null) &&
				(errors["InsertTime"] == null && InsertTime != null) &&
				(errors["InsertSecondTeamGoals"] == null ) &&
				(errors["InsertFirstTeamGoals"] == null ) &&
				(errors["InsertTour"] == null && InsertTour != null) &&
				(InsertFirstTeam !=null) &&
				(InsertSecondTeam !=null))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		private void CreateGamesCommand(object parameter)
		{
			using (UnitOfWork db = new UnitOfWork())
			{
				try
				{
					int id1 = db.Teams.GetAll().Where(t => t.TeamName == InsertFirstTeam).Select(p => p.Id).First();
					int id2 = db.Teams.GetAll().Where(t => t.TeamName == InsertSecondTeam).Select(p => p.Id).First();
					Game newGame = new Game(id1, id2, InsertDate + ' ' + InsertTime, InsertFirstTeamGoals, InsertSecondTeamGoals, "Тур " + InsertTour);
					db.Games.Create(newGame);
					db.Save();
					UserGames = new ObservableCollection<Game>(db.Games.GetAll().OrderBy(p => Convert.ToInt32(p.Tour.Substring(4))));
					MessageBox.Show("Новый матч добавлен!");
					InsertDate = null;
					InsertFirstTeam = null;
					InsertSecondTeam = null;
					InsertFirstTeamGoals = null;
					InsertSecondTeamGoals = null;
					InsertTour = null;
					InsertTime = null;
				}
				catch { }
			}
		}
		#endregion
		#region Methods
		public void ActionsBeforeClosing(){}

		public void ActionsBeforeInsert(object parameters = null)
		{
			using (UnitOfWork db = new UnitOfWork())
			{
				UserGames = new ObservableCollection<Game>(db.Games.GetAll().OrderBy(p => Convert.ToInt32(p.Tour.Substring(4))));
				SelectedTeams = new ObservableCollection<string>(db.Teams.GetAll().Select(t => t.TeamName));
			}
		}
		#endregion
	}
}
