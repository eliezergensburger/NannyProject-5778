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

        private static string filePath = System.IO.Path.Combine(solutionDirectory,"DS", "DataXML");
      
        private static XElement motherRoot = null;
        static string motherPath = Path.Combine(filePath, "MotherXml.xml");

        private static XElement contractRoot = null;
        static string contractPath = Path.Combine(filePath, "ContractXml.xml");

        static DatasourceXML()
        {
            if (!File.Exists(motherPath))
                CreateFile(motherRoot,"Mothers",motherPath);
            else
                LoadData(motherRoot, motherPath);

            if (!File.Exists(contractPath))
                CreateFile(contractRoot, "Contracts",contractPath);
            else
                LoadData(contractRoot,contractPath);
        }

        public static void Save(XElement root, string path)
        {
            root.Save(path);
            LoadData(root,path);
        }

        public static void SaveMothers()
        {
            motherRoot.Save(motherPath);
            LoadData(motherRoot, motherPath);
        }
        public static void SaveContracts()
        {
            contractRoot.Save(motherPath);
            LoadData(motherRoot, motherPath);
        }

        public static XElement Mothers
        {
            get
            {
                LoadData(motherRoot, motherPath);
                return motherRoot;
            }
        }
        public static XElement Contracts
        {
            get
            {
                LoadData(contractRoot, contractPath);
                return contractRoot;
            }
        }

         private static void CreateFile(XElement root,string typename,string path)
        {
            if (root == null)
            {
                root = new XElement(typename);
            }
            root.Save(path);
        }

        private static void LoadData(XElement root,string path)
        {
            try
            {
                root = XElement.Load(path);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }
    }
}
