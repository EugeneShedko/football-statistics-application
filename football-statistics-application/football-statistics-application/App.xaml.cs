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
using WpfApp1.ViewModels.Admin;
using WpfApp1.View.Admin;

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
            var navigationManager = new NavigationManager(Dispatcher, window.MainWindowLoginOrInformation, window);


            navigationManager.AddUserControl<MainWindowLoginOrRegisterViewModel, MainWindowLoginOrRegister>(new MainWindowLoginOrRegisterViewModel(navigationManager),
                NavigationKeys.MainWindowLoginOrRegister);
            navigationManager.AddUserControl<MainWindowForInformationViewModelUser, MainWindowForInformation>(new MainWindowForInformationViewModelUser(navigationManager),
                NavigationKeys.MainWindowForInformationUser);
            navigationManager.AddUserControl<MainWindowForInformationAdminViewModel, MainWindowForInformationAdmin>(new MainWindowForInformationAdminViewModel(navigationManager), NavigationKeys.MainWindowForInformationAdmin);

            var viewModel = new MainWindowViewModel(navigationManager);
            window.DataContext = viewModel;
            window.Show();
        }
    }
}
