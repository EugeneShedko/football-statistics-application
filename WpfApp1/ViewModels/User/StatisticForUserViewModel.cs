using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Navigation;

namespace WpfApp1.ViewModels.User
{
	class StatisticForUserViewModel : ViewModelBase, INavigationActions
	{
		#region Fields
		private NavigationManager _navigationManager;
		private NavigationManager _smallNavigationInfoManager;
		#endregion
		#region Properties
		public StatisticForUserViewModel(NavigationManager smallNavigationManager, NavigationManager navigationManager)
		{
			_smallNavigationInfoManager = smallNavigationManager;
			_navigationManager = navigationManager;
		}
		public StatisticForUserViewModel() { }
		#endregion
		#region Constructors
		#endregion
		#region Methods
		public void ActionsBeforeClosing() {}

		public void ActionsBeforeInsert(object parameters = null){}
		#endregion
}
}
