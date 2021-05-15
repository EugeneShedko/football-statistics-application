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
		private NavigationManager _smallNavigationManager;
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
		public void ActionsBeforeInsert()
		{
			//Достаем из коллекции объект данного типа, преобразеуем его и берем от него ContentControl
			_smallNavigationManager = new NavigationManager(_navigationManager._Dispatcher, ((MainWindowForInformation)_navigationManager.ViewTypesByViewModelTypes[this.GetType()]).ForInformation);
			//Регистрируем все страницы, которые возможно поместить в выбранный ContentControl
			_smallNavigationManager.Add<MainForUserViewModel, MainForUser>(new MainForUserViewModel(_smallNavigationManager, _navigationManager), NavigationKeys.MainForUser);
			//Вызываем функцию для вставки новой страницы
			_smallNavigationManager.Insert(NavigationKeys.MainForUser);

		}
		#endregion
	}
}
