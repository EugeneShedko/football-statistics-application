using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Navigation;
using WpfApp1.View;
using WpfApp1.ViewModels;

namespace WpfApp1.ViewModels
{
	class MainWindowLoginOrRegisterViewModel : ViewModelBase, INavigationActions
	{
		#region Fields
		private NavigationManager _navigationManager;                   //Зачем мне этот интерфейс может его снести?
		private NavigationManager _smallnavigationLoginManager;
		#endregion
		#region Constructors
		public MainWindowLoginOrRegisterViewModel(NavigationManager navigationManager)
		{
			_navigationManager = navigationManager;
		}
		public MainWindowLoginOrRegisterViewModel() { }
		#endregion
		#region Methods
		public void ActionsBeforeClosing(){}

		public void ActionsBeforeInsert(object parameters = null)
		{
			//Достаем из коллекции объект данного типа, преобразеуем его и берем от него ContentControl
			_smallnavigationLoginManager = new NavigationManager(_navigationManager._Dispatcher, ((MainWindowLoginOrRegister)_navigationManager.ViewTypesByViewModelTypes[this.GetType()]).WindowLoginOrRegister, _navigationManager.Mainwindow);
			//Регистрируем все страницы, которые возможно поместить в выбранный ContentControl
			_smallnavigationLoginManager.AddUserControl<LoginWindowViewModel, LoginWindow>(new LoginWindowViewModel(_smallnavigationLoginManager, _navigationManager), NavigationKeys.LoginWindow);
			_smallnavigationLoginManager.AddUserControl<RegisterWindowViewModel, RegisterWindow>(new RegisterWindowViewModel(_smallnavigationLoginManager, _navigationManager), NavigationKeys.RegisterWindow);
			//Вызываем функцию для вставки новой страницы
			_smallnavigationLoginManager.Insert(NavigationKeys.LoginWindow);
		}
		#endregion
	}
}
