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
		private NavigationManager _smallnavigationManager;
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

		public void ActionsBeforeInsert()
		{
			//Достаем из коллекции объект данного типа, преобразеуем его и берем от него ContentControl
			_smallnavigationManager = new NavigationManager(_navigationManager._Dispatcher, ((MainWindowLoginOrRegister)_navigationManager.ViewTypesByViewModelTypes[this.GetType()]).WindowLoginOrRegister);
			//Регистрируем все страницы, которые возможно поместить в выбранный ContentControl
			_smallnavigationManager.Add<LoginWindowViewModel, LoginWindow>(new LoginWindowViewModel(_smallnavigationManager, _navigationManager), NavigationKeys.LoginWindow);
			_smallnavigationManager.Add <RegisterWindowViewModel, RegisterWindow>(new RegisterWindowViewModel(_smallnavigationManager, _navigationManager), NavigationKeys.RegisterWindow);
			//Вызываем функцию для вставки новой страницы
			_smallnavigationManager.Insert(NavigationKeys.LoginWindow);
		}
		#endregion
	}
}
