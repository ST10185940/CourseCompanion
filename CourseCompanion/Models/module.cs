using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCompanion.Models
{
    public class module
    {
       public int module_id { get; set; }
       public int semester { get; set; }
       public string name { get; set; }
       public string code { get; set; }       
       public double credits { get; set; }
       public  double weekly_hrs{ get; set; }
       public int num_weeks { get; set; }   
       public double hrs_left { get; set; }           
       public int user_id { get; set; }
       public double selfstudy_hrs { get; set; }

    }
 
}
