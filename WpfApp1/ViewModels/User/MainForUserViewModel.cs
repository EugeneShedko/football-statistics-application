using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Navigation;
using System.Collections.ObjectModel;
using System.Windows;
using System.Threading;

namespace WpfApp1.ViewModels.User
{
	#region Удалить
	class MainForUserViewModel : ViewModelBase, INavigationActions
	{
		private ObservableCollection<Mathes> match;
		private ObservableCollection<New> newses;
		public ObservableCollection<Mathes> Match
		{
			get { return match; }
			set { Set(ref match, value); }
		}
		public ObservableCollection<New> Newses
		{
			get { return newses; }
			set { Set(ref newses, value); }
		}
		public class New
		{
			public string Zaglavie { get; set; } = "Месси забил 100 голов!";
			public string Info { get; set; } = "Бавария сыграла вничью с Фрайбургом (2:2) в гостевом матче 33-го тура Бундеслиги.В середине первого тайма Роберт Левандовски реализовал пенальти и вывел мюнхенцев вперед.Фрайбург отыгрался через три минуты усилиями Мануэля Гюльде.";
			public New() { }
		}
		public class Mathes
		{
			public string Time { get; set;} = "01.01.2021 00:00:00:";
			public string Firstteam { get; set; } = "Батэ";                     //Вот удалить
			public string Firstgoal { get; set; } = "2";
			public string Secondgoal { get; set; } = "3";
			public string Secondteam { get; set; } = "Шахтер";
			public string Tur { get; set;} = "Тур 1";
			public Mathes() { }
		}
		#endregion
		#region Fields
		private NavigationManager _navigationManager;
		private NavigationManager _smallNavigationInfoManager;
		private New _selectedItem;    //Потом нужно будет заменить на нужный модел!!!
		ParametersForWindow parametersForNewsWindow = new ParametersForWindow(2);

		#endregion
		#region Properties
		public New SelectedItem
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
			Match = new ObservableCollection<Mathes>() { new Mathes(), new Mathes(), new Mathes(), new Mathes(), new Mathes(), new Mathes(),
				new Mathes(), new Mathes(), new Mathes(), new Mathes(), new Mathes(), new Mathes(),
			new Mathes(), new Mathes(), new Mathes(), new Mathes(), new Mathes(), new Mathes(),
			new Mathes(), new Mathes(), new Mathes(), new Mathes(), new Mathes(), new Mathes(),
			};  // и это
			Newses = new ObservableCollection<New>() { new New(), new New(), new New(), new New()};
		}
		#endregion
	}
}
