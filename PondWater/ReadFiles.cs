using System.Text;
using System;
using System.IO;

namespace PondWater
{
    internal class ReadFiles
    {
        internal string DirIn { get; set; } = "In"; // папка входящих файлов

        internal async void CheckDirAndFiles()
        {
            DirectoryInfo directoryIn = new DirectoryInfo(DirIn);

            if (directoryIn.Exists)
            {
                Console.WriteLine("папка существует");
                FileInfo[] dirs = directoryIn.GetFiles("*.txt");

                foreach (FileInfo dir in dirs)
                {
                    Console.WriteLine(dir);
                    Console.WriteLine("файл существует");
                }
            }
            else
            {
                directoryIn.Create();
                Console.WriteLine("файл не существует");
            }

            using (FileStream fstream = File.OpenRead($"{DirIn}/1-4-20220128150030.txt"))
            {
                Console.WriteLine("Петушок");
                byte[] buffer = new byte[fstream.Length];
                await fstream.ReadAsync(buffer, 0, buffer.Length);
                string textFromFile = Encoding.UTF8.GetString(buffer);
                Console.WriteLine($"Текст из файла:\n{textFromFile}");
            }
        }

    }






}

