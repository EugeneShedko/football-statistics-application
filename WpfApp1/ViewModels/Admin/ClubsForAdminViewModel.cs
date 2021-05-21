using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Navigation;

namespace WpfApp1.ViewModels.Admin
{
	class ClubsForAdminViewModel : ViewModelBase, INavigationActions
	{
		#region Fields
		private NavigationManager _navigationManager;
		private NavigationManager _smallNavigationManager;
		#endregion
		#region Properties
		#endregion
		#region Constructors
		public ClubsForAdminViewModel(NavigationManager smallNavigationManager, NavigationManager navigationManager)
		{
			_navigationManager = navigationManager;
			_smallNavigationManager = smallNavigationManager;
		}
		public ClubsForAdminViewModel() { }
		#endregion
		#region Methods
		public void ActionsBeforeClosing(){}

		public void ActionsBeforeInsert(object parameters = null){}
		#endregion
	}
}
