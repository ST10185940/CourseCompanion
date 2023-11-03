using CourseCompanion.ViewModels;
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
using System.Windows.Shapes;

namespace CourseCompanion.Views
{
    /// <summary>
    /// Interaction logic for AddModule.xaml
    /// </summary>
    public partial class AddModule : Window
    {
        public AddModule()
        {
            InitializeComponent();
            AddModuleViewModel viewModel = new AddModuleViewModel();
            this.DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }
    }
}
