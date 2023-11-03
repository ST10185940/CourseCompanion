using CourseCompanion.Commands;
using CourseCompanion.DataAccess;
using CourseCompanion.Models;
using CourseCompanion.Views;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;

namespace CourseCompanion.ViewModels
{
    public class HomeViewModel
    {
        public ObservableCollection<module>? ModulesInfo { get; set; }
        public string searchName { get; set; }

        public string hrsDone { get; set; }

        public DateTime start_date { get; set; }

        public ICommand showAddModuleWindow { get; set; }
       
        public ICommand AddHrsCommand { get; set; }

        public  UserID_Dependency shared { get; set; }

        public string result;

        public HomeViewModel() 
        {
            try
            {
                using (var context = new AppData())
                {
                    ModulesInfo = new ObservableCollection<module>(context.module
                        .Where(u => u.user_id == shared.ID)
                        .ToList()
                   );
                }
               //ModulesInfo = get from db using user_id from module table where user_id = user_id ;
            } catch (ArgumentNullException ex){} catch(IOException) {} catch( ArithmeticException ar) { }
            showAddModuleWindow = new RelayCommand(ShowWindow,CanShowWindow);       
            AddHrsCommand = new RelayCommand(AddHrsDone,CanAddHrsDone);
        } 

        private bool CanAddHrsDone(object obj)
        {
            return true;
        }

        private void AddHrsDone(object obj)
        {
        
            if (!string.IsNullOrEmpty(searchName) && double.TryParse(hrsDone, out double hrsDone1))
            {
                try
                {
                    using (var context = new AppData())
                    {
                        var change = context.module
                        .Where(module => module.name == searchName && module.user_id == shared.ID)
                        .SingleOrDefault();


                        if (change != null)
                        {                    
                            change.hrs_left = change.hrs_left - hrsDone1;      
                            context.SaveChanges();
                            result = $"{change.name} has been updated";
                        }else
                        {
                            result = $"Module {searchName} doesn't exist";
                        }

                    }
                }catch (Exception ex) {
                    result = "module could not be altered";            
                }
            }
            else
            {
                result = "Enter fields to proceed";
            }
                     
        }

        // open window where users can add a new module
        private bool CanShowWindow(object obj)
        {
            return true;
        }

        private void ShowWindow(object obj)
        {
            AddModule addModuleWindow = new AddModule();
            addModuleWindow.Show(); 
        }
    }
}
