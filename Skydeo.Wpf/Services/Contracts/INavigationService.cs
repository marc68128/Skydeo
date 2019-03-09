using System.Windows.Controls;

namespace Skydeo.Wpf.Services.Contracts
{
    public interface INavigationService
    {
        void GotoPage(Page page);
        void GoBack();
    }
}