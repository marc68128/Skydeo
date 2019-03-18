using MahApps.Metro.Controls;
using Skydeo.ViewModels;

namespace Skydeo.Wpf
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
