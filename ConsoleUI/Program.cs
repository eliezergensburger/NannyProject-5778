﻿using System;
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
        private static int dummy = 1;
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

                        //TO DO

                        Mother mother = new Mother
                        {
                            ID = ID,
                            FirstName = FirstName,
                            LastName = LastName,
                            Address = Address,
                            Location = Location,
                            CellPhone = CellPhone,
                            BirthDate = DateTime.Now.AddYears(-30)
                        };
                        addMother(mother);
                        break;
                    case 2:
                        getAllMothers();
                        break;
                    case 3:
                        Contract contract = new Contract
                        {
                            MotherId = 123,
                            ContractID = 999,
                            NannyId = 777,
                            ChildId = ++dummy,
                            HadInterview = true,
                            HourlyPayment = 45.5,
                            IsPaidByHour = (dummy % 2 == 0) ? true : false,
                            MonthlyPayment = 2800,
                            SignedContract = true,
                            StartContact = DateTime.Now.AddMonths(-6),
                            EndContract = null
                        };
                        addContract(contract);
                        break;
                    case 4:
                        foreach (var item in getAllContracts())
                        {
                            Console.WriteLine(item);
                        }
                        break;
                }
                Console.WriteLine();
            }
            while (option != 0);
        }

        private static void addContract(Contract contract)
        {
            try
            {
                BL.FactorySingletonBL.getInstance.addContract(contract);
            }
            catch (Exception baya)
            {
                Console.WriteLine(baya.Message);
            }
        }

        private static List<Contract> getAllContracts()
        {
            List<Contract> result = null;
            try
            {
                result = BL.FactorySingletonBL.getInstance.getAllContracts();
            }
            catch (Exception baya)
            {
                Console.WriteLine(baya.Message);
            }
            return result;
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

        private static void addMother(Mother mother)
        {
            //Mother imma = new Mother
            //{
            //    ID = 38,
            //    FirstName = "Sarah",
            //    LastName = "Imeinu",
            //    Address = "Ha-Va'ad ha-Le'umi St 21, Jerusalem",
            //    Location = "Mal'akhi St 16, Bnei Brak",
            //    CellPhone = "05111111",
            //    WantedDays = new bool[6] { true, true, true, true, true, false },
            //    Days = new List<Day>(6)
            //    {
            //        new Day {Start = new Time(7), End = new Time(16)},
            //        new Day {Start = new Time(8), End = new Time(16)},
            //        new Day {Start = new Time(7, 30), End = new Time(13)},
            //        new Day {Start = new Time(8), End = new Time(16)},
            //        new Day {Start = new Time(8), End = new Time(17)},
            //        new Day {Start = new Time(), End = new Time(0)},
            //    }
            //};
            try
            {
                BL.FactorySingletonBL.getInstance.addMother(mother);
            }
            catch (Exception baya)
            {
                Console.WriteLine(baya.Message);
            }
        }
    }
}

