using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeatherNet.Util.Data
{
    public class TemperatureHelper
    {
        public static decimal KelvinToFahrenheit(decimal kelvin)
        {
            return ((KelvinToCelsius(kelvin)) * 9 / 5) + 32;   
        }

        public static decimal KelvinToCelsius(decimal kelvin)
        {
            return kelvin - 273;
        }

    } 
}
