#region

using System;
using WeatherNet.Model;

#endregion

namespace WeatherNet.Model
{
    /// <summary>
    ///     HistoricWeatherResult result type.
    /// </summary>
    public class HistoricWeatherResult : WeatherResult
    {
        /// <summary>
        ///     Atmospheric pressure in hPa.
        /// </summary>
        public Double Pressure { get; set; }

        /// <summary>
        ///     Wind direction in degrees (meteorological)
        /// </summary>
        public double WindDirection { get; set; }

        /// <summary>
        ///     Speed of wind gust
        /// </summary>
        public double WindGustSpeed { get; set; }

        /// <summary>
        ///     Rain volume mm .
        /// </summary>
        public Double Rain { get; set; }

        /// <summary>
        ///     Cloudiness in %
        /// </summary>
        public Double Clouds { get; set; }
    }
}