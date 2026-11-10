using System;
using System.IO;
using System.Linq;

namespace TemperatureSensorEmulator
{
    internal class SensorDataFileWriter
    {
        string _fileSearchPattern = $"*.txt";
        string _fileTxt = $"Example.txt";
        string _processingPath = "Processing";
        int _numberPlot = 1; // номер участка пруда, участок содержит пруды
        int _numberFishCage = 4; // номер пруда 
        string _dataCreateFile = string.Empty;
        TemperatureSensor? _temperatureSensor;
        public SensorDataFileWriter(TemperatureSensor temperatureSensor, int numberPlot, int numberFishCage)
        {
            _temperatureSensor = temperatureSensor ?? new TemperatureSensor();
            _numberPlot = numberPlot;
            _numberFishCage = numberFishCage;
        }
        /// <summary>
        /// Если нет папки создает
        /// </summary
        public void CheckFolder()
        {
            if (!Directory.Exists(_processingPath))
            {
                Directory.CreateDirectory(_processingPath);
            }
            else
            {
                Console.WriteLine($"Directrory {_processingPath} exists.");
            }
        }

        public void CreateFile()
        {
            CheckFolder();
            DateTime _now = DateTime.Now;
            _dataCreateFile = _now.ToString("yyyyMMddHHmmss");
            _fileTxt = $"{_numberPlot}-{_numberFishCage}-{_dataCreateFile}.txt";
            if (!Directory.EnumerateFiles(_processingPath, _fileSearchPattern).Any())
            {
                Console.WriteLine($"в папке {_processingPath} нет файлов {_fileSearchPattern}");
            }
            else
            {
                Console.WriteLine($"в папке {_processingPath} есть файлы {_fileSearchPattern}");
            }
            File.WriteAllText(Path.Combine(_processingPath, _fileTxt), $"1|{_temperatureSensor?.generateTemperature()}\n2|{_temperatureSensor?.generateTemperature()}");
        }

        // остановился на просмотр кода с ии, который исправил парку ошибок
    }
}
