using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Navigation;
using WpfApp1.View;
using WpfApp1.View.User;
using WpfApp1.ViewModels.User;

namespace WpfApp1.ViewModels
{
	class MainWindowForInformationViewModelUser : ViewModelBase, INavigationActions
	{
		#region Fields
		private NavigationManager _navigationManager;
		private NavigationManager _smallNavigationInfoManager;
		#endregion
		#region Constructors
		public MainWindowForInformationViewModelUser(NavigationManager navigationManager)
		{
			_navigationManager = navigationManager;
		}
		public MainWindowForInformationViewModelUser() { }
		#endregion
		#region Methods
		public void ActionsBeforeClosing(){}
		public void ActionsBeforeInsert(object parameters = null)
		{
			//Достаем из коллекции объект данного типа, преобразеуем его и берем от него ContentControl
			_smallNavigationInfoManager = new NavigationManager(_navigationManager._Dispatcher, ((MainWindowForInformation)_navigationManager.ViewTypesByViewModelTypes[this.GetType()]).ForInformation, _navigationManager.Mainwindow);
			//Регистрируем все страницы, которые возможно поместить и использовать в рамках выбранного ContentControl
			_smallNavigationInfoManager.AddUserControl<MainForUserViewModel, MainForUser>(new MainForUserViewModel(_smallNavigationInfoManager, _navigationManager), NavigationKeys.MainForUser);
			_smallNavigationInfoManager.AddWindow<NewsForUserViewModel, NewsForUser>(new NewsForUserViewModel(_smallNavigationInfoManager, _navigationManager), NavigationKeys.NewsForUser);
			//Вызываем функцию для вставки новой страницы
			_smallNavigationInfoManager.Insert(NavigationKeys.MainForUser);
		}
		#endregion
	}
}
