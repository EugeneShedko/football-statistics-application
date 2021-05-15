using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Navigation;

namespace WpfApp1.ViewModels.User
{
	class MainForUserViewModel : ViewModelBase, INavigationActions
	{
		#region Fields
		private NavigationManager _navigationManager;
		private NavigationManager _smallNavigationManager;
		#endregion
		#region Constructors
		public MainForUserViewModel(NavigationManager smallNavigationManager, NavigationManager navigationManager)
		{
			_smallNavigationManager = smallNavigationManager;
			_navigationManager = navigationManager;
		}
		public MainForUserViewModel() { }
		#endregion
		#region Methods
		public void ActionsBeforeClosing(){}
		public void ActionsBeforeInsert(){}
		#endregion
	}
}
