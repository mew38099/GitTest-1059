using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week08_Git_Multiple
{
    class WaterHeater : ITemperatureControl
    {
        private int _targetTemp = 60;
        private int _currentTemp = 30;
        private const int MinWaterTemp = 30;
        private const int MaxWaterTemp = 80; 

        public int MinTemperature => MinWaterTemp;
        public int MaxTemperature => MaxWaterTemp;

        public int TargetTemperature
        {
            get => _targetTemp;
            set => _targetTemp = value;
        }

        public int CurrentTemperature => _currentTemp;


        public int GetCurrentTemperature()
        {
            {
                if (_currentTemp < _targetTemp)
                {
                    _currentTemp++;  
                }
                else if (_currentTemp > _targetTemp)
                {
                    _currentTemp--;  
                }

                Console.WriteLine("Current Temperature is " + _currentTemp + "°C");
                return _currentTemp;
            }
        }

        public void SetTemperature(int degrees)
        {
            _targetTemp = Math.Max(MinWaterTemp, Math.Min(degrees, MaxWaterTemp));
            Console.WriteLine("Target Temperature is set to " + _targetTemp + "°C");
        }

    }
}

