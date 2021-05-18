using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace WpfApp1.Navigation
{
	class NavigationManager : INavigationManager
	{
		#region Fields
		public Window Mainwindow { get; set;}
		public Dispatcher _Dispatcher { get;}    //Здесь были изменения
		public ContentControl _frameControl { get; set; }
		private  IDictionary<string, object> _viewModelsByKey = new Dictionary<string, object>();
		public IDictionary<Type, object> ViewTypesByViewModelTypes { get; set; } = new Dictionary<Type, object>();
		#endregion

		#region Properties
		#endregion
		#region Constructors

		public NavigationManager(Dispatcher dispatcher, ContentControl frameControl, Window mainwindow)
		{
			if (dispatcher == null)
				throw new ArgumentNullException("dispathcer");
			if (frameControl == null)
				throw new ArgumentNullException("frameControl");
			if (mainwindow == null)
				throw new ArgumentNullException("mainwindow");
			_Dispatcher = dispatcher;
			_frameControl = frameControl;
			Mainwindow = mainwindow;
		}


		#endregion
		#region Methods

		public void AddUserControl<TViewModel, TView>(TViewModel viewModel, string navigationKey) where TView : new()
		{
			if (viewModel == null)
				throw new ArgumentNullException("viewModel");
			if (navigationKey == null)
				throw new ArgumentNullException("navigationKey");

			_viewModelsByKey[navigationKey] = viewModel;
			ViewTypesByViewModelTypes[viewModel.GetType()] = new TView();
		}
		public void AddWindow<TViewModel, Tview>(TViewModel viewModel, string navigationKey)
		{
			if (viewModel == null)
				throw new ArgumentNullException("viewModel");
			if (navigationKey == null)
				throw new ArgumentNullException("navigationKey");
			_viewModelsByKey[navigationKey] = viewModel;
			ViewTypesByViewModelTypes[viewModel.GetType()] = typeof(Tview);
		}

		public void Show(string navigationKey, object parameters)
		{
			try
			{
				object viewModel = GetViewModel(navigationKey);
				BeforeInsert(viewModel, parameters);
				var type = (Type)ViewTypesByViewModelTypes[viewModel.GetType()];
				var view = (Window)Activator.CreateInstance(type);
				view.DataContext = viewModel;
				view.Owner = Mainwindow;
				view.Show();
			}
			catch (Exception) { }
		}
		public void Insert(string navigationKey, object parameters = null)
		{
			InvokeInMainThread(() =>
			{
				// Нужен ли метод InvokeNavigationFrom
				object viewModel = GetViewModel(navigationKey);
				BeforeInsert(viewModel, parameters);

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
		private void BeforeInsert(object viewModel, object parameters)
		{
			var insertviewmodel = viewModel as INavigationActions;
			if (insertviewmodel == null)
				return;
			insertviewmodel.ActionsBeforeInsert(parameters);
		}
		#endregion
	}
}
