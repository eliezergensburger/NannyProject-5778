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
            var result = (from c in DS.DatasourceXML.Contracts.Elements("Contract")
                          select Int32.Parse(c.Element("ContractID").Value)).Max();
            if (result == 0)
            {
                result = 100000;
            }
            return result;

        }
        public int addContract(Contract c)
        {
            //ContractNannyChild contract = c.clone();
            //contract.ContractId = MaxContractID() + 1;
            //DS.DatasourceXML.Contracts.Add(contract.toXML());

            XElement contract = c.toXML();
            contract.Element("ContractID").Value = (MaxContractID() + 1).ToString();
            DS.DatasourceXML.Contracts.Add(contract);
            DS.DatasourceXML.SaveContracts();
            return c.ContractId;

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
    }
}
