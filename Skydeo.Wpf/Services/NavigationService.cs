using System.Collections.Generic;
using System.Windows.Controls;
using Skydeo.Wpf.Services.Contracts;

namespace Skydeo.Wpf.Services
{
    public class NavigationService : INavigationService
    {
        private readonly MainWindow _mainWindow;
        private readonly Stack<Page> _pageStack;
        private Page _pageCurrent;

        public NavigationService(MainWindow mainWindow)
        {
            this._mainWindow = mainWindow;
            _pageStack = new Stack<Page>();
        }

        public void GotoPage(Page page)
        {
            if (_pageCurrent != null)
                _pageStack.Push(_pageCurrent);
            SwitchDisplayTo(page);
        }

        public void GoBack()
        {
            Page page = _pageStack.Pop();
            SwitchDisplayTo(page);
        }

        private void SwitchDisplayTo(Page page)
        {
            _mainWindow.Content = page;
            _pageCurrent = page;
        }
    }
}