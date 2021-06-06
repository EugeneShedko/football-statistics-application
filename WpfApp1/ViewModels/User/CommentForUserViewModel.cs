using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Models;
using WpfApp1.Navigation;
using WpfApp1.UnitOfWorkAndRepository;

namespace WpfApp1.ViewModels.User
{
	class CommentForUserViewModel : ViewModelBase, INavigationActions
	{
		#region Fields
		private NavigationManager _navigationManager;
		private NavigationManager _smallNavigationIfnoManager;
		private string currentUser;
		private string _message;
		private ObservableCollection<Comment> _historyMessage;
		#endregion
		#region Properties
		public ObservableCollection<Comment> HistoryMessage
		{
			get { return _historyMessage; }
			set { Set(ref _historyMessage, value); }
		}
		public string Message
		{
			get { return _message; }
			set { Set(ref _message, value); }
		}
		#endregion
		#region Constructors
		public CommentForUserViewModel(NavigationManager smallNavigationManager, NavigationManager navigationManager) : this()
		{
			_navigationManager = navigationManager;
			_smallNavigationIfnoManager = smallNavigationManager;
		}
		public CommentForUserViewModel()
		{
			SendMessage = new DelegateCommand(SendMessageCommand, CanSendMessageCommand);
		}
		#endregion
		#region Commands
		public ICommand SendMessage { get; set; }
		private bool CanSendMessageCommand(object parameters)
		{
			return true;
		}
		private void SendMessageCommand(object parameters)
		{
			using (UnitOfWork db = new UnitOfWork())
			{
				if (Message != null)
				{
					string userId = db.Users.GetAll().Where(t => t.LoginId == currentUser).Select(t => t.LoginId).First();
					Comment newComment = new Comment(userId, Convert.ToString(DateTime.Now), Message);
					db.Comments.Create(newComment);
					db.Save();
					HistoryMessage = new ObservableCollection<Comment>(db.Comments.GetAll());
					Message = null;
				}
			}
		}
		#endregion
		#region Methods
		public void ActionsBeforeClosing(){}

		public void ActionsBeforeInsert(object parameters = null)
		{
			currentUser = (string)parameters;
			using (UnitOfWork db = new UnitOfWork() )
			{
				HistoryMessage = new ObservableCollection<Comment>(db.Comments.GetAll());
			}
		}
		#endregion
	}
}
