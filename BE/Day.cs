using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Day
    {
        public Time Start { get; set; }
        public Time End { get; set; }
        public override string ToString()
        {
            return this.ToStringProperty();
        }

    }
}
