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
    /// Interaction logic for ChooseView.xaml
    /// </summary>
    public partial class ChooseView : Page
    {
        public ChooseView()
        {
            InitializeComponent();
        }

        public void Register(object sender , RoutedEventArgs e)
        {
            RegisterView register = new RegisterView();
            MainFrame.NavigationService.Navigate(register);
        }

        public void LogIn(object sender, RoutedEventArgs e) 
        {
            LogIn login = new LogIn();
            MainFrame.NavigationService.Navigate(login);
        }
    }
}
