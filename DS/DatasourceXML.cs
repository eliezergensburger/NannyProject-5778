using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DS
{
    public static class DatasourceXML
    {
        //private static string currentDirectory = Directory.GetCurrentDirectory();
        private static string solutionDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).FullName;

        private static string filePath = System.IO.Path.Combine(solutionDirectory, "DS", "DataXML");

        private static XElement motherRoot = null;
        static string motherPath = Path.Combine(filePath, "MotherXml.xml");

        private static XElement contractRoot = null;
        static string contractPath = Path.Combine(filePath, "ContractXml.xml");

        static DatasourceXML()
        {
            bool exists = Directory.Exists(filePath);
            if (!exists)
            {
                Directory.CreateDirectory(filePath);
            }

            if (!File.Exists(motherPath))
            {
                CreateFile("Mothers", motherPath);

            }
            motherRoot = LoadData(motherPath);


            if (!File.Exists(contractPath))
            {
                CreateFile("Contracts", contractPath);
            }
            else
            {
                contractRoot = LoadData(contractPath);
            }
        }

        public static void Save(XElement root, string path)
        {
            root.Save(path);
        }

        public static void SaveMothers()
        {
            motherRoot.Save(motherPath);
        }

        public static void SaveContracts()
        {
            contractRoot.Save(contractPath);
        }

        public static XElement Mothers
        {
            get
            {
                motherRoot = LoadData(motherPath);
                return motherRoot;
            }
        }
        public static XElement Contracts
        {
            get
            {
                contractRoot = LoadData(contractPath);
                return contractRoot;
            }
        }

        private static void CreateFile(string typename, string path)
        {
            XElement root = new XElement(typename);
            root.Save(path);
        }

        private static XElement LoadData(string path)
        {
            XElement root;
            try
            {
                root = XElement.Load(path);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
            return root;
        }
    }
}
