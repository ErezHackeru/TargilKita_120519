using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    static class VirusScanner
    {
        public static int _IsInfected { get; set; }
        static VirusScanner()
        {
            string IsInfected = ConfigurationManager.AppSettings["MalwareSize"];
            _IsInfected = Convert.ToInt32(IsInfected);
        }
        public static bool IsFileInfected(MyFile myFile)
        {
            if (myFile.FileSize == _IsInfected)
                return true;
            else
            {
                throw new InfectedFileDetectedException("file is infected with virus", myFile.filePath);
                //return false;
            }
                
        }

    }
}
