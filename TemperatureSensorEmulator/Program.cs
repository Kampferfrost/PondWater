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
            string fileTxt = $"Example.txt";
            string processingPath = "Processing";
            string readyPath = "Ready"; // Конечная папка

            int numberPlot = 1; // номер участка пруда, участок содержит пруды
            int numberFishСagе = 3; // номер садка

            
            

            /// <summary>
            /// перечисление папки processingPath
            /// </summary>
            foreach (string file in Directory.EnumerateFiles(processingPath))
            {
                Console.WriteLine(file);
            }


            string fullPath = Path.Join(processingPath, filePath); // тут я хочу создать строку и потом с помощью File проверить существует ли *.txt
            Console.WriteLine(fullPath);
            //Directory.EnumerateFiles(fullPath, filePath);
            Console.WriteLine();



            // Файл должен создаваться с датой создания файла
            DateTime now = DateTime.Now;
            string dataCreateFile = now.ToString("yyyyMMddHHmmss");
            fileTxt = $"{numberPlot}-{numberFishСagе}-{dataCreateFile}.txt";
            TemperatureSensor temperatureSensor = new TemperatureSensor(); // стоит ли класс создавать TemperatureSensor каждый раз либо, создать один раз, и пользоваться одним методом?
            SensorDataFileWriter sensorDataFileWriter = new SensorDataFileWriter(temperatureSensor, numberPlot, numberFishСagе);

            sensorDataFileWriter.CreateFile();

            //File.WriteAllText(Path.Combine(processingPath, fileTxt),$"1|{temperatureSensor.generateTemperature()}\n2|{temperatureSensor.generateTemperature()}");

            // В созданый файл нужно генерацию температуры прудов от 15 до 25, данные записать в строку. 1 строка: "1|35,5" т.е. внутрь пишется номер датчика|температура
            


            

            /// <summary>
            /// перечисляем в папке файлы указаной маской filePath, и читаем их
            /// </summary>
            foreach (string file in Directory.EnumerateFiles(processingPath, filePath))
            {
                Console.WriteLine(file);
            }

            Console.WriteLine(Math.Round(Random.Shared.NextDouble(), 1));
        }
    }
}

//TODO: Сделать генератор температуры
//DONE: Нужно чтобы генератор создавал папку Processing(Temp) если ее нет
//DONE: Создать генерацию температуры прудов от 15 до 25, данные записать в строку. 1 строка: "1|35,5" т.е. внутрь пишется номер датчика|температура
//DONE: В папке Proccesing создать файл, где имя в формате 1-4-20220128150030.txt где номерУчастка-НомерСадка-дата.txt 2022.01.28 15:00:30
//DONE: Сделать отдельный класс температурного сенсора
//TODO: Нужен DI
//TODO: После, того как файл создался, нужно перенести файл в папку Ready.

