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
using WpfApp1.View.Admin;
using WpfApp1.ViewModels.Admin;

namespace WpfApp1.ViewModels.All
{
	class LoginForAdminWindowViewModel : ViewModelBase, INavigationActions
	{
		#region Fields
		private string _password;
		private NavigationManager _navigationManager;
		private NavigationManager _smallNavigationLoginManagaer;
		private string mistake;
		#endregion
		#region Properties
		public string Mistake
		{
			get { return mistake; }
			set { Set(ref mistake, value); }
		}
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
			_smallNavigationLoginManagaer.AddUserControl<LoginWindowViewModel, LoginWindow>(new LoginWindowViewModel(_smallNavigationLoginManagaer, _navigationManager), NavigationKeys.LoginWindow);
			_smallNavigationLoginManagaer.Insert(NavigationKeys.LoginWindow);
		}
		private bool CanShowMainWindowForInformationAdminCommand(object parameter)
		{
			return true;
		}
		private void ShowMainWindowForInformationAdminCommand(object parameter)
		{
			using (UnitOfWork db = new UnitOfWork())
			{
				bool isUser = db.Users.GetAll().Any(t => t.LoginId == "Admin" && t.Password == Password);
				if (isUser == true)
				{
					_navigationManager.AddUserControl<MainWindowForInformationAdminViewModel, MainWindowForInformationAdmin>(new MainWindowForInformationAdminViewModel(_navigationManager), NavigationKeys.MainWindowForInformationAdmin);
					_navigationManager.Insert(NavigationKeys.MainWindowForInformationAdmin);
				}
				else
				{
					Mistake = "Неверно введен логин или пароль";
				}
			}
		}
		#endregion
		#region Methods
		public void ActionsBeforeClosing() {}

		public void ActionsBeforeInsert(object parameters = null){}
		#endregion
	}
}
