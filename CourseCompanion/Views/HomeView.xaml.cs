using CourseCompanion.ViewModels;
using System.Windows.Controls;

namespace CourseCompanion.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : Page
    {
        public HomeView()
        {
            InitializeComponent();
            HomeViewModel homeViewModel = new HomeViewModel();
            this.DataContext = homeViewModel;
        }

    }
}
