using System.IO;


using System;
using System.Linq;

namespace TemperatureSensorEmulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = $"*.txt";
            string fileExampleTxt = $"Example.txt";
            string processingPath = "Processing";
            string readyPath = "Ready"; // Конечная папка

            int numberFishСagе = 4;
            int numberPlot = 1;


            /// <summary>
            /// Если нет папки создает
            /// </summary>
            if (!Directory.Exists(processingPath))
            {
                Directory.CreateDirectory(processingPath);
            }
            else
            {
                Console.WriteLine($"Directrory {processingPath} exists.");
            }

            /// <summary>
            /// перечисление папки processingPath
            /// </summary>
            foreach (string file in Directory.EnumerateFiles(processingPath))
            {
                Console.WriteLine(file);
            }


            string fullPath = Path.Combine(processingPath, filePath); // тут я хочу создать строку и потом с помощью File проверить существует ли *.txt
            Console.WriteLine(fullPath);
            //Directory.EnumerateFiles(fullPath, filePath);
            Console.WriteLine();
            

            if(!Directory.EnumerateFiles(processingPath, filePath).Any())
            {
                Console.WriteLine($"в папке {processingPath} нет файлов {filePath}");
            }
            else
            {
                Console.WriteLine($"в папке {processingPath} есть файлы {filePath}");
            }


            // Файл должен создаваться с датой создания файла
            DateTime now = DateTime.Now;
            string dataCreateFile = now.ToString("yyyyMMddHHmmss");
            fileExampleTxt = $"{numberPlot}-{numberFishСagе}-{dataCreateFile}.txt";
            
            double generateTemperature()
            {
                double minTemperatureFishCage = 15.0;
                double maxTemperatureFishCage = 26.0;
                double result = minTemperatureFishCage + (Random.Shared.NextDouble() * (maxTemperatureFishCage - minTemperatureFishCage));
                return result; // Нужно округлить значение
            }

            File.WriteAllText(Path.Combine(processingPath, fileExampleTxt),$"1|{generateTemperature()}\n2|{generateTemperature()}");

            // В созданый файл нужно генерацию температуры прудов от 15 до 25, данные записать в строку. 1 строка: "1|35,5" т.е. внутрь пишется номер датчика|температура
            


            

            /// <summary>
            /// перечисляем в папке файлы указаной маской filePath, и читаем их
            /// </summary>
            foreach (string file in Directory.EnumerateFiles(processingPath, filePath))
            {
                Console.WriteLine(file);
            }

            Console.WriteLine(Random.Shared.NextDouble());
        }
    }
}

//TODO: Сделать генератор температуры
//DONE: Нужно чтобы генератор создавал папку Processing(Temp) если ее нет
//TODO: Создать генерацию температуры прудов от 15 до 25, данные записать в строку. 1 строка: "1|35,5" т.е. внутрь пишется номер датчика|температура
//DONE: В папке Proccesing создать файл, где имя в формате 1-4-20220128150030.txt где номерУчастка-НомерСадка-дата.txt 2022.01.28 15:00:30
//TODO: После, того как файл создался, нужно перенести файл в папку Ready.

