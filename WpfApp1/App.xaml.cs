using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Navigation;
using WpfApp1.ViewModels;
using WpfApp1.View;

namespace WpfApp1
{
	/// <summary>
	/// Логика взаимодействия для App.xaml
	/// </summary>
	public partial class App : Application
	{
        protected override void OnStartup(StartupEventArgs e)
        {
            var window = new MainWindow();
            var navigationManager = new NavigationManager(Dispatcher, window.MainWindowLoginOrRegister);

            navigationManager.Add<MainWindowLoginOrRegisterViewModel, MainWindowLoginOrRegister>(new MainWindowLoginOrRegisterViewModel(navigationManager),
                NavigationKeys.MainWindowLoginOrRegister);

            var viewModel = new MainWindowViewModel(navigationManager);
            window.DataContext = viewModel;
            window.Show();
        }
    }
}
