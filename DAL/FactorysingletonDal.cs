using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FactorysingletonDal
    {
        private static IDal instance;

        protected FactorysingletonDal(){}

        public static IDal getInstance {
            get
            {
                if (instance == null)
                {
                    // instance = new Dal_List();
                    instance = new Dal_XML();
                }
                return instance;
            }
        }
    }
}
