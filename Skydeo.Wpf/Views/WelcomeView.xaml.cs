using System.Windows.Controls;
using Skydeo.Wpf.ViewModels;

namespace Skydeo.Wpf.Views
{
    /// <summary>
    /// Logique d'interaction pour WelcomeView.xaml
    /// </summary>
    public partial class WelcomeView : Page
    {
        public WelcomeView(WelcomeViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}