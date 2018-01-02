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

        public IEnumerable<Mother> getAllMothers()
        {
            XElement root = DS.DatasourceXML.Mothers;
            List<Mother> result = new List<Mother>();
            foreach (var m in root.Elements("mother"))
            {
               result.Add(m.toMother());
            }
            return result.AsEnumerable();
        }

        public bool removeMother(Mother m)
        {
            throw new NotImplementedException();
        }
    }
}
