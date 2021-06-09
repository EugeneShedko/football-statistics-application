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
	class TournamentTableForAdminViewModel : ViewModelBase, INavigationActions, IDataErrorInfo
	{
		#region Fields
		private NavigationManager _navigationManager;
		private NavigationManager _smallNavigationInfoManger;
		private ObservableCollection<Team> _userTeams;
		private string _searchTeamId;


		private string _insertTeamName;
		private string _insertCountOfGame;
		private string _insertCountOfWins;
		private string _insertCountOfDraws;
		private string _insertCountOfLose;
		private string _insertCountOfScoredGoals;
		private string _insertCountOfConsededGoals;
		private string _deleteTeamId;

		Dictionary<string, string> errors;
		public string this[string propertyName] => errors.ContainsKey(propertyName) ? errors[propertyName] : null;
		public string Error => throw new NotImplementedException();
		#endregion

		#region Properties
		public string DeleteTeamId
		{
			get { return _deleteTeamId; }
			set
			{
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
		public string InsertCountOfConsededGoals
		{
			get { return _insertCountOfConsededGoals; }
			set
			{
				Set(ref _insertCountOfConsededGoals, value);
				string str = @"[0-9]";
				if (InsertCountOfConsededGoals != null)
				{
					if (!Regex.IsMatch(InsertCountOfConsededGoals, str))
					{
						errors["InsertCountOfConsededGoals"] = "Неверный формат данных, возможны только цифры";
					}
					else
					{
						errors["InsertCountOfConsededGoals"] = null;
					}
				}
			}
		}
		public string InsertCountOfScoredGoals
		{
			get { return _insertCountOfScoredGoals; }
			set 
			{
				Set(ref _insertCountOfScoredGoals, value);
				string str = @"[0-9]";
				if (InsertCountOfScoredGoals != null)
				{
					if (!Regex.IsMatch(InsertCountOfScoredGoals, str))
					{
						errors["InsertCountOfScoredGoals"] = "Неверный формат данных, возможны только цифры";
					}
					else
					{
						errors["InsertCountOfScoredGoals"] = null;
					}
				}
			}
		}
		public string InsertCountOfLose
		{
			get { return _insertCountOfLose; }
			set
			{
				Set(ref _insertCountOfLose, value);
				string str = @"[0-9]";
				if (InsertCountOfLose != null)
				{
					if (!Regex.IsMatch(InsertCountOfLose, str))
					{
						errors["InsertCountOfLose"] = "Неверный формат данных, возможны только цифры";
					}
					else
					{
						errors["InsertCountOfLose"] = null;
					}
				}
			}
		}
		public string InsertCountOfDraws
		{
			get { return _insertCountOfDraws; }
			set 
			{
				Set(ref _insertCountOfDraws, value);
				string str = @"[0-9]";
				if (InsertCountOfDraws != null)
				{
					if (!Regex.IsMatch(InsertCountOfDraws, str))
					{
						errors["InsertCountOfDraws"] = "Неверный формат данных, возможны только цифры";
					}
					else
					{
						errors["InsertCountOfDraws"] = null;
					}
				}
			}
		}
		public string InsertCountOfWins
		{
			get { return _insertCountOfWins;}
			set
			{
				Set(ref _insertCountOfWins, value);
				string str = @"[0-9]";
				if (InsertCountOfWins != null)
				{
					if (!Regex.IsMatch(InsertCountOfWins, str))
					{
						errors["InsertCountOfWins"] = "Неверный формат данных, возможны только цифры";
					}
					else
					{
						errors["InsertCountOfWins"] = null;
					}
				}
			}
		}
		public string InsertTeamName
		{
			get { return _insertTeamName; }
			set 
			{
				Set(ref _insertTeamName, value);
				string str = @"^[А-Яа-я0-9]+|[А-Яа-я0-9]+[' '][А-Яа-я0-9]+ $";
				if (InsertTeamName != null)
				{
					using (UnitOfWork db = new UnitOfWork())
					{
						bool isTeam = db.Teams.GetAll().Any(t => t.TeamName == InsertTeamName);
						if (isTeam == true)
						{
							errors["InsertTeamName"] = "Такая команда уже существует";
						}
						else
						{
							if (!Regex.IsMatch(InsertTeamName, str))
							{
								errors["InsertTeamName"] = "Неверный формат данных";
							}
							else
							{
								errors["InsertTeamName"] = null;
							}
						}
					}
				}

			}

		}
		public string InsertCountOfGame
		{
			get { return _insertCountOfGame; }
			set 
			{ 
				Set(ref _insertCountOfGame, value);
				string str = @"[0-9]";
				if (InsertCountOfGame != null)
				{
					if (!Regex.IsMatch(InsertCountOfGame, str))
					{
						errors["InsertCountOfGame"] = "Неверный формат данных, возможны только цифры";
					}
					else
					{
						errors["InsertCountOfGame"] = null;
					}
				}
			}
		}
		public string SearchTeamId
		{
			get { return _searchTeamId; }
			set 
			{
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
		public ObservableCollection<Team> UserTeams
		{
			get { return _userTeams; }
			set { Set(ref _userTeams, value); }
		}
		public ObservableCollection<string> SelectedTeams { get; set; }
		#endregion

		#region Constructors
		public TournamentTableForAdminViewModel(NavigationManager smallNavigationInfoManager, NavigationManager navigationManager) : this()
		{
			_navigationManager = navigationManager;
			_smallNavigationInfoManger = smallNavigationInfoManager;
		}
		public TournamentTableForAdminViewModel() 
		{
			errors = new Dictionary<string, string>();
			errors["SearchTeamId"] = null;
			errors["InsertTeamName"] = null;
			errors["InsertCountOfGame"] = null;
			errors["InsertCountOfWins"] = null;
			errors["InsertCountOfDraws"] = null;
			errors["InsertCountOfLose"] = null;
			errors["InsertCountOfScoredGoals"] = null;
			errors["InsertCountOfConsededGoals"] = null;
			errors["DeleteTeamId"] = null;
			SearchTeams = new DelegateCommand(SearchTeamsCommand, CanSearchTeamsCommand);
			Back = new DelegateCommand(BackCommand, CanBackCommand);
			CreateTeam = new DelegateCommand(CreateTeamCommand, CanCreateTeamCommand);
			DeleteTeam = new DelegateCommand(DeleteTeamCommand, CanDeleteTeamCommamd);
		}
		#endregion
		#region Commands
		public ICommand SearchTeams { get; set; }
		public ICommand Back { get; set; }
		public ICommand CreateTeam { get; set; }
		public ICommand DeleteTeam { get; set; }
		//-------------------------------------------------------
		private bool CanDeleteTeamCommamd(object parameters)
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
		private void DeleteTeamCommand(object parameters)
		{
			try
			{
				using (UnitOfWork db = new UnitOfWork())
				{
					bool isMatch = db.Games.GetAll().Any(t => t.TeamId1 == Convert.ToInt32(DeleteTeamId) || t.TeamId2 == Convert.ToInt32(DeleteTeamId));
					if (isMatch == true)
					{
						IEnumerable<int> idMatches = db.Games.GetAll().Where(t => t.TeamId1 == Convert.ToInt32(DeleteTeamId) || t.TeamId2 == Convert.ToInt32(DeleteTeamId)).Select(t => t.Id);
						for (int i = 0; i < idMatches.ToList().Count; i++)
						{
							db.Games.Delete(idMatches.ToList()[i]);
						}
						if (db.Teams.Delete(Convert.ToInt32(DeleteTeamId)))
						{
							db.Save();
							UserTeams = new ObservableCollection<Team>(db.Teams.GetAll().OrderByDescending(p => Convert.ToInt32(p.GoalsDifference)).OrderByDescending(t => Convert.ToInt32(t.Points)));
							MessageBox.Show("Данные успешно удалены!");
						}
						else
						{
							MessageBox.Show("Не удалось найти команду с указанным Id");
						}
					}
					else
					{
						if (db.Teams.Delete(Convert.ToInt32(DeleteTeamId)))
						{
							db.Save();
							UserTeams = new ObservableCollection<Team>(db.Teams.GetAll().OrderByDescending(p => Convert.ToInt32(p.GoalsDifference)).OrderByDescending(t => Convert.ToInt32(t.Points)));
							MessageBox.Show("Данные успешно удалены!");
						}
						else
						{
							MessageBox.Show("Не удалось найти команду с указанным Id");
						}
					}
					DeleteTeamId = null;
				}
			}
			catch { }
		}
		//-------------------------------------------------------
		//-------------------------------------------------------
		private bool CanCreateTeamCommand(object parameter)
		{
			if ((errors["InsertTeamName"] == null && InsertTeamName != null) &&
				(errors["InsertCountOfGame"] == null && InsertCountOfGame != null) &&
				(errors["InsertCountOfWins"] == null && InsertCountOfWins != null) &&
				(errors["InsertCountOfDraws"] == null && InsertCountOfDraws != null) &&
				(errors["InsertCountOfLose"] == null && InsertCountOfLose != null) &&
				(errors["InsertCountOfScoredGoals"] == null && InsertCountOfScoredGoals != null) &&
				(errors["InsertCountOfConsededGoals"] == null && InsertCountOfConsededGoals != null))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		private void CreateTeamCommand(object parameter)
		{
			using (UnitOfWork db = new UnitOfWork())
			{
				try
				{
					Team newTeam = new Team(InsertTeamName, InsertCountOfGame, Convert.ToInt32(InsertCountOfWins), Convert.ToInt32(InsertCountOfDraws),
						Convert.ToInt32(InsertCountOfLose), Convert.ToInt32(InsertCountOfScoredGoals), Convert.ToInt32(InsertCountOfConsededGoals));
					db.Teams.Create(newTeam);
					db.Save();
					UserTeams = new ObservableCollection<Team>(db.Teams.GetAll().OrderByDescending(p => Convert.ToInt32(p.GoalsDifference)).OrderByDescending(t => Convert.ToInt32(t.Points)));
					MessageBox.Show("Новая команда добавлена!");
					InsertTeamName = null;
					InsertCountOfGame = null;
					InsertCountOfWins = null;
					InsertCountOfDraws = null;
					InsertCountOfLose = null;
					InsertCountOfScoredGoals = null;
					InsertCountOfConsededGoals = null;
				}
				catch { }
			}
		}
		//-------------------------------------------------------
		//--------------------------------------------------------
		public bool CanSearchTeamsCommand(object parameter)
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
		public void SearchTeamsCommand(object parameter)
		{
			using (UnitOfWork db = new UnitOfWork())
			{
				bool isTeam = db.Teams.GetAll().Any(t => t.Id == Convert.ToInt32(SearchTeamId));
				if (isTeam == true)
				{
					Team searchTeam = db.Teams.GetAll().Where(t => t.Id == Convert.ToInt32(SearchTeamId)).First();
					if (searchTeam != null)
					{
						UserTeams = new ObservableCollection<Team>() { searchTeam };
					}
				}
				else
				{
					MessageBox.Show("Не удалось найти по указанному Id");
				}
				SearchTeamId = null;
			}
		}
		//----------------------------------------------------------
		//---------------------------------------------------------
		public bool CanBackCommand(object parameter)
		{
			return true;
		}
		public void BackCommand(object parameter)
		{
			using (UnitOfWork db = new UnitOfWork())
			{
				UserTeams = new ObservableCollection<Team>(db.Teams.GetAll());
			}
		}
		//---------------------------------------------------------
		#endregion
		#region Methods
		public void ActionsBeforeClosing(){}
		public void ActionsBeforeInsert(object parameters = null) 
		{
			using (UnitOfWork db = new UnitOfWork())
			{
				UserTeams = new ObservableCollection<Team>(db.Teams.GetAll().OrderByDescending(p=>Convert.ToInt32(p.GoalsDifference)).OrderByDescending(t=> Convert.ToInt32(t.Points)));
			}
		}
		#endregion
	}
}
