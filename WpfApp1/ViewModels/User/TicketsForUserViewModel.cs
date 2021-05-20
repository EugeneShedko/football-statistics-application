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
	class TicketsForUserViewModel : ViewModelBase, INavigationActions
	{
		#region Fields
		private NavigationManager _navigationManager;
		private NavigationManager _smallNavigationInfoManager;
		#endregion
		#region Properties
		#endregion
		#region Constructors
		public TicketsForUserViewModel(NavigationManager smallNavigationManager, NavigationManager navigationManager) : this()
		{
			_smallNavigationInfoManager = smallNavigationManager;
			_navigationManager = navigationManager;
		}
		public TicketsForUserViewModel() 
		{
			ShowMessageBox = new DelegateCommand(ShowMessageBoxCommand, CanShowMessageBoxCommand);
		}
		#endregion
		#region Commands
		public ICommand ShowMessageBox { get; set;}
		private bool CanShowMessageBoxCommand(object parameter)
		{
			return true;
		}
		private void ShowMessageBoxCommand(object parameter)
		{
			MessageBox.Show("Ваш заказ оформлен!");
		}

		#endregion
		#region Methods
		public void ActionsBeforeClosing(){}

		public void ActionsBeforeInsert(object parameters = null)
		{}
		#endregion
	}
}
