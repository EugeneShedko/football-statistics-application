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
	class RegisterWindowViewModel : ViewModelBase, INavigationActions
	{
		#region Fields
		private string _FamilyName;
		private string _Name;
		private string _Login;
		private string _Password;
		private NavigationManager _navigationManager;
		private NavigationManager _smallNavigationManager;
		#endregion
		#region Properties
		public string FamilyName
		{
			get { return _FamilyName; }
			set { Set(ref _FamilyName, value); }
		}
		public string Name
		{
			get { return _Name; }
			set { Set(ref _Name, value); }
		}
		public string Login
		{
			get { return _Login; }
			set { Set(ref _Login, value); }
		}
		public string Password
		{
			get { return _Password; }
			set { Set(ref _Password, value); }
		}
		#endregion
		#region Constructors
		public RegisterWindowViewModel(NavigationManager smallNavigationManager,NavigationManager navigationManager) : this()
		{
			_navigationManager = navigationManager;
			_smallNavigationManager = smallNavigationManager;
		}
		public RegisterWindowViewModel()
		{
			ShowLoginWindow = new DelegateCommand(ShowLoginWindowCommand, CanShowLoginWindowCommand);
		}
		#endregion
		#region Methods
		public void ActionsBeforeInsert(){}
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
			_smallNavigationManager.Insert(NavigationKeys.LoginWindow);
		}
		#endregion
	}
}
