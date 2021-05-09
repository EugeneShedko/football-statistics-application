using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Commands;

namespace WpfApp1.ViewModels
{
	internal class MainWindowViewModel : ViewModelBase
	{
		#region Constructors
		public MainWindowViewModel()
		{
			ShowWindow = new DelegateCommand(ShowWindowCommand, CanShowWindowCommand);
		}
		#endregion
		#region Properties
		private string _Login;
		public string Login
		{
			get { return _Login;}
			set 
			{
				Set(ref _Login, value);
			}
		}
		private string _Password;
		public string Password
		{
			get { return _Password; }
			set
			{
				Set(ref _Password, value);
			}
		}
		#endregion
		#region Commands

		public ICommand ShowWindow { get;}

		public bool CanShowWindowCommand(object parameter)
		{
			return true;
		}
		public void ShowWindowCommand(object parameter)
		{
			Window s = new Window();
			s.Show();
		}
		
		#endregion
	}
}
