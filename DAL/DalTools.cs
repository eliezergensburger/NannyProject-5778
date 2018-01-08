using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;

namespace DAL
{
    public static class DalTools
    {
        public static T DeepClone<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                xs.Serialize(ms, obj);
                ms.Position = 0;

                return (T)xs.Deserialize(ms);
            }
        }
        public static Nanny clone (this Nanny  nanny)
        {           
            return DeepClone(nanny);
        }
        public static Mother clone(this Mother mother)
        {
            return new Mother
            {
                ID = mother.ID,
                FirstName = mother.FirstName,
                LastName = mother.LastName,
                WantedDays = mother.WantedDays.ToArray(),
                Address = mother.Address,
                Location = mother.Location,
                Days = mother.Days,
                CellPhone = mother.CellPhone
            };
        }
        public static Contract clone(this Contract contract)
        {
            return new Contract
            {
                ContractId = contract.ContractId,
                ChildId = contract.ChildId,
                NannyId = contract.NannyId,
                MotherId = contract.MotherId,
                HadInterview = contract.HadInterview,
                SignedContract = contract.SignedContract,
                HourlyPayment = contract.HourlyPayment,
                MonthlyPayment = contract.MonthlyPayment,
                IsPaidByHour = contract.IsPaidByHour,
                StartContact = contract.StartContact,
                EndContract = contract.EndContract
            };
        }
 
        public static XElement toXML(this TimeSpan time, string attribute = "undefined")
        {
            return new XElement("Time", new XAttribute("type", attribute),
                new XElement("Hours", time.Hours),
                new XElement("Minutes", time.Minutes),
                new XElement("Seconds", time.Seconds));
        }

        public static XElement toXML(this Mother mother)
        {
            return new XElement("Mother",
                new XElement("ID", mother.ID),
                new XElement("FirstName", mother.FirstName),
                new XElement("LastName", mother.LastName),
                new XElement("WantedDaysArray",
                    (from d in mother.WantedDays
                     select new XElement("DayBool", d.ToString())
                    )),
                new XElement("Address", mother.Address),
                new XElement("Location", mother.Location),
                new XElement("DaysArray",
                    (from d in mother.Days
                     select new XElement("Day",
                         new XElement(d.Start.toXML("Start")),
                         new XElement(d.End.toXML("End"))
                     )
                    )
                ),
                new XElement("CellPhone", mother.CellPhone)
            );
        }
        public static XElement toXML(this Contract contract)
        {
            return new XElement("Contract",
                new XElement("ContractID", contract.ContractId),
                new XElement("MotherId", contract.MotherId),
                new XElement("NannyId", contract.NannyId),
                new XElement("ChildId", contract.ChildId)
          );
        }
        public static Contract toContract(this XElement contractrXml)
        {
            Contract result = null;
            if (contractrXml == null)
            {
                return result;
            }
            else
            {
                //TO DO
            }
            return result;
        }
  
        public static Mother toMother(this XElement motherXml)
        {
            Mother result = null;
            if (motherXml == null)
            {
                return result;
            }
            else
            {
                result = new Mother
                {
                    ID = Int32.Parse(motherXml.Element("ID").Value),
                    FirstName = motherXml.Element("FirstName").Value,
                    LastName = motherXml.Element("LastName").Value,
                    Location = motherXml.Element("Location").Value,
                    Address = motherXml.Element("Address").Value,
                    CellPhone = motherXml.Element("CellPhone").Value,
                    WantedDays = (from e in motherXml.Element("WantedDaysArray").Elements("DayBool")
                                  select Boolean.Parse(e.Value)).ToArray(),
                    Days = (from d in motherXml.Element("DaysArray").Elements("Day")
                            from t in d.Elements("Time")
                            select new Day
                            {
                                Start = new TimeSpan(
                                    Int32.Parse(t.Element("Hours").Value),
                                    Int32.Parse(t.Element("Minutes").Value),
                                    Int32.Parse(t.Element("Seconds").Value)),
                                End = new TimeSpan(
                                    Int32.Parse(t.Element("Hours").Value),
                                    Int32.Parse(t.Element("Minutes").Value),
                                    Int32.Parse(t.Element("Seconds").Value)) 

                            }).ToList()
                };
                return result;
            }
        }
    }
}
