using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Xml.Linq;

namespace DAL
{
    internal class Dal_XML : IDal
    {
        public int addMother(Mother m)
        {
            DS.DatasourceXML.Mothers.Add(m.toXML());
            DS.DatasourceXML.SaveMothers();
            return m.ID;           
        }

        private  int MaxContractID()
        {
            int result;
            var kayam = DS.DatasourceXML.Contracts.Elements("Contract").Any();

            if (!kayam)
            {
                result = 100000;
            }
            else
            {
                result = (from c in DS.DatasourceXML.Contracts.Elements("Contract")
                              select Int32.Parse(c.Element("ContractID").Value)).Max();
            }

            return result;

        }
        public int addContract(Contract c)
        {
            //ContractNannyChild contract = c.clone();
            //contract.ContractID = MaxContractID() + 1;
            //DS.DatasourceXML.Contracts.Add(contract.toXML());

            XElement contract = c.toXML();
            contract.Element("ContractID").Value = (MaxContractID() + 1).ToString();
            DS.DatasourceXML.Contracts.Add(contract);
            DS.DatasourceXML.SaveContracts();
            return Int32.Parse(contract.Element("ContractID").Value);

        }
        public IEnumerable<Mother> getAllMothers()
        {
            XElement root = DS.DatasourceXML.Mothers;
            List<Mother> result = new List<Mother>();
            foreach (var m in root.Elements("Mother"))
            {
               result.Add(m.toMother());
            }
            return result.AsEnumerable();
        }

        public IEnumerable<Contract> getAllContracts()
        {
            XElement root = DS.DatasourceXML.Contracts;
            List<Contract> result = new List<Contract>();
            foreach (var c in root.Elements("Contract"))
            {
                result.Add(c.toContract());
            }
            return result.AsEnumerable();
        }

        public bool removeMother(Mother m)
        {
            throw new NotImplementedException();
        }

        public bool removeContract(Contract c)
        {
            throw new NotImplementedException();
        }
    }
}
