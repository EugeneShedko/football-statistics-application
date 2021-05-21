using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Navigation;

namespace WpfApp1.ViewModels.User
{
	class UserProfileViewModel : ViewModelBase, INavigationActions
	{
		#region Fields
		private NavigationManager _navigationManager;
		private NavigationManager _smallNavigationInfoManager;
		private ObservableCollection<int> _age;
		#endregion
		#region Properties
		#endregion
		public ObservableCollection<int> Age
		{
			get { return _age;}
			set { Set(ref _age, value);}
		}
		#region Constructors
		public UserProfileViewModel(NavigationManager smallNaviagationInfoMnager, NavigationManager navigationManager)
		{
			_navigationManager = navigationManager;
			_smallNavigationInfoManager = smallNaviagationInfoMnager;
		}
		#endregion
		#region Methods
		public void ActionsBeforeClosing()
		{}
		public void ActionsBeforeInsert(object parameters = null)
		{
			CreateAgeCollection();
		}
		private void CreateAgeCollection()
		{
			Age = new ObservableCollection<int>();
			for (int i = 10; i <= 60; i++)
				Age.Add(i);
		}
	}
	#endregion
}
