using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CourseCompanion.DataAccess;
using CourseCompanion.ViewModels;
using SimpleInjector;
using SimpleInjector.Lifestyles;

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
