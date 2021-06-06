using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Models;
using WpfApp1.Navigation;
using WpfApp1.UnitOfWorkAndRepository;
using WpfApp1.View;
using WpfApp1.View.Admin;
using WpfApp1.View.All;
using WpfApp1.ViewModels.Admin;
using WpfApp1.ViewModels.All;

namespace WpfApp1.ViewModels
{
	class LoginWindowViewModel : ViewModelBase, INavigationActions
	{
		#region Fields
		private string _Login;
		private string _Password;
		private NavigationManager _navigationManager;
		private NavigationManager _smallNavigationLoginManager;
		private string mistake ;

		#endregion
		#region Properties
		public string Mistake
		{
			get { return mistake; }
			set { Set(ref mistake, value); }
		}
		public string Login
		{
			get { return _Login; }
			set 
			{
				Mistake = "";
				Set(ref _Login, value); 
			}
		}
		public string Password
		{
			get { return _Password; }
			set {
				Mistake = "";
				Set(ref _Password, value);
			}
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
			_smallNavigationLoginManager.AddUserControl<RegisterWindowViewModel, RegisterWindow>(new RegisterWindowViewModel(_smallNavigationLoginManager, _navigationManager), NavigationKeys.RegisterWindow);
			_smallNavigationLoginManager.Insert(NavigationKeys.RegisterWindow);
		}
		private bool CanShowMainWindowForInformationCommand(object parameter)
		{
			return true;
		}
		private void ShowMainWindowForInforamtionCommand(object parameter)
		{
			using(UnitOfWork db = new UnitOfWork())
			{
				bool isUser = db.Users.GetAll().Any(t=>t.LoginId == Login && t.Password == GetHach(Password));
				if (isUser == true)
				{
					_navigationManager.AddUserControl<MainWindowForInformationAdminViewModel, MainWindowForInformationAdmin>(new MainWindowForInformationAdminViewModel(_navigationManager), NavigationKeys.MainWindowForInformationAdmin);
					_navigationManager.Insert(NavigationKeys.MainWindowForInformationUser, Login);
				}
				else
				{
					Mistake = "Неверно введен логин или пароль";
				}
			}
		}
		private bool CanShowLoginWindowForAdminCommand(object parameter)
		{
			return true;
		}
		private void ShowLoginWindowForAdminCommand(object parameter)
		{
			_smallNavigationLoginManager.AddUserControl<LoginForAdminWindowViewModel,LoginForAlminWindow>(new LoginForAdminWindowViewModel(_smallNavigationLoginManager, _navigationManager), NavigationKeys.LoginForAdminWindow);
			_smallNavigationLoginManager.Insert(NavigationKeys.LoginForAdminWindow);
		}
		private string GetHach(string input)
		{
			var md5 = MD5.Create();
			var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
			return Convert.ToBase64String(hash);
		}
		#endregion
		#region Methods
		public void ActionsBeforeInsert(object parameters = null) { }
		public void ActionsBeforeClosing() 
		{}
		#endregion
	}
}
