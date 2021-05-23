using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Navigation;

namespace WpfApp1.ViewModels.Admin
{
	class BookedTicketsForAdminViewModel : ViewModelBase, INavigationActions
	{
		#region Fields
		private NavigationManager _navigationManager;
		private NavigationManager _smallNavugationInfoManager;
		#endregion
		#region Properties
		#endregion
		#region Constructors
		public BookedTicketsForAdminViewModel(NavigationManager smallNaviagtionInfoManager, NavigationManager navigationManager)
		{
			_navigationManager = navigationManager;
			_smallNavugationInfoManager = smallNaviagtionInfoManager;
		}
		#endregion
		#region Methods
		public void ActionsBeforeClosing(){}

		public void ActionsBeforeInsert(object parameters = null){}
		#endregion
	}
}
