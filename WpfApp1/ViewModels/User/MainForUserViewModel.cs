using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Navigation;
using System.Collections.ObjectModel;
using System.Windows;
using System.Threading;
using WpfApp1.UnitOfWorkAndRepository;
using WpfApp1.Models;

namespace WpfApp1.ViewModels.User
{
	class MainForUserViewModel : ViewModelBase, INavigationActions
	{
		#region Fields
		private NavigationManager _navigationManager;
		private NavigationManager _smallNavigationInfoManager;
		private News _selectedItem;    
		ParametersForWindow parametersForNewsWindow = new ParametersForWindow(2);

		#endregion
		#region Properties
		public ObservableCollection<Game> Games { get; set; }
		public ObservableCollection<News> News { get; set; }
		public News SelectedItem
		{
			get { return _selectedItem;}
			set
			{
				Set(ref _selectedItem, value);
				_smallNavigationInfoManager.Show(NavigationKeys.NewsForUser, SelectedItem);
			}
		}
		#endregion
		#region Constructors
		public MainForUserViewModel(NavigationManager smallNavigationManager, NavigationManager navigationManager)
		{
			_smallNavigationInfoManager = smallNavigationManager;
			_navigationManager = navigationManager;
		}
		public MainForUserViewModel() { }
		#endregion
		#region Methods
		public void ActionsBeforeClosing(){}
		public void ActionsBeforeInsert(object parameters = null)
		{
			using (UnitOfWork db = new UnitOfWork() )
			{
				Games = new ObservableCollection<Game>(db.Games.GetAll());
				News = new ObservableCollection<News>(db.Newses.GetAll().OrderByDescending(t=>t.Id));
			}
		}
		#endregion
	}
}
