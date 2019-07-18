using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZTravelAgency_DharmeshPatel
{
    class User
    {
        public int regID { get; }
        string name;
        string address;
        string vacationPlan;
        string date;

        public User(int regID, string name, string address, string vacationPlan, string date)
        {
            this.regID = regID;
            this.name = name;
            this.address = address;
            this.vacationPlan = vacationPlan;
            this.date = date;
        }


    }
}
