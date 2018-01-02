using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Child:Person
    {
        public int MotherId { get; set; }
        public bool HaveSpecialsNeeds { get; set; }
        public string SpecialNeeds { get; set; }

        public override string ToString()
        {
            string result = base.ToString();
            result += "\n" + "MotherID" + ": " + MotherId;
            result += "\n" + "HaveSpecialsNeeds" + ": " + HaveSpecialsNeeds;
            result +=  (HaveSpecialsNeeds == true) ? "\n" + SpecialNeeds : "";
            return result;
        }
    }
}
