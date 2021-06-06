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

namespace WpfApp1.ViewModels.Admin
{
	class BookedTicketsForAdminViewModel : ViewModelBase, INavigationActions
	{
		#region Fields
		private NavigationManager _navigationManager;
		private NavigationManager _smallNavugationInfoManager;
		private ObservableCollection<BookedTicket> _bookedTickets;
		#endregion
		#region Properties
		public ObservableCollection<BookedTicket> BookedTickets 
		{
			get { return _bookedTickets; }
			set { Set(ref _bookedTickets, value); }
		}
		#endregion
		#region Constructors
		public BookedTicketsForAdminViewModel(NavigationManager smallNaviagtionInfoManager, NavigationManager navigationManager) : this()
		{
			_navigationManager = navigationManager;
			_smallNavugationInfoManager = smallNaviagtionInfoManager;
			SaveChanges = new DelegateCommand(SaveChangesCommand, CanSaveChangesCommand);
		}
		public BookedTicketsForAdminViewModel() {}
		#endregion
		#region Commands
		public ICommand SaveChanges { get; set; }
		private bool CanSaveChangesCommand(object parameters)
		{
			return true;
		}
		private void SaveChangesCommand(object parameters)
		{
			using (UnitOfWork db = new UnitOfWork())
			{
				for (int i = 0; i < BookedTickets.Count; i++)
				{
					db.BookedTickets.Update(BookedTickets[i]);
				}
					db.Save();
				MessageBox.Show("Данные успешно сохранены!");
			}
		}
		#endregion
		#region Methods
		public void ActionsBeforeClosing(){}

		public void ActionsBeforeInsert(object parameters = null)
		{
			using (UnitOfWork db = new UnitOfWork())
			{
				BookedTickets = new ObservableCollection<BookedTicket>(db.BookedTickets.GetAll());
			}
		}
		#endregion
	}
}
