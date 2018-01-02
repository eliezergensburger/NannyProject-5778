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

        static DatasourceXML()
        {
            if (!File.Exists(motherPath))
                CreateFiles();
            else
                LoadData();
        }

        public static void Save(XElement root, string path)
        {
            root.Save(path);
            LoadData();
        }

        public static void SaveMothers()
        {
            motherRoot.Save(motherPath);
            LoadData();
        }

        public static XElement Mothers
        {
            get
            {
                LoadData();
                return motherRoot;
            }
        }

        private static void CreateFiles()
        {
            if (motherRoot == null)
            {
                motherRoot = new XElement("mothers");
            }
            motherRoot.Save(motherPath);
        }

        private static void LoadData()
        {
            try
            {
                motherRoot = XElement.Load(motherPath);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }
    }
}
