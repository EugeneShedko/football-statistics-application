using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.UnitOfWorkAndRepository
{
	class UnitOfWork : IDisposable
	{
		#region Fields
		private UserContext db = new UserContext();
		private AssistRepository _assistRepository;
		private BookedTicketRepository _bookedTicketRepository;
		private CommentRepository _commentRepository;
		private GameRepository _gameRepository;
		private GoalRepositorycs _goalRepositorycs;
		private NewsRepository _newsRepository;
		private PlayerRepositorycs _playerRepositorycs;
		private TeamRepository _teamRepository;
		private TicketRepository _ticketRepository;
		private UserRepository _userRepository;
		private bool disposed = false;
		#endregion
		#region Properties

		public AssistRepository Assists
		{
			get
			{
				if (_assistRepository == null)
					_assistRepository = new AssistRepository(db);
				return _assistRepository;
			}
		}
		public BookedTicketRepository BookedTickets
		{
			get
			{
				if (_bookedTicketRepository == null)
					_bookedTicketRepository = new BookedTicketRepository(db);
				return _bookedTicketRepository;
			}
		}
		public CommentRepository Comments
		{
			get
			{
				if (_commentRepository == null)
					_commentRepository = new CommentRepository(db);
				return _commentRepository;
			}
		}
		public GameRepository Games
		{
			get
			{
				if (_gameRepository == null)
					_gameRepository = new GameRepository(db);
				return _gameRepository;
			}
		}
		public GoalRepositorycs Goals
		{
			get
			{
				if (_goalRepositorycs == null)
					_goalRepositorycs = new GoalRepositorycs(db);
				return _goalRepositorycs;
			}
		}
		public NewsRepository Newses
		{
			get
			{
				if (_newsRepository == null)
					_newsRepository = new NewsRepository(db);
				return _newsRepository;
			}
		}
		public PlayerRepositorycs Players
		{
			get
			{
				if (_playerRepositorycs == null)
					_playerRepositorycs = new PlayerRepositorycs(db);
				return _playerRepositorycs;
			}
		}
		public TeamRepository Teams
		{
			get
			{
				if (_teamRepository == null)
					_teamRepository = new TeamRepository(db);
				return _teamRepository;
			}
		}
		public TicketRepository Tickets
		{
			get
			{
				if (_ticketRepository == null)
					_ticketRepository = new TicketRepository(db);
				return _ticketRepository;
			}
		}
		public UserRepository Users
		{
			get
			{
				if (_userRepository == null)
					_userRepository = new UserRepository(db);
				return _userRepository;
			}
		}
		#endregion
		#region Methods
		public void Save()
		{
			db.SaveChanges();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					db.Dispose();
				}
				this.disposed = true;
			}
		}
		#endregion
	}
}
