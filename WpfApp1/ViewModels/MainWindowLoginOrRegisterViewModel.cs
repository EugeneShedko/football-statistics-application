using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Navigation;

namespace WpfApp1.ViewModels
{
	class MainWindowLoginOrRegisterViewModel : ViewModelBase, INavigationActions
	{
		private INavigationManager _navigationManager;
		public MainWindowLoginOrRegisterViewModel(INavigationManager navigationManager)
		{
			_navigationManager = navigationManager;
		}

		public void ActionsBeforeClosing(){}

		public void ActionsBeforeInsert() {}
	}
}
