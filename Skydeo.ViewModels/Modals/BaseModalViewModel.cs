using System.Windows.Input;
using Skydeo.ViewModels.Commands;

namespace Skydeo.ViewModels.Modals
{
    public class BaseModalViewModel : BaseViewModel
    {
        public BaseModalViewModel()
        {
            InitCommand();
        }

        public ICommand CloseModalCommand { get; protected set; }

        private void InitCommand()
        {
            CloseModalCommand = new ActionCommand(_ =>
            {
                DisplayModal(null);
            });
        }
    }
}