using CourseCompanion.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace CourseCompanion.Models
{
    public class semester
    {
        public int semester_id { get; set; }
        public DateTime start_date { get; set; }
        public int num_weeks { get; set; } 
     
    }
}
