using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Skydeo.ViewModels.Modals;
using Skydeo.ViewModels.Properties;

namespace Skydeo.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<BaseViewModel> NavigateEvent;
        public event EventHandler<BaseModalViewModel> ModalEvent;


        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected virtual void Navigate(BaseViewModel viewModel)
        {
            NavigateEvent?.Invoke(this, viewModel);
        }
        protected virtual void DisplayModal(BaseModalViewModel viewModel)
        {
            ModalEvent?.Invoke(this, viewModel);
        }
    }
}