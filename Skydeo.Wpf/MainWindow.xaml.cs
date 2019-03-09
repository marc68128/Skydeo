using MahApps.Metro.Controls;
using Skydeo.Kernel;
using Skydeo.Wpf.Services;
using Skydeo.Wpf.Services.Contracts;
using Skydeo.Wpf.ViewModels;
using Skydeo.Wpf.Views;

namespace Skydeo.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            var navigationService = new NavigationService(this);

            KernelConfig.RegisterInstance<INavigationService>(navigationService);

            navigationService.GotoPage(new WelcomeView(new WelcomeViewModel()));
        }
    }
}
