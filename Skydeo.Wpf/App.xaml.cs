using System.Windows;
using Ninject;
using Skydeo.Wpf.Configuration;

namespace Skydeo.Wpf
{
    public partial class App
    {
        private IKernel _iocKernel;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _iocKernel = new StandardKernel();
            _iocKernel.Load(new IocConfiguration());

            Current.MainWindow = _iocKernel.Get<MainWindow>();
            Current.MainWindow.Show();
        }
    }
}