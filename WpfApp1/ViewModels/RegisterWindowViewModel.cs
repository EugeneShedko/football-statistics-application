using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Navigation;

namespace WpfApp1.ViewModels
{
	class RegisterWindowViewModel : ViewModelBase, INavigationActions
	{
		#region Fields
		private string _FamilyName;
		private string _Name;
		private string _Login;
		private string _Password;
		private INavigationManager _navigationManager;
		#endregion
		#region Properties
		public string FamilyName
		{
			get { return _FamilyName; }
			set { Set(ref _FamilyName, value); }
		}
		public string Name
		{
			get { return _Name; }
			set { Set(ref _Name, value); }
		}
		public string Login
		{
			get { return _Login; }
			set { Set(ref _Login, value); }
		}
		public string Password
		{
			get { return _Password; }
			set { Set(ref _Password, value); }
		}
		#endregion
		#region Constructors
		public RegisterWindowViewModel(INavigationManager navigationManager)
		{
			_navigationManager = navigationManager;
		}
		#endregion
		#region Methods
		public void ActionsBeforeInsert(){}
		public void ActionsBeforeClosing(){}
		#endregion
	}
}
