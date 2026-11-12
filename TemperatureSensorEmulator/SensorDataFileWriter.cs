using System;
using System.IO;
using System.Linq;

namespace TemperatureSensorEmulator
{
    internal class SensorDataFileWriter
    {
        string _fileTxt = $"Example.txt";
        string _processingPath = "Processing";
        string _readyPath = "Ready";
        string _fullPath = "";
        int _numberPlot = 1; // номер участка пруда, участок содержит пруды
        int _numberFishCage = 4; // номер пруда 
        string _dataCreateFile = string.Empty;
        TemperatureSensor _temperatureSensor;
        public SensorDataFileWriter(TemperatureSensor temperatureSensor, int numberPlot, int numberFishCage)
        {
            _temperatureSensor = temperatureSensor ?? new TemperatureSensor();
            _numberPlot = numberPlot;
            _numberFishCage = numberFishCage;
        }
        /// <summary>
        /// Если нет папки создает Processing, Ready
        /// </summary>
        private void EnsureDirectoriesExist()
        {
            if (!Directory.Exists(_processingPath))
            {
                Directory.CreateDirectory(_processingPath);
            }
            if (!Directory.Exists(_readyPath))
            {
                Directory.CreateDirectory(_readyPath);
            }

        }
        

        public void CreateFile()
        {
            EnsureDirectoriesExist();
            DateTime now = DateTime.Now;
            _dataCreateFile = now.ToString("yyyyMMddHHmmss");
            _fileTxt = $"{_numberPlot}-{_numberFishCage}-{_dataCreateFile}.txt";
            _fullPath = Path.Combine(_processingPath, _fileTxt);
            File.WriteAllText(_fullPath, $"1|{_temperatureSensor.ReadTemperature()}\n2|{_temperatureSensor.ReadTemperature()}");
            if (File.Exists(Path.Combine(_processingPath, _fileTxt)))
            {
                Console.WriteLine($"ФАЙЛ {_fullPath} существует");
                File.Move(_fullPath, Path.Combine(_readyPath, _fileTxt));
            }
           

        }

        // нет проверок если файлы застряли в папке Proceccing. Нам это пока что и не нужно
    }
}
