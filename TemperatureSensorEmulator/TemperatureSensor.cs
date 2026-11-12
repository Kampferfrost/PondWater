using System;
using System.Collections.Generic;
using System.Text;

namespace TemperatureSensorEmulator
{
    internal class TemperatureSensor
    {
        public Guid Id { get; set; }
        public double CurrentTemperature { get; private set; }
        public DateTime Timestamp  { get; private set; }
        private readonly double _minTemperature = 15.0;
        private readonly double _maxTemperature = 26.0;

        public TemperatureSensor(double minTemperature = 15.0, double maxTemperature = 26.0)
        {
            Id = Guid.NewGuid();
            _minTemperature = minTemperature;
            _maxTemperature = maxTemperature;

            ReadTemperature();
        }

        public double ReadTemperature()
        {
            double rawValue = _minTemperature + (Random.Shared.NextDouble() * (_maxTemperature - _minTemperature));
            CurrentTemperature = Math.Round(rawValue, 1);
            return CurrentTemperature; 
        }

        // нужно разобраться тут со свойствами, а то они не используются здесь
        


    }


}
