using System.IO;
using System;
using Microsoft.Extensions.DependencyInjection;


namespace TemperatureSensorEmulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = $"*.txt";
            string fileTxt = $"Example.txt";
            string processingPath = "Processing";
            string readyPath = "Ready";

            IServiceCollection services = new ServiceCollection();

            int numberPlot = 1; // номер участка пруда, участок содержит пруды
            int numberFishСagе = 3; // номер садка

     
            TemperatureSensor temperatureSensor = new TemperatureSensor(); // стоит ли класс создавать TemperatureSensor каждый раз либо, создать один раз, и пользоваться одним методом?
            SensorDataFileWriter sensorDataFileWriter = new SensorDataFileWriter(temperatureSensor, numberPlot, numberFishСagе);

            sensorDataFileWriter.CreateFile();


            /// <summary>
            /// перечисляем в папке файлы указаной маской filePath, и читаем их
            /// </summary>
            foreach (string file in Directory.EnumerateFiles(readyPath, filePath))
            {
                Console.WriteLine(file);
            }
        }
    }
}

//TODO: Сделать генератор температуры
//DONE: Нужно чтобы генератор создавал папку Processing(Temp) если ее нет
//DONE: Создать генерацию температуры прудов от 15 до 25, данные записать в строку. 1 строка: "1|35,5" т.е. внутрь пишется номер датчика|температура
//DONE: В папке Proccesing создать файл, где имя в формате 1-4-20220128150030.txt где номерУчастка-НомерСадка-дата.txt 2022.01.28 15:00:30
//DONE: Сделать отдельный класс температурного сенсора
//TODO: Нужен DI
//TODO: numberPlot и numberFishСagе сделать с чтобы брал с файла configure.ini
//DONE: После, того как файл создался, нужно перенести файл в папку Ready.

