using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Navigation;
using WpfApp1.View.Admin;

namespace WpfApp1.ViewModels.Admin
{
	class MainWindowForInformationAdminViewModel : ViewModelBase, INavigationActions
	{
		#region Fields
		private NavigationManager _navigationManager;
		private NavigationManager _smallNavigationInfoManager;
		#endregion
		#region Properties
		#endregion
		#region Constructors
		public MainWindowForInformationAdminViewModel(NavigationManager navigationManager) : this()
		{
			_navigationManager = navigationManager;

		}
		public MainWindowForInformationAdminViewModel() 
		{
			ShowMatchesForAdminWindow = new DelegateCommand(ShowMatchesForAdminWindowCommand, CanShowMatchesForAdminWindowCommand);
			ShowNewsForAdminWindow = new DelegateCommand(ShowNewsForAdminCommand,CanShowNewsForAdminWindowCommand);
			ShowTournamentTableForAdminWindow = new DelegateCommand(ShowTournamentTableForAdminCommand, CanShowTournamentTableForAdminCommand);
			ShowStatisticForAdminWindow = new DelegateCommand(ShowStatisticForAdminCommand, CanShowStatisticForAdminCommand);
			ShowTicketsForAdminWindow = new DelegateCommand(ShowTicketsForAdminCommand, CanShowTicketsForAdminCommand);
			ShowExitForAdminWindow = new DelegateCommand(ShowExitForAdminCommand, CanShowExitForAdminCommand);
			ShowBookedTicketsForAdminWindow = new DelegateCommand(ShowBookedForAdminCommand, CanShowBookedForAdminCommand);
		}
		#endregion
		#region Commands
		public ICommand ShowMatchesForAdminWindow { get; set; }
		public ICommand ShowNewsForAdminWindow { get; set; }
		public ICommand ShowTournamentTableForAdminWindow { get; set; }
		public ICommand ShowStatisticForAdminWindow { get; set; }
		public ICommand ShowClubsForAdminWindow { get; set; }
		public ICommand ShowTicketsForAdminWindow { get; set;}
		public ICommand ShowExitForAdminWindow { get; set; }
		public ICommand ShowBookedTicketsForAdminWindow { get; set; }
		private bool CanShowMatchesForAdminWindowCommand(object parameter)
		{
			return true;
		}
		private void ShowMatchesForAdminWindowCommand(object parameter)
		{
			_smallNavigationInfoManager.AddUserControl<MathesForAdminViewModel, MathesForAdmin>(new MathesForAdminViewModel(_smallNavigationInfoManager, _navigationManager), NavigationKeys.MathesForAdmin);
			_smallNavigationInfoManager.Insert(NavigationKeys.MathesForAdmin);
		}
		private bool CanShowNewsForAdminWindowCommand(object parameter)
		{
			return true;
		}
		private void ShowNewsForAdminCommand(object parameter)
		{
			_smallNavigationInfoManager.AddUserControl<NewsForAdminViewModel, NewForAdmin>(new NewsForAdminViewModel(_smallNavigationInfoManager, _navigationManager), NavigationKeys.NewsForAdmin);
			_smallNavigationInfoManager.Insert(NavigationKeys.NewsForAdmin);
		}
		private bool CanShowTournamentTableForAdminCommand(object parameter)
		{
			return true;
		}
		private void ShowTournamentTableForAdminCommand(object parameter)
		{
			_smallNavigationInfoManager.AddUserControl<TournamentTableForAdminViewModel, TournamentTableForAdmin>(new TournamentTableForAdminViewModel(_smallNavigationInfoManager, _navigationManager), NavigationKeys.TournamentTableForAdmin);
			_smallNavigationInfoManager.Insert(NavigationKeys.TournamentTableForAdmin);
		}
		private bool CanShowStatisticForAdminCommand(object parameter)
		{
			return true;
		}
		private void ShowStatisticForAdminCommand(object parameter)
		{
			_smallNavigationInfoManager.AddUserControl<StatisticForAdminViewModel, StatisticForAdmin>(new StatisticForAdminViewModel(_smallNavigationInfoManager, _navigationManager), NavigationKeys.StatisticForAdmin);
			_smallNavigationInfoManager.Insert(NavigationKeys.StatisticForAdmin);
		}
		private bool CanShowTicketsForAdminCommand(object parameter)
		{
			return true;
		}
		private void ShowTicketsForAdminCommand(object parameter)
		{
			_smallNavigationInfoManager.AddUserControl<TicketsForAdminViewModel, TicketsForAdmin>(new TicketsForAdminViewModel(_smallNavigationInfoManager, _navigationManager), NavigationKeys.TicketsForAdmin);
			_smallNavigationInfoManager.Insert(NavigationKeys.TicketsForAdmin);
		}
		private bool CanShowExitForAdminCommand(object parameter)
		{
			return true;
		}
		private void ShowExitForAdminCommand(object parameter)
		{
			_smallNavigationInfoManager.AddUserControl<ExitWindowViewModel, ExitForAdmin>(new ExitWindowViewModel(_smallNavigationInfoManager, _navigationManager), NavigationKeys.ExitForAdmin);
			_smallNavigationInfoManager.Insert(NavigationKeys.ExitForAdmin);
		}
		private bool CanShowBookedForAdminCommand(object parameter)
		{
			return true;
		}
		private void ShowBookedForAdminCommand(object parameter)
		{
			_smallNavigationInfoManager.AddUserControl<BookedTicketsForAdminViewModel, BookedTicketsForAdmin1>(new BookedTicketsForAdminViewModel(_smallNavigationInfoManager, _navigationManager), NavigationKeys.BookedTicketsForUser);
			_smallNavigationInfoManager.Insert(NavigationKeys.BookedTicketsForUser);
		}
		#endregion
		#region Methods
		public void ActionsBeforeClosing(){}

