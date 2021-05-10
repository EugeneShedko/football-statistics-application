using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Navigation;

namespace WpfApp1.ViewModels
{
	internal class MainWindowViewModel : ViewModelBase
	{
		#region Fields
		private INavigationManager _navigationActions;
		#endregion
		#region Properties
		#endregion
		#region Constructors
		public MainWindowViewModel(INavigationManager navigationActions)
		{
			_navigationActions = navigationActions;
			_navigationActions.Insert(NavigationKeys.MainWindowLoginOrRegister);
		}
		public MainWindowViewModel() { }
		#endregion
		#region Commands

		//public ICommand ShowWindow { get;}

		//public bool CanShowWindowCommand(object parameter)
		//{
		//	return true;                                                  //Пример использования комманды
		//}
		//public void ShowWindowCommand(object parameter)
		//{
		//	Window s = new Window();
		//	s.Show();
		//}

		#endregion
	}
}
