using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logs
{
    public class MyLog
    {
        public static DirectoryInfo directory = new DirectoryInfo("C:\\MyLogs");

        public static void Logs(object obj)
        {
            string fileName = directory + "\\logs.txt";
            int counter = 2;

            FileStream aFile = new FileStream(fileName, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(aFile);
            sw.Close();

            do
            {
                if (File.ReadAllBytes(fileName).Length > 1024 * 1024)
                {
                    fileName = directory + "\\logs" + counter + ".txt";

                    counter++;
                }
                else
                {
                    break;
                }
            }
            while (true);

            aFile = new FileStream(fileName, FileMode.OpenOrCreate);
            sw = new StreamWriter(aFile);

            aFile.Seek(0, SeekOrigin.End);
            sw.WriteLine($"{DateTime.Now}:\n{obj.ToString()}");
            sw.Close();
        }
    }
}
