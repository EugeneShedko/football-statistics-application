using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;
using WpfApp1.Navigation;
using WpfApp1.UnitOfWorkAndRepository;

namespace WpfApp1.ViewModels.Admin
{
	class MathesForAdminViewModel : ViewModelBase, INavigationActions
	{
		#region Fields
		private NavigationManager _navigationManager;
		private NavigationManager _smallNavigationInfoManager;
		private ObservableCollection<Game> _games;
		#endregion
		#region Properties
		public ObservableCollection<Game> Games
		{
			get { return _games; }
			set { Set(ref _games, value);}
		}
		#endregion
		#region Constructors
		public MathesForAdminViewModel(NavigationManager smallNavigationInfoMnager, NavigationManager navigationManager)
		{
			_navigationManager = navigationManager;
			_smallNavigationInfoManager = smallNavigationInfoMnager;
		}
		public MathesForAdminViewModel() { }
		#endregion
		#region Methods
		public void ActionsBeforeClosing(){}

		public void ActionsBeforeInsert(object parameters = null)
		{
			using (UnitOfWork db = new UnitOfWork())
			{
				Games = new ObservableCollection<Game>(db.Games.GetAll());
			}
		}
		#endregion
	}
}
