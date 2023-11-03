using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CourseCompanion.ViewModels;
using CourseCompanion.Views;

namespace CourseCompanion.Views
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Page
    {
        public LogIn()
        {
            InitializeComponent();
            LogInViewModel viewModel = new LogInViewModel();
            this.DataContext = viewModel;
            var viewdata = (LogInViewModel)DataContext;

            if (viewdata.loginSuccess)
            {
                HomeView home = new HomeView();
                MainFrame.NavigationService.Navigate(home);
            }

        }
    }
}
