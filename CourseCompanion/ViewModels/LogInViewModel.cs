using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Shapes;
using CourseCompanion.Commands;
using CourseCompanion.DataAccess;
using CourseCompanion.Models;
using CourseCompanion.Views;
using Microsoft.EntityFrameworkCore;

namespace CourseCompanion.ViewModels
{
    public class LogInViewModel
    {

        private string Username_in { get; set; }
        private string Password_in { get; set; }
        private string result { get; set; }

        public RelayCommand loginUser { get; set; }

        public bool loginSuccess { get; private set; }

        public UserID_Dependency shared { get; set; }

        public LogInViewModel() {

            loginUser = new RelayCommand(Login, CanLogin);
        }

        private bool CanLogin(object obj)
        {
            return true;
        }

        private async void Login(object obj)
        {
            await Login();
        }

        private async Task Login()
        {
            if (!string.IsNullOrEmpty(Username_in) && !string.IsNullOrEmpty(Password_in))
            {

                try
                {
                    using (var context = new AppData())
                    {
                       
                        var user = await (context.user.FirstOrDefaultAsync(u => u.username == Username_in));
                        if (user != null && BCrypt.Net.BCrypt.EnhancedVerify(Password_in, user.password))
                        {
                            result = "Login Successful";
                            loginSuccess = true;

                            int userId = context.user
                                .Where(u => u.username == Username_in)
                                .Select(u => u.user_id)
                                .FirstOrDefault();
                            shared.ID = userId;
                        }
                        else
                        {
                            result = "Log-In failed.  please re-enter credentials ";
                        }
                    }

                }
                catch (Exception e)
                {
                    result = "login failed " + e.Message;
                }
            }
            else
            {
                result = "Please enter all credentials";
            }
        }
    }
}
