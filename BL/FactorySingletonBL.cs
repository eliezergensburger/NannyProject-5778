using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class FactorySingletonBL
    {
        private static Ibl instance;

        protected FactorySingletonBL() { }

        public static Ibl getInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MyBL();
                }
                return instance;
            }
        }

    }
}
