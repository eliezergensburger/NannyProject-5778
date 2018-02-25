using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Person
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public override string ToString()
        {
            string result=null;

            result += "\n" + "ID" +": "+ ID;
            result += "\n" + "FirstName" + ": " + FirstName;
            result += "\n" + "LastName" + ": " + LastName;
            result += "\n" + "Gender" + ": " + Gender;

            return result;
        }
    }
}
