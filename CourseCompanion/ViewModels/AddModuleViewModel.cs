using CourseCompanion.Commands;
using CourseCompanion.DataAccess;
using CourseCompanion.Models;
using CourseCompanion.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CourseCompanion.ViewModels
{
    public class AddModuleViewModel 
    {
        public ICommand AddModuleCommand { get; set; }
        public string Name_in { get; set; }
        public string Code_in { get; set; }
        public string Credits_in { get; set; }
        public string ClassHrsPerWeek_in { get; set; }
        public string SemesterWeeks_in { get; set; }
        public string Semester_in { get; set; }
        public string ModuleSelfStudyHours { get; set; }

        public string result;

        public UserID_Dependency shared { get; set; }


        public AddModuleViewModel()
        {
            AddModuleCommand = new RelayCommand(AddModule,CanAddModule);
        }

        private async void AddModule(object obj)
        {
            await AddModule();
        }

        private bool CanAddModule(object obj)
        {
            return true;
        }

        private async Task AddModule()
        {
      
            if (!string.IsNullOrWhiteSpace(Name_in) && !String.IsNullOrWhiteSpace(Code_in))
            {
                if (int.TryParse(Credits_in, out int Credits1))
                {
                    if (double.TryParse(ClassHrsPerWeek_in, out double ClassHrsPerWeek1))
                    {
                        if (int.TryParse(SemesterWeeks_in, out int SemesterWeeks1))
                        {
                            if (int.TryParse(Semester_in, out int Semester1))
                            {
                                double self_hrs = ((Credits1 * 10) / SemesterWeeks1) - ClassHrsPerWeek1;
                                try
                                {
                                    using (var context = new AppData())
                                    {
                                        var newModule = new module { name = Name_in, code = Code_in, credits = Credits1, weekly_hrs = ClassHrsPerWeek1, num_weeks = SemesterWeeks1, selfstudy_hrs = self_hrs, hrs_left = self_hrs, user_id = shared.ID, semester = Semester1 };
                                        context.SaveChanges();
                                        result = $" module: {newModule.name} has been created";
                                        context.Dispose();
                                      
                                    }

                                }
                                catch (Exception) { result = "could not add module"; } 
                            }
                        }
                    }
                }
            }
            else
            {
                result = "Enter all module details";
            }
        }

    }
}
