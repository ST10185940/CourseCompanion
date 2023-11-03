﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Interaction logic for RegisterView.xaml
    /// </summary>
    public partial class RegisterView : Page
    {
        public RegisterView()
        {
            InitializeComponent();
            RegisterViewModel view = new RegisterViewModel();
            this.DataContext = view;
            var viewModel = (RegisterViewModel)DataContext;

            if (viewModel.RegistrationSuccess)
            {
                HomeView home = new HomeView();
                MainFrame.NavigationService.Navigate(home);
            }           
        }
    }
}