using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            int option = -1;
            int ID = 38;
            string FirstName;
            string LastName;
            string Address;
            string Location;
            string CellPhone;
            bool[] WantedDays;
            List<Day> Days;
           

            string choice;
            do
            {
                Console.WriteLine("ma ata rotze ");
                choice = Console.ReadLine();
                option = Int32.Parse(choice);
                switch (option)
                {
                    case 0:
                        break;
                    case 1:
                        ID = Int32.Parse(Console.ReadLine());
                        FirstName = Console.ReadLine();
                        LastName = Console.ReadLine();
                        Address = Console.ReadLine();
                        Location = Console.ReadLine();
                        CellPhone = Console.ReadLine();

                        addMother();
                        break;
                    case 2:
                        getAllMothers();
                        break;
                }
                Console.WriteLine();
            }
            while (option != 0);
        }

        private static void getAllMothers()
        {
            try
            {
                List<Mother> immaot = BL.FactorySingletonBL.getInstance.getAllMothers();
                foreach (var m in immaot)
                {
                    Console.WriteLine(m);
                }

            }
            catch (Exception problem)
            {

                Console.WriteLine(problem.Message);
            }
        }

        private static void addMother()
        {
            Mother imma = new Mother
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
            try
            {
                BL.FactorySingletonBL.getInstance.addMother(imma);

            }
            catch (Exception baya)
            {
                Console.WriteLine(baya.Message);
            }
        }
    }
}

