using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Navigation;

namespace WpfApp1.ViewModels.Admin
{
	class TicketsForAdminViewModel : ViewModelBase, INavigationActions
	{
		#region Fields
		private NavigationManager _navigationManager;
		private NavigationManager _smallNaviagtionInfoManager;
		#endregion
		#region Properties
		#endregion
		#region Constructors
		public TicketsForAdminViewModel(NavigationManager smallNavigationInfoManager, NavigationManager navigationManager)
		{
			_navigationManager = navigationManager;
			_smallNaviagtionInfoManager = smallNavigationInfoManager;
		}
		#endregion
		#region Methods
		public void ActionsBeforeClosing(){}

		public void ActionsBeforeInsert(object parameters = null){}
		#endregion
	}
}
