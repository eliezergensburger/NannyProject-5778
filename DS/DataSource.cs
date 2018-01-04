using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS
{
    public class DataSource
    {
        #region private members
        private static List<Mother> motherlist = new List<Mother>();
        private static List<Contract> contractNannyChildlist = new List<Contract>();
        #endregion

        #region getters and setters
        public static List<Mother> Mothers
        {
            get { return motherlist; }
        }

        public static List<Contract> ContractNannyChildlist
        {
            get => contractNannyChildlist;
        }
        #endregion
    }
}
