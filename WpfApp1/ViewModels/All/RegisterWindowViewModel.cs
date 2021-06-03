using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Navigation;

namespace WpfApp1.ViewModels
{
	class RegisterWindowViewModel : ViewModelBase, INavigationActions, IDataErrorInfo
	{
		#region Fields
		private string _familyName;
		private string _name;
		private string _login;
		private string _password;
		private NavigationManager _navigationManager;
		private NavigationManager _smallNavigationLoginManager;
		#endregion
		#region Properties
		public string FamilyName
		{
			get { return _familyName; }
			set { Set(ref _familyName, value); }
		}
		public string Name
		{
			get { return _name; }
			set { Set(ref _name, value); }
		}
		public string Login
		{
			get { return _login; }
			set { Set(ref _login, value); }
		}
		public string Password
		{
			get { return _password; }
			set { Set(ref _password, value); }
		}
		#endregion
		#region Constructors
		public RegisterWindowViewModel(NavigationManager smallNavigationManager,NavigationManager navigationManager) : this()
		{
			_navigationManager = navigationManager;
			_smallNavigationLoginManager = smallNavigationManager;
		}
		public RegisterWindowViewModel()
		{
			ShowLoginWindow = new DelegateCommand(ShowLoginWindowCommand, CanShowLoginWindowCommand);
		}
		#endregion
		#region Methods
		public void ActionsBeforeInsert(object parameters = null){}
		public void ActionsBeforeClosing(){}
		#endregion
		#region Commands
		public ICommand ShowLoginWindow { get; set; }
		private bool CanShowLoginWindowCommand(object parameter)
		{
			return true;
		}
		private void ShowLoginWindowCommand(object parameter)
		{
			_smallNavigationLoginManager.Insert(NavigationKeys.LoginWindow);
		}
		#endregion
	}
}
