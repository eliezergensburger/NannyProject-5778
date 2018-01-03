using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Xml.Linq;
using BE;
using BL;
using DAL;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private BE.Person person = new Person
        {
            ID = 123,
            FirstName = "moshe",
            LastName = "zuchmir"
        };
        private Mother imma = new Mother
        {
            ID = 38,
            FirstName = "Sarah",
            LastName = "Imeinu",
            Address = "Ha-Va'ad ha-Le'umi St 21, Jerusalem",
            Location = "Mal'akhi St 16, Bnei Brak",
            CellPhone = "05111111",
            WantedDays = new bool[6] { true, true, true, true, true, false },
            Days = new List<Day>(6)
            {
                new Day {Start = new Time(7), End = new Time(16)},
                new Day {Start = new Time(8), End = new Time(16)},
                new Day {Start = new Time(7, 30), End = new Time(13)},
                new Day {Start = new Time(8), End = new Time(16)},
                new Day {Start = new Time(8), End = new Time(17)},
                new Day {Start = new Time(), End = new Time(0)},
            }
        };

        [TestMethod]
        public void TestPersonTostring()
        {
            Console.WriteLine(person);
            // Assert.AreEqual("lo nachon",person.ToString());
        }
        [TestMethod]
        public void TestMotherToXml()
        {
            XElement motherXml = imma.toXML();
            var x = (from e in motherXml.Element("WantedDaysArray").Elements("DayBool")
                     select Boolean.Parse(e.Value));
            foreach (var b in x)
            {
                Console.WriteLine("the value is: {0}", b);
            }
        }

        [TestMethod]
        public void TestBoolParseXelement()
        {
            XElement stams =
                new XElement("WantedDaysArray",
                    new XElement("DayBool", "True"),
                    new XElement("DayBool", "True"));
            bool val = Boolean.Parse(stams.Elements("DayBool").First().Value);
            Console.WriteLine(val);
        }

        [TestMethod]
        public void TestToMother()
        {
            XElement root = DS.DatasourceXML.Mothers;
            XElement firstmother = root.Elements("mother").First();
            var mmm = firstmother.Element("DaysArray");
            Console.WriteLine(mmm);
            Mother mother = firstmother.toMother();
            //Console.WriteLine(imma);
            Console.WriteLine(mother);
        }

        [TestMethod]
        public void TestMotherDayXml()
        {
            XElement root = DS.DatasourceXML.Mothers;
            var firstmother = root.Elements("mother").First();
            var res = (from d in firstmother.Element("DaysArray").Elements("Day")
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
                       }).ToList();
            foreach (var d in res)
            {
                Console.WriteLine(d);
            }
        }

        [TestMethod]
        public void TestGoogleMapApi()
        {
            BL.Ibl bl = BL.FactorySingletonBL.getInstance;

            int distance = bl.getDrivingDistance("Ha-Va'ad ha-Le'umi St 21, Jerusalem", "Beit Ha-Defus St 7, Jerusalem", false);
            //int distance = bl.getDrivingDistance("Beit Ha-Defus St 47, Jerusalem", "Beit Ha-Defus St 7, Jerusalem", false);

            if (distance >= 1000)
            {
                Console.WriteLine("distance is {0:#,000} kilometers", distance);
            }
            else
            {
                Console.WriteLine("distance is {0} meters", distance);
            }
         }
    }
}
