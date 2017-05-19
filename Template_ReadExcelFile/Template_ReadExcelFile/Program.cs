using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using Excel = Microsoft.Office.Interop.Excel;  

namespace Template_ReadExcelFile
{
    class Program
    {
        private static string excelFileName = ConfigurationManager.AppSettings["excelFileName"];
        private static string UPC_ColumnName = ConfigurationManager.AppSettings["UPC_ColumnName"];
        private static string ProductPageURL_ColumnName = ConfigurationManager.AppSettings["ProductPageURL_ColumnName"]; // нужно получить relative URL
        private static string hostName = ConfigurationManager.AppSettings["hostName"]; //для правильной генерации relative URL. перестраховка
        private static string ParentUPC_ColumnName = ConfigurationManager.AppSettings["ParentUPC_ColumnName"]; // Проверяем на повторы, если есть повторы , то выводим информацию, нет- нет.

        static void Main(string[] args)
        {
            // создаем имя таблицы как у оригинала но с др расширением
            string tableName = excelFileName.Replace("xslx", "table");  // найти др решение изменения расширения у файла

            File.AppendAllText(tableName, "|ContentFamilyID|RelativePageURL|Lang|" + "\n");

            ReadExcelFile(excelFileName, tableName);
        }

        static void ReadExcelFile(string excelFileName, string tableName)
        {

        }
    }
}
