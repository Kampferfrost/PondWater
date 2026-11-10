using System;
using System.Collections.Generic;
using System.Text;

namespace TemperatureSensorEmulator
{
    internal class TemperatureSensor
    {
        public Guid Id { get; set; }
        public double CurrentTemperature { get; set; }
        public DateTime Timestamp  { get; set; }
        private double _minTemperatureFishCage = 15.0;
        private double _maxTemperatureFishCage = 26.0;

        public double generateTemperature()
        {
            double result = _minTemperatureFishCage + (Random.Shared.NextDouble() * (_maxTemperatureFishCage - _minTemperatureFishCage));
            result = Math.Round(result, 1);
            return result; 
        }

        // нужно разобраться тут со свойствами, а то они не используются здесь
        


    }


}
