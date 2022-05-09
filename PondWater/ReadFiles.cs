using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PondWater
{
    internal class ReadFiles
    {
        internal string DirIn { get; set; } = "In"; // папка входящих файлов

        internal void CheckDirAndFiles()
        {
            DirectoryInfo directoryIn = new DirectoryInfo(DirIn);

            if (directoryIn.Exists)
            {
                FileInfo[] dirs = directoryIn.GetFiles("*.txt");
                foreach (FileInfo dir in dirs)
                {
                    Console.WriteLine(dir);
                }
            }
            else
            {
                directoryIn.Create();
            }

        }

    }


    



}
