using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Navigation;
using WpfApp1.View;

namespace WpfApp1.ViewModels.User
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
			ShowMainWindowLoginOrRegister = new DelegateCommand(ShowMainWindowLoginOrRegisterCommand, CanShowMainWindowLoginOrRegisterCommand);
			ShowMainFouUserWindow = new DelegateCommand(ShowMainForUserWindowCommand, CanShowMainForUserWindowCommand);
		}
		#endregion
		#region Commands
		public ICommand ShowMainWindowLoginOrRegister { get; set; }
		public ICommand ShowMainFouUserWindow { get; set; }
		private bool CanShowMainWindowLoginOrRegisterCommand(object parameter)
		{
			return true;
		}
		private void ShowMainWindowLoginOrRegisterCommand(object parameter)
		{
			_navigationManager.AddUserControl<MainWindowLoginOrRegisterViewModel, MainWindowLoginOrRegister>(new MainWindowLoginOrRegisterViewModel(_navigationManager),
			   NavigationKeys.MainWindowLoginOrRegister);
			_navigationManager.Insert(NavigationKeys.MainWindowLoginOrRegister);
		}
		private bool CanShowMainForUserWindowCommand(object parameter)
		{
			return true;
		}
		private void ShowMainForUserWindowCommand(object parameter)
		{
			_navigationManager.AddUserControl<MainWindowForInformationViewModelUser, MainWindowForInformation>(new MainWindowForInformationViewModelUser(_navigationManager),
			   NavigationKeys.MainWindowForInformationUser);
			_smallNavigationInfoManager.Insert(NavigationKeys.MainForUser);
		}
		#endregion
		#region Methods
		public void ActionsBeforeClosing(){}

		public void ActionsBeforeInsert(object parameters = null) {}
		#endregion
	}
}
