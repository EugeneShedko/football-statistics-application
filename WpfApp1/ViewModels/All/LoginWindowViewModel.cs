using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Navigation;

namespace WpfApp1.ViewModels
{
	class LoginWindowViewModel : ViewModelBase, INavigationActions
	{
		#region Fields
		private string _Login;
		private string _Password;
		private NavigationManager _navigationManager;
		private NavigationManager _smallNavigationLoginManager;
		#endregion
		#region Properties
		public string Login
		{
			get { return _Login; }
			set { Set(ref _Login, value); }
		}
		public string Password
		{
			get { return _Password; }
			set { Set(ref _Password, value);}
		}
		#endregion
		#region Constructors
		public LoginWindowViewModel(NavigationManager smallNavigatorManager, NavigationManager navigationManager) : this()
		{
			_smallNavigationLoginManager = smallNavigatorManager;
			_navigationManager = navigationManager;
		}
		public LoginWindowViewModel() 
		{
			ShowRegisterWindow = new DelegateCommand(ShowRegisterWindowCommand, CanShowRegisterWindowCommand);
			ShowMainWindowForInformation = new DelegateCommand(ShowMainWindowForInforamtionCommand, CanShowMainWindowForInformationCommand);
			ShowLoginWindowForAdmin = new DelegateCommand(ShowLoginWindowForAdminCommand, CanShowLoginWindowForAdminCommand);
		}
		#endregion
		#region Commands
		public ICommand ShowRegisterWindow { get; set; }
		public ICommand ShowMainWindowForInformation { get; set; }
		public ICommand ShowLoginWindowForAdmin { get; set; }
		private bool CanShowRegisterWindowCommand(object parameter)
		{
			return true;
		}
		private void ShowRegisterWindowCommand(object parameter)
		{
			_smallNavigationLoginManager.Insert(NavigationKeys.RegisterWindow);
		}
		private bool CanShowMainWindowForInformationCommand(object parameter)
		{
			return true;
		}
		private void ShowMainWindowForInforamtionCommand(object parameter)
		{
			_navigationManager.Insert(NavigationKeys.MainWindowForInformationUser);
		}
		private bool CanShowLoginWindowForAdminCommand(object parameter)
		{
			return true;
		}
		private void ShowLoginWindowForAdminCommand(object parameter)
		{
			_smallNavigationLoginManager.Insert(NavigationKeys.LoginForAdminWindow);
		}
		#endregion
		#region Methods
		public void ActionsBeforeInsert(object parameters = null) { }
		public void ActionsBeforeClosing() { }
		#endregion
	}
}
