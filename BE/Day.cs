using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Day
    {
        //thanks to nachum & matanya
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public override string ToString()
        {
            return this.ToStringProperty();
        }
    }
}
