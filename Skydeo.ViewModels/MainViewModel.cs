using Ninject;
using Skydeo.ViewModels.Modals;

namespace Skydeo.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IKernel _kernel;

        private BaseViewModel _viewModel;
        private BaseModalViewModel _modalViewModel;

        public MainViewModel(IKernel kernel)
        {
            _kernel = kernel;
            SetupViewModel(_kernel.Get<WelcomeViewModel>());
        }

        private void SetupViewModel(BaseViewModel viewModel)
        {
            ViewModel = viewModel;
            ViewModel.NavigateEvent += (sender, model) => SetupViewModel(model);
            ViewModel.ModalEvent += (sender, model) => SetupModalViewModel(model);
        }

        private void SetupModalViewModel(BaseModalViewModel modalViewModel)
        {
            ModalViewModel = modalViewModel;

            if (modalViewModel != null)
                modalViewModel.ModalEvent += (sender, model) => SetupModalViewModel(model);
        }

        public BaseViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                OnPropertyChanged();
            }
        }

        public BaseModalViewModel ModalViewModel
        {
            get => _modalViewModel;
            set
            {
                _modalViewModel = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ShowModal));
            }
        }
        public bool ShowModal => ModalViewModel != null;
    }
}