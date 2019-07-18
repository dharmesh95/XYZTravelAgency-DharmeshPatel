using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZTravelAgency_Q5
{
    class User
    {
       
  

      
  public string Package { get; set; }
        public string Name { get; set; }

        public DateTime TravelDate { get; set; }

        public User( string name , string package, DateTime date)
        {
          
            Name = name;       
            Package = package;
            TravelDate = date;
        }

     
    }
}
