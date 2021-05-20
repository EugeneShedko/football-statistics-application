using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Navigation;

namespace WpfApp1.ViewModels.User
{
	class CommentForUserViewModel : ViewModelBase, INavigationActions
	{
		#region Fields
		private NavigationManager _navigationManager;
		private NavigationManager _smallNavigationIfnoManager;
		#endregion
		#region Properties
		#endregion
		#region Constructors
		public CommentForUserViewModel(NavigationManager smallNavigationManager, NavigationManager navigationManager)
		{
			_navigationManager = navigationManager;
			_smallNavigationIfnoManager = smallNavigationManager;
		}
		#endregion
		#region Commands
		#endregion
		#region Methods
		public void ActionsBeforeClosing(){}

		public void ActionsBeforeInsert(object parameters = null){}
		#endregion
	}
}
