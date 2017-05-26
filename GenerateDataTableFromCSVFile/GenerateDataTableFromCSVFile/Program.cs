using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace GenerateDataTableFromCSVFile
{
    class Program
    {
        private static string pathFolderCSVFiles = ConfigurationManager.AppSettings["pathFolderCSVFiles"];
        private static string hostNAME = ConfigurationManager.AppSettings["hostNAME"];
        private static string lang = ConfigurationManager.AppSettings["lang"];
        //private static string pathFolderCSVFiles = @"D:\JAJ\ENCH\Geotagging";
        //private static string hostNAME = "https://www.cleanandclear.co.uk";
        

        static void Main(string[] args)
        {
            string[] arrayOfCSVFiles = GetListCSVFiles();
            

            foreach (var fileName in arrayOfCSVFiles)
            {
                string tableName = fileName.Replace("csv", "table");
                Console.WriteLine("filename" + tableName);
                File.AppendAllText(tableName, "|ContentFamilyID|RelativePageURL|Lang|" + "\n");
                ReadCSVFile(fileName, tableName);
            }
            Console.ReadKey();
        }

        private static void ReadCSVFile(string filename, string tableName)
        {            
            using (StreamReader sr = new StreamReader(filename))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string rowToFile = "";
                    string FID = parts[0];
                    
                    if ((parts[1] != "") && (parts[1] != null))
                    {
                        string fullURL = parts[1];
                        string relativeURL = fullURL.Replace(hostNAME, "");
                        rowToFile = "|" + FID + "|" + relativeURL + "|" + lang + "|";
                        File.AppendAllText(tableName, rowToFile + "\n");
                    }
                    
                    //Console.WriteLine("row in file" + rowToFile);

                }
            }
        }

       
        private static string[] GetListCSVFiles()
        {
            string[] listStoryFiles = Directory.GetFiles(pathFolderCSVFiles, "*.csv");
            Console.WriteLine("Count of files = " + listStoryFiles.Length);
            return listStoryFiles;
        }

        private static void AddDataIntoTableFile(string file, string rowToFile)
        {
            File.AppendAllText(pathFolderCSVFiles + file + ".txt", rowToFile + "\n");
        }
    }
}
