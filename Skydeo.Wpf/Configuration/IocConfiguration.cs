using Ninject.Modules;
using Skydeo.Application.UseCases.GetDriveInfos;
using Skydeo.Infrastructure;
using Skydeo.Infrastructure.Contracts;
using Skydeo.ViewModels;

namespace Skydeo.Wpf.Configuration
{
    public class IocConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<IFileService>().To<FileService>().InSingletonScope();
            Bind<ISerializationService>().To<SerializationService>().InSingletonScope();

            Bind<IGetDriveInfosUseCase>().To<GetDriveInfosUseCase>().InSingletonScope();

            Bind<MainViewModel>().ToSelf().InTransientScope();

            Bind<WelcomeViewModel>().ToSelf().InTransientScope();
            Bind<DebriefViewModel>().ToSelf().InTransientScope();
        }
    }
}