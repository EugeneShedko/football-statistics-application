using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Navigation;

namespace WpfApp1.ViewModels.All
{
	class LoginForAdminWindowViewModel : ViewModelBase, INavigationActions
	{
		#region Fields
		private string _password;
		private NavigationManager _navigationManager;
		private NavigationManager _smallNavigationLoginManagaer;
		#endregion
		#region Properties
		public string Password
		{
			get { return _password;}
			set { Set(ref _password, value);}
		}
		#endregion
		#region Constructors
		public LoginForAdminWindowViewModel(NavigationManager smallNaviagtionLoginManager, NavigationManager navigationManager) : this()
		{
			_navigationManager = navigationManager;
			_smallNavigationLoginManagaer = smallNaviagtionLoginManager;
		}
		public LoginForAdminWindowViewModel() 
		{
			ShowLoginWindow = new DelegateCommand(ShowLoginWindowCommand, CanShowLoginWindowCommand);
			ShowMainWindowForInformationAdmin = new DelegateCommand( ShowMainWindowForInformationAdminCommand , CanShowMainWindowForInformationAdminCommand);
		}
		#endregion
		#region Commands
		public ICommand ShowLoginWindow { get; set; }
		public ICommand ShowMainWindowForInformationAdmin { get; set;}
		private bool CanShowLoginWindowCommand(object parameter)
		{
			return true;
		}
		private void ShowLoginWindowCommand(object parameter)
		{
			_smallNavigationLoginManagaer.Insert(NavigationKeys.LoginWindow);
		}
		private bool CanShowMainWindowForInformationAdminCommand(object parameter)
		{
			return true;
		}
		private void ShowMainWindowForInformationAdminCommand(object parameter)
		{
			_navigationManager.Insert(NavigationKeys.MainWindowForInformationAdmin);
		}
		#endregion
		#region Methods
		public void ActionsBeforeClosing() {}

		public void ActionsBeforeInsert(object parameters = null){}
		#endregion
	}
}
