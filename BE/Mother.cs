using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Mother:Person
    {
  
        public string CellPhone { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public bool[] WantedDays { get; set; }
        public List<Yom> Days { get; set; }
        public override string ToString()
        {
            string result = base.ToString();
            result += "\n"+"CellPhone" + ": "+ CellPhone;
            result += "\n" + "Address" + ": " + Address;
            result += "\n" + "Location" + ": " + Location;
            result += "\n" + "WantedDays" + ": [ " ;
            foreach (var b in WantedDays)
            {
                result += b.ToString() + ",";
            }
            result += ']';
            result += "\n" + "DaysSchedule" + ": ";
            foreach (var d in Days)
            {
                result += "\n" + d;
            }
            return result;
        }

    }
}
