using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Navigation;
using static WpfApp1.ViewModels.User.MainForUserViewModel; //Потом нужно будет удалить

namespace WpfApp1.ViewModels.User
{
	class NewsForUserViewModel : ViewModelBase, INavigationActions
	{
		#region Fields
		private NavigationManager _navigationManager;
		private NavigationManager _smallNavigationInfoManager;
		private string _heading;
		private string _text;
		#endregion
		#region Properties
		public string Heading
		{
			get { return _heading;}
			set { Set(ref _heading, value); }
		}
		public string Text
		{
			get { return _text;}
			set { Set(ref _text, value); }
		}
		#endregion
		#region Constructors
		public NewsForUserViewModel(NavigationManager smallNavigationManager, NavigationManager navigationManager)
		{
			_smallNavigationInfoManager = smallNavigationManager;
			_navigationManager = navigationManager;
		}
		public NewsForUserViewModel() { }
		#endregion
		#region Methods
		public void ActionsBeforeClosing()
		{

		}

		public void ActionsBeforeInsert(object parameters = null)
		{
			_heading = ((New)parameters).Zaglavie;
			_text = ((New)parameters).Info;
		}
		#endregion
	}
}
