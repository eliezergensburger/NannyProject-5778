using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Nanny:Person
    {
        public string CellPhone { get; set; }
        public string Address { get; set; }
        public bool Elevator { get; set; }
        public int Floor { get; set; }
        public int Experience { get; set; }
        public int MaxChildren  { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public bool PaidByHour { get; set; }
        public double HourlyWage { get; set; }
        public double MonthlyWage { get; set; }
        public bool[] WorkDays { get; set; }
        public List<Day> DaySchedule { get; set; }
        public bool VacationType { get; set; }
        public string Recommendations { get; set; } 

        public override string ToString()
        {   
            string result = base.ToString();

            result += "\n" + "CellPhone" + ": " + CellPhone;
            result += "\n" + "Address" + ": " + Address;
            result += "\n" + "WorkDays" + ": [ ";
            result += "\n" + "Elevator" + ": " + Elevator;
            result += "\n" + "Floor" + ": " + Floor;
            result += "\n" + "Experience" + ": " + Experience;
            result += "\n" + "MaxChildren" + ": " + MaxChildren;
            result += "\n" + "MinAge" + ": " + MinAge;
            result += "\n" + "MaxAge" + ": " + MaxAge;
            result += "\n" + "PaidByHour" + ": " + PaidByHour;
            result += "\n" + "HourlyWage" + ": " + HourlyWage;
            result += "\n" + "MonthlyWage" + ": " + MonthlyWage;

            foreach (var b in WorkDays)
            {
                result += b.ToString() + ",";
            }
            result += ']';

            result += "\n" + "DaysSchedule" + ": ";
            foreach (var d in DaySchedule)
            {
                result += "\n" + d;
            }
            return result;
        }
    }
}
