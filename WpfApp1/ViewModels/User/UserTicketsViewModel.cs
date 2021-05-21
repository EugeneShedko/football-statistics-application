using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Navigation;

namespace WpfApp1.ViewModels.User
{
	class UserTicketsViewModel : ViewModelBase, INavigationActions
	{
		#region Fields
		private NavigationManager _navigationManager;
		private NavigationManager _smallNavigationInfoManager;
		#endregion
		#region Properties
		#endregion
		#region Constructors
		public UserTicketsViewModel(NavigationManager smallNavigationInfoManger, NavigationManager navigationManager) : this()
		{
			_navigationManager = navigationManager;
			_smallNavigationInfoManager = smallNavigationInfoManger;
		}
		public UserTicketsViewModel() 
		{
			ShowWindow = new DelegateCommand(ShowWindowCommand, CanShowWindowCommand);
		}
		#endregion
		#region Commands
		public ICommand ShowWindow { get; set; } //Заменить потом на нужную команду
		private bool CanShowWindowCommand(object parameter)
		{
			return true;
		}
		private void ShowWindowCommand(object parameter)
		{
			Window z = new Window();
			z.Show();
		}
		#endregion
		#region Methods
		public void ActionsBeforeClosing() {}

		public void ActionsBeforeInsert(object parameters = null) {}
		#endregion
	}
}
