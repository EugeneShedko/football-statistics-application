using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Navigation;
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
			ShowClubsUserWindow = new DelegateCommand(ShowClubsUserWindowCommand, CanShowClubsUserWindowCommand);
		}
		#endregion
		#region Commands
		public ICommand ShowMainUserWindow { get; set; }
		public ICommand ShowTournamentTableUserWindow { get; set;}
		public ICommand ShowStatisticUserWindow { get; set; }
		public ICommand ShowTicketsUserWindow { get; set; }
		public ICommand ShowCommentUserWindow { get; set; }
		public ICommand ShowClubsUserWindow { get; set;}
		private bool CanShowMainUserWindowCommand(object parameter)
		{
			return true;
		}
		private void ShowMainUserWindowCommand(object parameter)
		{
			_smallNavigationInfoManager.Insert(NavigationKeys.MainForUser);
		}
		private bool CanShowTournamentTableUserWindowCommand(object parameter)
		{
			return true;
		}
		private void ShowTournamentTableUserWindowCommand(object parameter)
		{
			_smallNavigationInfoManager.Insert(NavigationKeys.TournamentTableForUser);
		}
		private bool CanShowStatisticWindowCommand(object parameter)
		{
			return true;
		}
		private void ShowStatisticWindowCommand(object parameter)
		{
			_smallNavigationInfoManager.Insert(NavigationKeys.StatisticForUser);
		}
		private bool CanShowTicketsUserWindowCommand(object parameter)
		{
			return true;
		}
		private void ShowTicketsUserWindowCommand(object parameter)
		{
			_smallNavigationInfoManager.Insert(NavigationKeys.TicketsForUser);
		}
		private bool CanShowCommentUserWindowCommand(object parameter)
		{
			return true;
		}
		private void ShowCommentUserWindowCommand(object parammeter)
		{
			_smallNavigationInfoManager.Insert(NavigationKeys.CommentForUser);
		}
		private bool CanShowClubsUserWindowCommand(object parameter)
		{
			return true;
		}
		private void ShowClubsUserWindowCommand(object parameter)
		{
			_smallNavigationInfoManager.Insert(NavigationKeys.ClubsForUser);
		}

		#endregion
		#region Methods
		public void ActionsBeforeClosing(){}
		public void ActionsBeforeInsert(object parameters = null)
		{
			//Достаем из коллекции объект данного типа, преобразеуем его и берем от него ContentControl
			_smallNavigationInfoManager = new NavigationManager(_navigationManager._Dispatcher, ((MainWindowForInformation)_navigationManager.ViewTypesByViewModelTypes[this.GetType()]).ForInformation, _navigationManager.Mainwindow);
			//Регистрируем все страницы, которые возможно поместить и использовать в рамках выбранного ContentControl
			_smallNavigationInfoManager.AddUserControl<MainForUserViewModel, MainForUser>(new MainForUserViewModel(_smallNavigationInfoManager, _navigationManager), NavigationKeys.MainForUser);
			_smallNavigationInfoManager.AddUserControl<TournamentTableUserViewModel, TournamentTableForUser>(new TournamentTableUserViewModel(_smallNavigationInfoManager, _navigationManager), NavigationKeys.TournamentTableForUser);
			_smallNavigationInfoManager.AddUserControl<StatisticForUserViewModel, StatisticForUser>(new StatisticForUserViewModel(_smallNavigationInfoManager, _navigationManager), NavigationKeys.StatisticForUser);
			_smallNavigationInfoManager.AddUserControl<TicketsForUserViewModel, TicketsForUser>(new TicketsForUserViewModel(_smallNavigationInfoManager, _navigationManager), NavigationKeys.TicketsForUser);
			_smallNavigationInfoManager.AddUserControl<CommentForUserViewModel, CommentForUser>(new CommentForUserViewModel(_smallNavigationInfoManager, _navigationManager), NavigationKeys.CommentForUser);
			_smallNavigationInfoManager.AddUserControl<ClubsForUserViewModel, ClubsForUser>(new ClubsForUserViewModel(_smallNavigationInfoManager,_navigationManager), NavigationKeys.ClubsForUser);
			_smallNavigationInfoManager.AddWindow<NewsForUserViewModel, NewsForUser>(new NewsForUserViewModel(_smallNavigationInfoManager, _navigationManager), NavigationKeys.NewsForUser);
			//Вызываем функцию для вставки новой страницы
			_smallNavigationInfoManager.Insert(NavigationKeys.MainForUser);
		}
		#endregion
	}
}
