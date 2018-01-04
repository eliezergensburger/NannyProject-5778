using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    internal class Dal_List :IDal
    {
        static int ContractSerial = 100000;

        public int addMother(Mother m)
        {
           DS.DataSource.Mothers.Add(m.clone());
            return m.ID;
        }

        public bool removeMother(Mother m)
        {
            Mother leshaavar = getAllMothers().Where(item => item.ID == m.ID).FirstOrDefault();
            if (leshaavar != null)
            {
                return DS.DataSource.Mothers.Remove(leshaavar);
            }
            return false;
         }

        public IEnumerable<Mother> getAllMothers()
        {
            List<Mother> mothers = new List<Mother>();
            foreach (var m in DS.DataSource.Mothers)
            {
                mothers.Add(m.clone());
            }
            return mothers.AsEnumerable();
        }

        public int addContract(ContractNannyChild c)
        {
            ContractNannyChild contract = c.clone();
            contract.ContractId = ++ContractSerial;
            DS.DataSource.ContractNannyChildlist.Add(contract);
            return contract.ContractId;
        }

        public IEnumerable<ContractNannyChild> getAllContracts()
        {
            List<ContractNannyChild> contracts = new List<ContractNannyChild>();
            foreach (var c in DS.DataSource.ContractNannyChildlist)
            {
                contracts.Add(c.clone());
            }
            return contracts.AsEnumerable();
        }
    }
}
