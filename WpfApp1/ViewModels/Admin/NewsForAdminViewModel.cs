using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Models;
using WpfApp1.Navigation;
using WpfApp1.UnitOfWorkAndRepository;

namespace WpfApp1.ViewModels.Admin
{
	class NewsForAdminViewModel : ViewModelBase, INavigationActions, IDataErrorInfo
	{
		#region Fields
		private NavigationManager _navigationManager;
		private NavigationManager _smallNavigationInfoManager;
		private string _insertHeader;
		private string _insertText;
		private string _deleteNewsId;
		private string _searchNewsId;
		private ObservableCollection<News> _news;
		Dictionary<string, string> errors;
		public string this[string propertyName] => errors.ContainsKey(propertyName) ? errors[propertyName] : null;
		public string Error => throw new NotImplementedException();
		#endregion
		#region Properties
		public string SearchNewsId
		{
			get { return _searchNewsId; }
			set
			{
				Set(ref _searchNewsId, value);
				string str = @"[0-9]";
				if (SearchNewsId != null)
				{
					if (!Regex.IsMatch(SearchNewsId, str))
					{
						errors["SearchNewsId"] = "Неверный формат данных, возможны только цифры";
					}
					else
					{
						errors["SearchNewsId"] = null;
					}
				}
			}
		}
		public string DeleteNewsId
		{
			get { return _deleteNewsId; }
			set
			{
				Set(ref _deleteNewsId, value);
				string str = @"[0-9]";
				if (DeleteNewsId != null)
				{
					if (!Regex.IsMatch(DeleteNewsId, str))
					{
						errors["DeleteNewsId"] = "Неверный формат данных, возможны только цифры";
					}
					else
					{
						errors["DeleteNewsId"] = null;
					}
				}
			}
		}
		public string InsertHeader
		{
			get { return _insertHeader; }
			set 
			{
				Set(ref _insertHeader, value);
			}
		}
		public string InsertText
		{
			get { return _insertText; }
			set
			{
				Set(ref _insertText, value);
			}
		}
		public ObservableCollection<News> UserNews
		{
			get { return _news; }
			set { Set(ref _news, value); }
		}
		#endregion
		#region Constructors
		public NewsForAdminViewModel(NavigationManager smallNavigationInfoManager, NavigationManager navigationManager) : this()
		{
			_navigationManager = navigationManager;
			_smallNavigationInfoManager = smallNavigationInfoManager;
		}
		public NewsForAdminViewModel()
		{
			errors = new Dictionary<string, string>();
			errors["DeleteNewsId"] = null;
			errors["SearchNewsId"] = null;
			CreateNews = new DelegateCommand(CreateGamesCommand, CanCreateGamesCommand);
			DeleteNews = new DelegateCommand(DeleteNewsCommand, CanDeleteNewsCommamd);
			SearchNews = new DelegateCommand(SearchNewsCommand, CanSearchNewsCommand);
			SaveChanges = new DelegateCommand(SaveChangesCommand, CanSaveChangesCommand);

		}
		#endregion
		#region Commands
		public ICommand CreateNews { get; set; }
		public ICommand DeleteNews { get; set; }
		public ICommand SearchNews { get; set; }
		public ICommand SaveChanges { get; set; }
		//------------------------------------------------------------
		private bool CanSaveChangesCommand(object parameters)
		{
			return true;
		}
		private void SaveChangesCommand(object parameters)
		{
			using (UnitOfWork db = new UnitOfWork())
			{
				for (int i = 0; i < UserNews.Count; i++)
				{
					db.Newses.Update(UserNews[i]);
					db.Save();
					UserNews = new ObservableCollection<News>(db.Newses.GetAll().OrderByDescending(p => p.Id));
				}
				MessageBox.Show("Данные успешно сохранены!");
			}
		}
		//------------------------------------------------------------
		//------------------------------------------------------------
		public bool CanSearchNewsCommand(object parameter)
		{
			if (errors["SearchNewsId"] == null && SearchNewsId != null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public void SearchNewsCommand(object parameter)
		{
			using (UnitOfWork db = new UnitOfWork())
			{
				News searchNews = db.Newses.GetAll().Where(t => t.Id == Convert.ToInt32(SearchNewsId)).First();
				if (searchNews != null)
				{
					UserNews = new ObservableCollection<News>() { searchNews };
				}
				else
				{
					MessageBox.Show("Не удалось новость с указанным Id");
				}
				SearchNewsId = null;
			}
		}
		//-----------------------------------------------------------
		//----------------------------------------------------------
		private bool CanDeleteNewsCommamd(object parameters)
		{
			if (errors["DeleteNewsId"] == null && DeleteNewsId != null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		private void DeleteNewsCommand(object parameters)
		{
			using (UnitOfWork db = new UnitOfWork())
			{
				if (db.Newses.Delete(Convert.ToInt32(DeleteNewsId)))
				{
					db.Save();
					UserNews = new ObservableCollection<News>(db.Newses.GetAll().OrderByDescending(t=>t.Id));
					MessageBox.Show("Данные успешно удалены!");
				}
				else
				{
					MessageBox.Show("Не удалось найти новость с указанным Id");
				}
				DeleteNewsId = null;
			}
		}
		//---------------------------------------------------------
		//---------------------------------------------------------
		private bool CanCreateGamesCommand(object parameter)
		{
			if (InsertHeader !=null && InsertText !=null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		private void CreateGamesCommand(object parameter)
		{
			using (UnitOfWork db = new UnitOfWork())
			{
				try
				{
					News newNews = new News(InsertHeader, InsertText);
					db.Newses.Create(newNews);
					db.Save();
					UserNews = new ObservableCollection<News>(db.Newses.GetAll().OrderByDescending(t=>t.Id));
					MessageBox.Show("Новость добавлена!");
					InsertHeader = null;
					InsertText = null;
				}
				catch { }
			}
		}
		//---------------------------------------------------------
		#endregion
		#region Methods
		public void ActionsBeforeClosing(){}

		public void ActionsBeforeInsert(object parameters = null)
		{
			using (UnitOfWork db = new UnitOfWork())
			{
				UserNews = new ObservableCollection<News>(db.Newses.GetAll().OrderByDescending(p => p.Id));
			}
		}
		#endregion
	}
}
