using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace WpfApp1.Navigation
{
	class NavigationManager : INavigationManager
	{
		#region Fields
		public Dispatcher _Dispatcher { get;}    //Здесь были изменения
		public ContentControl _frameControl { get; set; }
		private  IDictionary<string, object> _viewModelsByKey = new Dictionary<string, object>();
		public IDictionary<Type, object> ViewTypesByViewModelTypes { get; set; } = new Dictionary<Type, object>();
		#endregion

		#region Properties
		#endregion

		#region Constructors

		public NavigationManager(Dispatcher dispatcher, ContentControl frameControl)
		{
			if (dispatcher == null)
				throw new ArgumentNullException("dispathcer");
			if (frameControl == null)
				throw new ArgumentNullException("frameControl");
			_Dispatcher = dispatcher;
			_frameControl = frameControl;
		}


		#endregion
		#region Methods

		public void Add<TViewModel, TView>(TViewModel viewModel, string navigationKey) where TView : new()
		{
			if (viewModel == null)
				throw new ArgumentNullException("viewModel");
			if (navigationKey == null)
				throw new ArgumentNullException("navigationKey");

			_viewModelsByKey[navigationKey] = viewModel;
			ViewTypesByViewModelTypes[viewModel.GetType()] = new TView();
		}

		public void Insert(string navigationKey)
		{
			InvokeInMainThread(() =>
			{
				// Нужен ли метод InvokeNavigationFrom
				object viewModel = GetViewModel(navigationKey);
				BeforeInsert(viewModel);

				var view = CreateNewView(viewModel);
				_frameControl.Content = view;
			});
		}

		private FrameworkElement CreateNewView(object viewModel)
		{
			var view = (FrameworkElement)ViewTypesByViewModelTypes[viewModel.GetType()];
			view.DataContext = viewModel;
			return view;
		}
		private void InvokeInMainThread(Action execute)
		{
			_Dispatcher.Invoke(execute);
		}
		private object GetViewModel(string navigationKey)
		{
			return _viewModelsByKey[navigationKey];
		}
		private void BeforeInsert(object viewModel)
		{
			var insertviewmodel = viewModel as INavigationActions;
			if (insertviewmodel == null)
				return;
			insertviewmodel.ActionsBeforeInsert();
		}
		#endregion
	}
}
