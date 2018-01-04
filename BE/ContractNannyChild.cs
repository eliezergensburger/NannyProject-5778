using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ContractNannyChild
    {
        public int ContractId { get; set; }
        public int NannyId { get; set; }
        public int MotherId { get; set; }
        public int ChildId { get; set; }
        public bool HadInterview { get; set; }
        public bool SignedContract { get; set; }
        public double HourlyPayment{ get; set; }
        public double MonthlyPayment { get; set; }
        public bool IsPaidByHour { get; set; }
        public DateTime StartContact { get; set; }
        public DateTime EndContract { get; set; }

        public override string ToString()
        {
            return this.ToStringProperty();
        }
    }
}
