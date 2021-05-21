using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Navigation;

namespace WpfApp1.ViewModels.User
{
	class ClubsForUserViewModel : ViewModelBase, INavigationActions
	{
		#region Fields
		private NavigationManager _navigationManager;
		private NavigationManager _smallNavigationInfoManager;
		//Добавить SelectedItem с нужным классом!!!! когда появится Model!!!!!! и вызывать окно, которое у меня есть для новостей
		#endregion
		#region Properties
		#endregion
		#region Constructors
		public ClubsForUserViewModel(NavigationManager smallNavigationInfoManager, NavigationManager navigationManager)
		{
			_navigationManager = navigationManager;
			_smallNavigationInfoManager = smallNavigationInfoManager;
		}
		public ClubsForUserViewModel() { }
		#endregion
		#region Methods
		public void ActionsBeforeClosing(){}

		public void ActionsBeforeInsert(object parameters = null){}
		#endregion
	}
}
