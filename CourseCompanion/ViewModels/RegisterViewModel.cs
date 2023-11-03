using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CourseCompanion.Commands;
using CourseCompanion.DataAccess;
using CourseCompanion.Models;
using CourseCompanion.Views;
using Microsoft.EntityFrameworkCore;


namespace CourseCompanion.ViewModels
{
    public class RegisterViewModel
    {
        private string Username_in { get; set; }
        private string Password_in { get; set; }
        public string result { get; set; }

        public UserID_Dependency shared { get; set; }

        public RelayCommand registerUser { get; set; }

        public bool RegistrationSuccess { get; private set; }

        public RegisterViewModel() {
            registerUser = new RelayCommand(Register, CanRegister);
        }

        private async void Register(object obj)
        {
            await Register();
        }

        private bool CanRegister(object obj)
        {
            return true;
        }

        private async Task Register()
        {
            if (!string.IsNullOrEmpty(Username_in) && !string.IsNullOrEmpty(Password_in))
            {
                try
                {
                    using (var context = new AppData())
                    {
                        var existingUser = context.user.FirstOrDefault(x => x.username == Username_in);

                        if (existingUser != null)
                        {
                            result = "That username has been taken , use another!";
                        }
                        else
                        {
                            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(Password_in);
                            var currentUser = new user { username = Username_in, password = hashedPassword };
                            context.user.Add(currentUser);
                            context.SaveChanges();
                            result = $"{currentUser.username} your account has been created";
                            RegistrationSuccess = true;

                            int userId = context.user
                                .Where(u => u.username == Username_in)
                                .Select(u => u.user_id)
                                .FirstOrDefault();
                            shared.ID = userId;

                        }
                    }
                }
                catch (Exception ex)
                {
                    result = "registration failed:" + ex.Message;
                }
            }
            else
            {
                result = "Please fill in all fields ,to proceed";
            }
        }  
    }
}
