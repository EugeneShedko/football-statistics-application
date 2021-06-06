using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Navigation;
using WpfApp1.UnitOfWorkAndRepository;
using WpfApp1.View;
using WpfApp1.View.User;
using WpfApp1.ViewModels.User;

namespace WpfApp1.ViewModels
{
	class MainWindowForInformationViewModelUser : ViewModelBase, INavigationActions
	{
		#region Fields
		private NavigationManager _navigationManager;
		private NavigationManager _smallNavigationInfoManager;
		private string currentuser;
		private string showUser;
		#endregion
		#region Properties
		public string ShowUser
		{
			get { return showUser; }
			set { Set(ref showUser, value); }
		}
		#endregion
		#region Constructors
		public MainWindowForInformationViewModelUser(NavigationManager navigationManager) : this()
		{
			_navigationManager = navigationManager;
		}
		public MainWindowForInformationViewModelUser() 
		{
			ShowMainUserWindow = new DelegateCommand(ShowMainUserWindowCommand, CanShowMainUserWindowCommand);
			ShowTournamentTableUserWindow = new DelegateCommand(ShowTournamentTableUserWindowCommand, CanShowTournamentTableUserWindowCommand);
			ShowStatisticUserWindow = new DelegateCommand(ShowStatisticWindowCommand, CanShowStatisticWindowCommand);
			ShowTicketsUserWindow = new DelegateCommand(ShowTicketsUserWindowCommand, CanShowTicketsUserWindowCommand);
			ShowCommentUserWindow = new DelegateCommand(ShowCommentUserWindowCommand, CanShowCommentUserWindowCommand);
			ShowExitUserWindow = new DelegateCommand(ShowExitUserWindowCommand, CanShowExitUserWindowCommand);
			ShowUserTicketsWindow = new DelegateCommand(ShowUserTicketsWindowCommand, CanShowUserTicketsWindowCommand);
			ShowUserProfileWindow = new DelegateCommand(ShowUserProfileWindowCommand, CanShowUserProfileWindowCommand);
		}
		#endregion
		#region Commands
		public ICommand ShowMainUserWindow { get; set; }
		public ICommand ShowTournamentTableUserWindow { get; set;}
		public ICommand ShowStatisticUserWindow { get; set; }
		public ICommand ShowTicketsUserWindow { get; set; }
		public ICommand ShowCommentUserWindow { get; set; }
		public ICommand ShowExitUserWindow { get; set; }
		public ICommand ShowUserProfileWindow { get; set; }
		public ICommand ShowUserTicketsWindow { get; set; }
		private bool CanShowMainUserWindowCommand(object parameter)
		{
			return true;
		}
		private void ShowMainUserWindowCommand(object parameter)
		{
			_smallNavigationInfoManager.AddUserControl<MainForUserViewModel, MainForUser>(new MainForUserViewModel(_smallNavigationInfoManager, _navigationManager), NavigationKeys.MainForUser);
			_smallNavigationInfoManager.Insert(NavigationKeys.MainForUser);
		}
		private bool CanShowTournamentTableUserWindowCommand(object parameter)
		{
			return true;
		}
		private void ShowTournamentTableUserWindowCommand(object parameter)
		{
			_smallNavigationInfoManager.AddUserControl<TournamentTableUserViewModel, TournamentTableForUser>(new TournamentTableUserViewModel(_smallNavigationInfoManager, _navigationManager), NavigationKeys.TournamentTableForUser);
			_smallNavigationInfoManager.Insert(NavigationKeys.TournamentTableForUser);
		}
		private bool CanShowStatisticWindowCommand(object parameter)
		{
			return true;
		}
		private void ShowStatisticWindowCommand(object parameter)
		{
			_smallNavigationInfoManager.AddUserControl<StatisticForUserViewModel, StatisticForUser>(new StatisticForUserViewModel(_smallNavigationInfoManager, _navigationManager), NavigationKeys.StatisticForUser);
			_smallNavigationInfoManager.Insert(NavigationKeys.StatisticForUser);
		}
		private bool CanShowTicketsUserWindowCommand(object parameter)
		{
			return true;
		}
		private void ShowTicketsUserWindowCommand(object parameter)
		{
			_smallNavigationInfoManager.AddUserControl<TicketsForUserViewModel, TicketsForUser>(new TicketsForUserViewModel(_smallNavigationInfoManager, _navigationManager), NavigationKeys.TicketsForUser);
			_smallNavigationInfoManager.Insert(NavigationKeys.TicketsForUser, currentuser);
		}
		private bool CanShowCommentUserWindowCommand(object parameter)
		{
			return true;
		}
		private void ShowCommentUserWindowCommand(object parammeter)
		{
			_smallNavigationInfoManager.AddUserControl<CommentForUserViewModel, CommentForUser>(new CommentForUserViewModel(_smallNavigationInfoManager, _navigationManager), NavigationKeys.CommentForUser);
			_smallNavigationInfoManager.Insert(NavigationKeys.CommentForUser, currentuser);
		}
		private bool CanShowExitUserWindowCommand(object parameter)
		{
			return true;
		}
		private void ShowExitUserWindowCommand(object parameter)
		{
			_smallNavigationInfoManager.AddUserControl<ExitWindowViewModel, ExitWindowForUser>(new ExitWindowViewModel(_smallNavigationInfoManager, _navigationManager), NavigationKeys.ExitWindowForUser);
			_smallNavigationInfoManager.Insert(NavigationKeys.ExitWindowForUser);
		}
		private bool CanShowUserTicketsWindowCommand(object parameter)
		{
			return true;
		}
		private void ShowUserTicketsWindowCommand(object parameter)
		{
			_smallNavigationInfoManager.AddUserControl<UserTicketsViewModel, UserTicketsxaml>(new UserTicketsViewModel(_smallNavigationInfoManager, _navigationManager), NavigationKeys.UserTickets);
			_smallNavigationInfoManager.Insert(NavigationKeys.UserTickets, currentuser);
		}
		private bool CanShowUserProfileWindowCommand(object parameter)
		{
			return true;
		}
		private void ShowUserProfileWindowCommand(object parameter)
		{
			_smallNavigationInfoManager.AddUserControl<UserProfileViewModel, UserProfile>(new UserProfileViewModel(_smallNavigationInfoManager, _navigationManager), NavigationKeys.UserProfile);
			_smallNavigationInfoManager.Insert(NavigationKeys.UserProfile, currentuser);
		}
		#endregion
		#region Methods
		public void ActionsBeforeClosing(){}
		public void ActionsBeforeInsert(object parameters = null)
		{
			currentuser = (string)parameters;
			using (UnitOfWork db = new UnitOfWork())
			{
				ShowUser = db.Users.GetAll().Where(t => t.LoginId == currentuser).Select(t => t.Name).First();
			}
				//Достаем из коллекции объект данного типа, преобразеуем его и берем от него ContentControl
			_smallNavigationInfoManager = new NavigationManager(_navigationManager._Dispatcher, ((MainWindowForInformation)_navigationManager.ViewTypesByViewModelTypes[this.GetType()]).ForInformation, _navigationManager.Mainwindow);
			//Регистрируем все страницы, которые возможно поместить и использовать в рамках выбранного ContentControl
			_smallNavigationInfoManager.AddUserControl<MainForUserViewModel, MainForUser>(new MainForUserViewModel(_smallNavigationInfoManager, _navigationManager), NavigationKeys.MainForUser);
			_smallNavigationInfoManager.AddUserControl<TournamentTableUserViewModel, TournamentTableForUser>(new TournamentTableUserViewModel(_smallNavigationInfoManager, _navigationManager), NavigationKeys.TournamentTableForUser);
			_smallNavigationInfoManager.AddUserControl<StatisticForUserViewModel, StatisticForUser>(new StatisticForUserViewModel(_smallNavigationInfoManager, _navigationManager), NavigationKeys.StatisticForUser);
			_smallNavigationInfoManager.AddUserControl<TicketsForUserViewModel, TicketsForUser>(new TicketsForUserViewModel(_smallNavigationInfoManager, _navigationManager), NavigationKeys.TicketsForUser);
			_smallNavigationInfoManager.AddUserControl<CommentForUserViewModel, CommentForUser>(new CommentForUserViewModel(_smallNavigationInfoManager, _navigationManager), NavigationKeys.CommentForUser);
			_smallNavigationInfoManager.AddUserControl<ExitWindowViewModel,ExitWindowForUser> (new ExitWindowViewModel(_smallNavigationInfoManager, _navigationManager), NavigationKeys.ExitWindowForUser);
			_smallNavigationInfoManager.AddUserControl<UserTicketsViewModel, UserTicketsxaml>(new UserTicketsViewModel(_smallNavigationInfoManager, _navigationManager), NavigationKeys.UserTickets);
			_smallNavigationInfoManager.AddWindow<NewsForUserViewModel, NewsForUser>(new NewsForUserViewModel(_smallNavigationInfoManager, _navigationManager), NavigationKeys.NewsForUser);
			//Вызываем функцию для вставки новой страницы
			_smallNavigationInfoManager.Insert(NavigationKeys.MainForUser);
		}
		#endregion
	}
}
