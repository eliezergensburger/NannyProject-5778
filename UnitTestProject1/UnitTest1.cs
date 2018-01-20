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
                new Day {Start = new TimeSpan(7,0,0), End = new TimeSpan(16,0,0)},
                new Day {Start = new TimeSpan(8,0,0), End = new TimeSpan(16,0,0)},
                new Day {Start = new TimeSpan(7, 30,0), End = new TimeSpan(13,0,0)},
                new Day {Start = new TimeSpan(8,0,0), End = new TimeSpan(16,0,0)},
                new Day {Start = new TimeSpan(8,0,0), End = new TimeSpan(17,0,0)},
                new Day {Start = new TimeSpan(), End = new TimeSpan()}
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
            XElement firstmother = root.Elements("Mother").First();
            var mmm = firstmother.Element("DaysArray");
            Console.WriteLine(mmm);
            Mother mother = firstmother.toMother();
            //Console.WriteLine(imma);
            Console.WriteLine(mother);
        }

        [TestMethod]
        public void TestAddMotherToXML()
        {
            FactorySingletonBL.getInstance.addMother(imma);
            Mother mother = FactorySingletonBL.getInstance.getAllMothers().FirstOrDefault();
            Console.WriteLine(mother);
        }
 
        [TestMethod]
        public void TestGoogleMapApi()
        {
            BL.Ibl bl = BL.FactorySingletonBL.getInstance;

            int distance = bl.getDrivingDistance("Ha-Va'ad ha-Le'umi St 21, Jerusalem", "Beit Ha-Defus St 7, Jerusalem", false);
            //int distance = bl.getDrivingDistance("Beit Ha-Defus St 47, Jerusalem", "Beit Ha-Defus St 7, Jerusalem", false);
            

            string result = (distance >= 1000) ? String.Format("driving distance is {0:#,000} kilometers", distance) : String.Format("driving distance is {0} meters", distance);
            Console.WriteLine(result);

            int distance2 = bl.getWalkingDistance("Ha-Va'ad ha-Le'umi St 21, Jerusalem", "Beit Ha-Defus St 7, Jerusalem", false);
            result = (distance2 >= 1000) ? String.Format("walking distance is {0:#,000} kilometers", distance2) : String.Format("walking distance is {0} meters", distance2);
            Console.WriteLine(result);
        }
    }
}
