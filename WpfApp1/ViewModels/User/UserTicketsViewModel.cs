using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Models;
using WpfApp1.Navigation;
using WpfApp1.UnitOfWorkAndRepository;

namespace WpfApp1.ViewModels.User
{
	class UserTicketsViewModel : ViewModelBase, INavigationActions
	{
		#region Fields
		private NavigationManager _navigationManager;
		private NavigationManager _smallNavigationInfoManager;
		private ObservableCollection<BookedTicket> _bookedTicket;
		private string currentuser;
		#endregion
		#region Properties
		public ObservableCollection<BookedTicket> BookedTicket 
		{ get { return _bookedTicket; }
			set { Set(ref _bookedTicket, value); }
		}
		#endregion
		#region Constructors
		public UserTicketsViewModel(NavigationManager smallNavigationInfoManger, NavigationManager navigationManager) : this()
		{
			_navigationManager = navigationManager;
			_smallNavigationInfoManager = smallNavigationInfoManger;
		}
		public UserTicketsViewModel() 
		{
			Cancel = new DelegateCommand(CancelCommand, CanCancelCommand);
		}
		#endregion
		#region Commands
		public ICommand Cancel { get; set; }
		private bool CanCancelCommand(object parameter)
		{
			return true;
		}
		private void CancelCommand(object parameter)
		{
			using (UnitOfWork db = new UnitOfWork())
			{
				int id = ((BookedTicket)parameter).Id;
				db.BookedTickets.Delete(id);
				db.Save();
				BookedTicket = new ObservableCollection<BookedTicket>(db.BookedTickets.GetAll().Where(t => t.UserId == currentuser));
			}
		}
		#endregion
		#region Methods
		public void ActionsBeforeClosing() {}
		public void ActionsBeforeInsert(object parameters = null)
		{
			currentuser = (string)parameters;
			using (UnitOfWork db = new UnitOfWork())
			{
				BookedTicket = new ObservableCollection<BookedTicket>(db.BookedTickets.GetAll().Where(t=>t.UserId == currentuser));
			}
		}
		#endregion
	}
}