		public void ActionsBeforeInsert(object parameters = null)
		{
			_smallNavigationInfoManager = new NavigationManager(_navigationManager._Dispatcher, ((MainWindowForInformationAdmin)_navigationManager.ViewTypesByViewModelTypes[this.GetType()]).ForInformation, _navigationManager.Mainwindow);
			_smallNavigationInfoManager.AddUserControl<MathesForAdminViewModel, MathesForAdmin>(new MathesForAdminViewModel(_smallNavigationInfoManager, _navigationManager), NavigationKeys.MathesForAdmin);
			//_smallNavigationInfoManager.AddUserControl<NewsForAdminViewModel, NewForAdmin>(new NewsForAdminViewModel(_smallNavigationInfoManager, _navigationManager), NavigationKeys.NewsForAdmin);
			//_smallNavigationInfoManager.AddUserControl<TournamentTableForAdminViewModel, TournamentTableForAdmin>(new TournamentTableForAdminViewModel(_smallNavigationInfoManager, _navigationManager), NavigationKeys.TournamentTableForAdmin);
			//_smallNavigationInfoManager.AddUserControl<StatisticForAdminViewModel, StatisticForAdmin>(new StatisticForAdminViewModel(_smallNavigationInfoManager, _navigationManager), NavigationKeys.StatisticForAdmin);
			//_smallNavigationInfoManager.AddUserControl<TicketsForAdminViewModel, TicketsForAdmin>( new TicketsForAdminViewModel(_smallNavigationInfoManager, _navigationManager), NavigationKeys.TicketsForAdmin);
			//_smallNavigationInfoManager.AddUserControl<ExitWindowViewModel, ExitForAdmin>(new ExitWindowViewModel(_smallNavigationInfoManager, _navigationManager), NavigationKeys.ExitForAdmin);
			//_smallNavigationInfoManager.AddUserControl<BookedTicketsForAdminViewModel, BookedTicketsForAdmin1>(new BookedTicketsForAdminViewModel(_smallNavigationInfoManager, _navigationManager), NavigationKeys.BookedTicketsForUser);
			_smallNavigationInfoManager.Insert(NavigationKeys.MathesForAdmin);
		}
		#endregion
	}
}
