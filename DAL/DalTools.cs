using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Xml.Linq;

namespace DAL
{
    public static class DalTools
    {
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
        public static XElement toXML(this Time time,string attribute ="undefined")
        {
            return new XElement("Time", new XAttribute("type",attribute),
                new XElement("Hour", time.Hour),
                new XElement("Minutes", time.Minutes),
                new XElement("Seconds", time.Seconds));
        }

        public static XElement toXML(this Mother mother)
        {
            return new XElement("mother",
                new XElement("ID", mother.ID.ToString()),
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
                                Start = new Time(
                                    Int32.Parse(t.Element("Hour").Value),
                                    Int32.Parse(t.Element("Minutes").Value),
                                    Int32.Parse(t.Element("Seconds").Value)),
                                End = new Time(
                                    Int32.Parse(t.Element("Hour").Value),
                                    Int32.Parse(t.Element("Minutes").Value),
                                    Int32.Parse(t.Element("Seconds").Value)),
                            }).ToList()
                };
                return result;
            }
        }
    }
}
