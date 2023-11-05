using CourseCompanion.DataAccess;
using CourseCompanion.ViewModels;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System.Windows;

namespace CourseCompanion
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Container? container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.Register<UserID_Dependency>(Lifestyle.Singleton);

            container.Register<HomeViewModel>();
            container.Register<AddModuleViewModel>();
            container.Register<RegisterViewModel>();
            container.Register<LogInViewModel>();

            container.Verify();
        }
    }
}
