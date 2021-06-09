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
	class StatisticForAdminViewModel : ViewModelBase, INavigationActions, IDataErrorInfo
	{
		#region Fields
		private NavigationManager _navigationManager;
		private NavigationManager _smallNavigationInfoManager;
		private ObservableCollection<Goal> _goalsPlayer;
		private ObservableCollection<Assist> _assistsPlayer;
		private string _searchGoalsPlayerId;
		private string _searchAssistsPlayerId;
		private string _insertPlayerNameGoals;
		private string _insertTeamNameGoals;
		private string _insertCountOfGoals;
		private string _insertPlayerNameAssists;
		private string _insertTeamNameAssists;
		private string _insertCountOfAssists;
		private string _deletePlayersIdGoals;
		private string _deletePlayersIdAssists;

		Dictionary<string, string> errors;
		public string this[string propertyName] => errors.ContainsKey(propertyName) ? errors[propertyName] : null;
		public string Error => throw new NotImplementedException();

		#endregion
		#region Properties
		public string DeletePlayersIdAssists
		{
			get { return _deletePlayersIdAssists; }
			set
			{
				Set(ref _deletePlayersIdAssists, value);
				string str = @"[0-9]";
				if (DeletePlayersIdAssists != null)
				{
					if (!Regex.IsMatch(DeletePlayersIdAssists, str))
					{
						errors["DeletePlayersIdAssists"] = "Неверный формат данных, возможны только цифры";
					}
					else
					{
						errors["DeletePlayersIdAssists"] = null;
					}
				}
			}
		}
		public string DeletePlayersIdGoals
		{
			get { return _deletePlayersIdGoals; }
			set 
			{
				Set(ref _deletePlayersIdGoals, value);
				string str = @"[0-9]";
				if (DeletePlayersIdGoals != null)
				{
					if (!Regex.IsMatch(DeletePlayersIdGoals, str))
					{
						errors["DeletePlayersIdGoals"] = "Неверный формат данных, возможны только цифры";
					}
					else
					{
						errors["DeletePlayersIdGoals"] = null;
					}
				}
			}
		}
		public string InsertCountOfAssists
		{
			get { return _insertCountOfAssists; }
			set
			{
				Set(ref _insertCountOfAssists, value);
				string str = @"[0-9]";
				if (InsertCountOfAssists != null)
				{
					if (!Regex.IsMatch(InsertCountOfAssists, str))
					{
						errors["InsertCountOfAssists"] = "Неверный формат данных, возможны только цифры";
					}
					else
					{
						errors["InsertCountOfAssists"] = null;
					}
				}
			}
		}
		public string InsertTeamNameAssists
		{
			get { return _insertTeamNameAssists; }
			set { Set(ref _insertTeamNameAssists, value); }
		}
		public string InsertPlayerNameAssists
		{
			get { return _insertPlayerNameAssists; }
			set
			{
				Set(ref _insertPlayerNameAssists, value);
				string str = @"^[А-Яа-я0-9]+|[А-Яа-я0-9]+[' '][А-Яа-я0-9]+ $";
				if (InsertPlayerNameAssists != null)
				{
					if (!Regex.IsMatch(InsertPlayerNameAssists, str))
					{
						errors["InsertPlayerNameAssists"] = "Неверный формат данных, возможны только буквы";
					}
					else
					{
						errors["InsertPlayerNameAssists"] = null;
					}
				}

			}
		}
		public string InsertCountOfGoals
		{
			get { return _insertCountOfGoals; }
			set 
			{
				Set(ref _insertCountOfGoals,value);
				string str = @"[0-9]";
				if (InsertCountOfGoals != null)
				{
					if (!Regex.IsMatch(InsertCountOfGoals, str))
					{
						errors["InsertCountOfGoals"] = "Неверный формат данных, возможны только цифры";
					}
					else
					{
						errors["InsertCountOfGoals"] = null;
					}
				}
			}
		}
		public string InsertTeamNameGoals
		{
			get { return _insertTeamNameGoals; }
			set { Set(ref _insertTeamNameGoals, value); }
		}
		public string InsertPlayerNameGoals
		{
			get { return _insertPlayerNameGoals; }
			set
			{
				Set(ref _insertPlayerNameGoals, value);
				string str = @"^[А-Яа-я0-9]+|[А-Яа-я0-9]+[' '][А-Яа-я0-9]+ $";
				if (InsertPlayerNameGoals != null)
				{
					if (!Regex.IsMatch(InsertPlayerNameGoals, str))
					{
						errors["InsertPlayerNameGoals"] = "Неверный формат данных, возможны только буквы";
					}
					else
					{
						errors["InsertPlayerNameGoals"] = null;
					}
				}

			}
		}
		public string SearchAssistsPlayerId
		{
			get { return _searchAssistsPlayerId; }
			set
			{
				Set(ref _searchAssistsPlayerId, value);
				string str = @"[0-9]";
				if (SearchAssistsPlayerId != null)
				{
					if (!Regex.IsMatch(SearchAssistsPlayerId, str))
					{
						errors["SearchAssistsPlayerId"] = "Неверный формат данных, возможны только цифры";
					}
					else
					{
						errors["SearchAssistsPlayerId"] = null;
					}
				}
			}
		}
		public string SearchGoalsPlayerId
		{
			get { return _searchGoalsPlayerId; }
			set
			{
				Set(ref _searchGoalsPlayerId, value);
				string str = @"[0-9]";
				if (SearchGoalsPlayerId != null)
				{
					if (!Regex.IsMatch(SearchGoalsPlayerId, str))
					{
						errors["SearchGoalsPlayerId"] = "Неверный формат данных, возможны только цифры";
					}
					else
					{
						errors["SearchGoalsPlayerId"] = null;
					}
				}
			}
		}
		public ObservableCollection<Assist> UserAssistsPlayer
		{
			get { return _assistsPlayer; }
			set { Set(ref _assistsPlayer, value); }
		}
		public ObservableCollection<Goal> UserGoalsPlayer
		{
			get { return _goalsPlayer; }
			set { Set(ref _goalsPlayer, value); }
		}
		public ObservableCollection<string> SelectedTeams { get; set; }
		#endregion
		#region Constructors
		public StatisticForAdminViewModel(NavigationManager smallNavigationInfoManager, NavigationManager navigationManager) : this()
		{
			_navigationManager = navigationManager;
			_smallNavigationInfoManager = smallNavigationInfoManager;
		}
		public StatisticForAdminViewModel() 
		{
			errors = new Dictionary<string, string>();
			errors["SearchGoalsPlayerId"] = null;
			errors["SearchAssistsPlayerId"] = null;
			errors["InsertPlayerNameGoals"] = null;
			errors["InsertCountOfGoals"] = null;
			errors["InsertCountOfAssists"] = null;
			errors["InsertPlayerNameAssists"] = null;
			errors["DeletePlayersIdGoals"] = null;
			errors["DeletePlayersIdAssists"] = null;
			SearchGoalsPlayers = new DelegateCommand(SearchGoalsPlayersCommand, CanSearchGoalsPlayersCommand);
			SearchAssistsPlayers = new DelegateCommand(SearchAssistsPlayersCommand, CanSearchAssistsPlayersCommand);
			BackGoals = new DelegateCommand(BackGoalsCommand, CanBackGoalsCommand);
			BackAssists = new DelegateCommand(BackAssistsCommand, CanBackAssistsCommand);
			CreatePlayersGoals = new DelegateCommand(CreatePlayersGoalsCommand, CanCreatePlayersGoalsCommand);
			DeletePlayersGoals = new DelegateCommand(DeletePlayersGoalsCommand, CanDeletePlayersGoalsCommamd);
			CreatePlayersAssists = new DelegateCommand(CreatePlayersAssistsCommand, CanCreatePlayersAssistsCommand);
			DeletePlayersAssists = new DelegateCommand(DeletePlayersAssistsCommand, CanDeletePlayersAssistsCommamd);
		}
		#endregion

		#region Commands
		public ICommand SearchGoalsPlayers { get; set; }
		public ICommand SearchAssistsPlayers { get; set; }
		public ICommand BackGoals { get; set; }
		public ICommand BackAssists { get; set; }
		public ICommand CreatePlayersGoals { get; set; } 
		public ICommand CreatePlayersAssists { get; set; }
		public ICommand DeletePlayersGoals { get; set; }
		public ICommand DeletePlayersAssists { get; set; }
		//----------------------------------------------------------
		private bool CanDeletePlayersAssistsCommamd(object parameters)
		{
			if (errors["DeletePlayersIdAssists"] == null && DeletePlayersIdAssists != null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		private void DeletePlayersAssistsCommand(object parameters)
		{
			using (UnitOfWork db = new UnitOfWork())
			{
				if (db.Assists.Delete(Convert.ToInt32(DeletePlayersIdAssists)))
				{
					db.Save();
					UserAssistsPlayer = new ObservableCollection<Assist>(db.Assists.GetAll().OrderByDescending(t => Convert.ToInt32(t.CountOfAssists)));
					MessageBox.Show("Данные успешно удалены!");
					bool isGoal = db.Goals.GetAll().Any(t => t.Id == Convert.ToInt32(DeletePlayersIdAssists));
					if (isGoal == false)
					{
						db.Players.Delete(Convert.ToInt32(DeletePlayersIdAssists));
						db.Save();
					}
				}
				else
				{
					MessageBox.Show("Не удалось найти игрока по указанному Id");
				}
				DeletePlayersIdAssists = null;
			}
		}
		//----------------------------------------------------------
		//-----------------------------------------------------------
		private bool CanCreatePlayersAssistsCommand(object parameter)
		{
			if ((errors["InsertPlayerNameAssists"] == null && InsertPlayerNameAssists != null) &&
				(errors["InsertCountOfAssists"] == null && InsertCountOfAssists != null) &&
				InsertTeamNameAssists != null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		private void CreatePlayersAssistsCommand(object parameter)
		{
			try
			{
				using (UnitOfWork db = new UnitOfWork())
				{
					//Если нет в таблице Player
					bool isPlayers = db.Players.GetAll().Any(t => t.PlayerName == InsertPlayerNameAssists && t.Team.TeamName == InsertTeamNameAssists);
					if (isPlayers == false)
					{
						int id1 = db.Teams.GetAll().Where(t => t.TeamName == InsertTeamNameAssists).Select(p => p.Id).First();
						Player newPlayer = new Player(InsertPlayerNameAssists, id1);
						db.Players.Create(newPlayer);
						db.Save();
						
						int id2 = db.Players.GetAll().Where(t => t.PlayerName == InsertPlayerNameAssists).Select(p => p.Id).First();
						Assist newPlayerAssist = new Assist(id2, InsertCountOfAssists);
						db.Assists.Create(newPlayerAssist);
						db.Save();
						UserAssistsPlayer = new ObservableCollection<Assist>(db.Assists.GetAll().OrderByDescending(t => Convert.ToInt32(t.CountOfAssists)));
						MessageBox.Show("Новый игрок добавлен!");
					}
					else
					{
						int playerid = db.Players.GetAll().Where(t => t.PlayerName == InsertPlayerNameAssists && t.Team.TeamName == InsertTeamNameAssists).Select(t => t.Id).First();
						bool isAssist = db.Assists.GetAll().Any(t => t.Id == playerid);
						//Если есть в таблице Player, но нет в таблице Assist
						if (isAssist == false)
						{
							Assist newPlayerAssist = new Assist(playerid, InsertCountOfAssists);
							db.Assists.Create(newPlayerAssist);
							db.Save();
							UserAssistsPlayer = new ObservableCollection<Assist>(db.Assists.GetAll().OrderByDescending(t => Convert.ToInt32(t.CountOfAssists)));
							MessageBox.Show("Новый игрок добавлен!");
						}
						else
						{
							MessageBox.Show("Игрок с таким именем уже существует");
						}
					}
					InsertPlayerNameAssists = null;
					InsertTeamNameAssists = null;
					InsertCountOfAssists = null;
				}
			}
			catch { }
		}
		//-----------------------------------------------------------
		//-----------------------------------------------------------
		private bool CanDeletePlayersGoalsCommamd(object parameters)
		{
			if (errors["DeletePlayersIdGoals"] == null && DeletePlayersIdGoals != null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		private void DeletePlayersGoalsCommand(object parameters)
		{
			using (UnitOfWork db = new UnitOfWork())
			{
				if (db.Goals.Delete(Convert.ToInt32(DeletePlayersIdGoals)))
				{
					db.Save();
					UserGoalsPlayer = new ObservableCollection<Goal>(db.Goals.GetAll().OrderByDescending(t => Convert.ToInt32(t.CountOfGoals)));
					MessageBox.Show("Данные успешно удалены!");
					bool isAssists = db.Assists.GetAll().Any(t => t.Id == Convert.ToInt32(DeletePlayersIdGoals));
					if (isAssists == false)
					{
						db.Players.Delete(Convert.ToInt32(DeletePlayersIdGoals));
						db.Save();
					}
				}
				else
				{
					MessageBox.Show("Не удалось найти игрока по указанному Id");
				}
				DeletePlayersIdGoals = null;
			}
		}
		//------------------------------------------------------------
		//------------------------------------------------------------
		private bool CanCreatePlayersGoalsCommand(object parameter)
		{
			if ((errors["InsertPlayerNameGoals"] == null && InsertPlayerNameGoals != null) && 
				(errors["InsertCountOfGoals"] == null && InsertCountOfGoals != null) &&
				InsertTeamNameGoals != null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		private void CreatePlayersGoalsCommand(object parameter)
		{
			try
			{
				using (UnitOfWork db = new UnitOfWork())
				{
					//Если нет в таблице Player
					bool isPlayers = db.Players.GetAll().Any(t => t.PlayerName == InsertPlayerNameGoals && t.Team.TeamName == InsertTeamNameGoals);
					if (isPlayers == false)
					{
						int id1 = db.Teams.GetAll().Where(t => t.TeamName == InsertTeamNameGoals).Select(p => p.Id).First();
						Player newPlayer = new Player(InsertPlayerNameGoals, id1);

						db.Players.Create(newPlayer);
						db.Save();
						int id2 = db.Players.GetAll().Where(t => t.PlayerName == InsertPlayerNameGoals).Select(p => p.Id).First();
						Goal newPlayerGoal = new Goal(id2, InsertCountOfGoals);
						db.Goals.Create(newPlayerGoal);
						db.Save();
						UserGoalsPlayer = new ObservableCollection<Goal>(db.Goals.GetAll().OrderByDescending(t => Convert.ToInt32(t.CountOfGoals)));
						MessageBox.Show("Новый игрок добавлен!");
					}
					else
					{
						int playerid = db.Players.GetAll().Where(t => t.PlayerName == InsertPlayerNameGoals && t.Team.TeamName == InsertTeamNameGoals).Select(t => t.Id).First();
						bool isGoal = db.Goals.GetAll().Any(t => t.Id == playerid);
						//Если нет в таблице Player и в таблице Goal
						if (isGoal == false)
						{
							Goal newPlayerGoal = new Goal(playerid, InsertCountOfGoals);
							db.Goals.Create(newPlayerGoal);
							db.Save();
							UserGoalsPlayer = new ObservableCollection<Goal>(db.Goals.GetAll().OrderByDescending(t => Convert.ToInt32(t.CountOfGoals)));
							MessageBox.Show("Новый игрок добавлен!");
						}
						else
						{
							MessageBox.Show("Игрок с таким именем уже существует");
						}
					}
					InsertPlayerNameGoals = null;
					InsertTeamNameGoals = null;
					InsertCountOfGoals = null;
				}
			}
			catch { }
		}

		//------------------------------------------------------------
		//------------------------------------------------------------
		public bool CanSearchAssistsPlayersCommand(object parameter)
		{
			if (errors["SearchAssistsPlayerId"] == null && SearchAssistsPlayerId != null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public void SearchAssistsPlayersCommand(object parameter)
		{
			using (UnitOfWork db = new UnitOfWork())
			{
				bool isAssistsPlayer = db.Assists.GetAll().Any(t => t.Player.Id == Convert.ToInt32(SearchAssistsPlayerId));
				if (isAssistsPlayer == true)
				{
					Assist searchPlayer = db.Assists.GetAll().Where(t => t.Player.Id == Convert.ToInt32(SearchAssistsPlayerId)).First();
					if (searchPlayer != null)
					{
						UserAssistsPlayer = new ObservableCollection<Assist>() { searchPlayer };
					}
				}
				else
				{
					MessageBox.Show("Не удалось найти игрока по указанному Id");
				}
				SearchAssistsPlayerId = null;
			}
		}
		//------------------------------------------------------------
		//------------------------------------------------------------
		public bool CanBackAssistsCommand(object parameter)
		{
			return true;
		}
		public void BackAssistsCommand(object parameter)
		{
			using (UnitOfWork db = new UnitOfWork())
			{
				UserAssistsPlayer = new ObservableCollection<Assist>(db.Assists.GetAll().OrderByDescending(t => Convert.ToInt32(t.CountOfAssists)));
			}
		}
		//------------------------------------------------------------
		//-------------------------------------------------------------
		public bool CanBackGoalsCommand(object parameter)
		{
			return true;
		}
		public void BackGoalsCommand(object parameter)
		{
			using (UnitOfWork db = new UnitOfWork())
			{
				UserGoalsPlayer = new ObservableCollection<Goal>(db.Goals.GetAll().OrderByDescending(t => Convert.ToInt32(t.CountOfGoals)));
			}
		}
		//--------------------------------------------------------------
		//------------------------------------------------------------
		public bool CanSearchGoalsPlayersCommand(object parameter)
		{
			if (errors["SearchGoalsPlayerId"] == null && SearchGoalsPlayerId != null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public void SearchGoalsPlayersCommand(object parameter)
		{
			using (UnitOfWork db = new UnitOfWork())
			{
				bool isGoalsPlayer = db.Goals.GetAll().Any(t => t.Player.Id == Convert.ToInt32(SearchGoalsPlayerId));
				if (isGoalsPlayer == true)
				{
					Goal searchPlayer = db.Goals.GetAll().Where(t => t.Player.Id == Convert.ToInt32(SearchGoalsPlayerId)).First();
					if (searchPlayer != null)
					{
						UserGoalsPlayer = new ObservableCollection<Goal>() { searchPlayer };
					}
				}
				else
				{
					MessageBox.Show("Не удалось найти игрока по указанному Id");
				}
				SearchGoalsPlayerId = null;
			}
		}
		//------------------------------------------------------------
		#endregion

		#region Methods
		public void ActionsBeforeClosing(){}

		public void ActionsBeforeInsert(object parameters = null)
		{
			using (UnitOfWork db = new UnitOfWork())
			{
				UserGoalsPlayer = new ObservableCollection<Goal>(db.Goals.GetAll().OrderByDescending(t=> Convert.ToInt32(t.CountOfGoals)));
				UserAssistsPlayer = new ObservableCollection<Assist>(db.Assists.GetAll().OrderByDescending(t=> Convert.ToInt32(t.CountOfAssists)));
				SelectedTeams = new ObservableCollection<string>(db.Teams.GetAll().Select(t => t.TeamName));
			}
		}
		#endregion
	}
}
