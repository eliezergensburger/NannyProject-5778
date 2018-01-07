using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Yom
    {
        TimeSpan Start { get; set; }
        TimeSpan End { get; set; }
        public override string ToString()
        {
            return this.ToStringProperty();
        }
    }
}
