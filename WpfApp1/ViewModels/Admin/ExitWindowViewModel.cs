using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Navigation;

namespace WpfApp1.ViewModels.Admin
{
	class ExitWindowViewModel : ViewModelBase, INavigationActions
	{
		#region Fields
		private NavigationManager _navigationManager;
		private NavigationManager _smallNavigationInfoManager;
		#endregion
		#region Properties
		#endregion
		#region Constructors
		public ExitWindowViewModel(NavigationManager smallNavigationInfoManager, NavigationManager navigationManager) : this()
		{
			_navigationManager = navigationManager;
			_smallNavigationInfoManager = smallNavigationInfoManager;
		}
		public ExitWindowViewModel() 
		{
			ShowMathesForAdminWindow = new DelegateCommand(ShowMathesForAdminWindowCommand, CanShowMatchesForAdminWindowCommand);
			ShowLoginForAdminWindow = new DelegateCommand(ShowLoginForAdminWindowCommand, CanShowLoginForAdminWindowCommand);
		}
		#endregion
		#region Commands
		public ICommand ShowMathesForAdminWindow { get; set; }
		public ICommand ShowLoginForAdminWindow { get; set;}
		private bool CanShowMatchesForAdminWindowCommand(object parameter)
		{
			return true;
		}
		private void ShowMathesForAdminWindowCommand(object parameter)
		{
			_smallNavigationInfoManager.Insert(NavigationKeys.MathesForAdmin);
		}
		private bool CanShowLoginForAdminWindowCommand(object parameter)
		{
			return true;
		}
		private void ShowLoginForAdminWindowCommand(object parameter)
		{
			_navigationManager.Insert(NavigationKeys.MainWindowLoginOrRegister);
		}
		#endregion
		#region Methods
		public void ActionsBeforeClosing(){}

		public void ActionsBeforeInsert(object parameters = null){}
		#endregion
	}
}
