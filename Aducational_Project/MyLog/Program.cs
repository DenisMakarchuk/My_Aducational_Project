using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLog
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "logs.txt";
            int counter = 2;
            if (File.ReadAllBytes(fileName).Length > 1024*1024)
            {
                fileName = "logs" + counter + ".txt";
            }
            
            FileStream aFile = new FileStream(fileName, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(aFile);
            aFile.Seek(0, SeekOrigin.End);
            sw.WriteLine("123");
            sw.Close();
        }


    }
}
