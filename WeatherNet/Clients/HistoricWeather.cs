#region

using System;
using WeatherNet.Model;
using WeatherNet.Util.Api;
using WeatherNet.Util.Data;

#endregion

namespace WeatherNet.Clients
{
    public static class HistoricWeather
    {
        /// <summary>
        ///     Get the weather history for a specific city by indicating its 'OpenwWeatherMap' identifier.
        /// </summary>
        /// <param name="id">City 'OpenwWeatherMap' identifier.</param>
        /// <param name="startDateTime">Data start of historic data</param>
        /// <param name="endDateTime">Data end of historic data</param>
        /// <returns>The historic weather information.</returns>
        public static Result<HistoricWeatherResult> GetByCityId(int id, DateTime startDateTime, DateTime endDateTime)
        {
            try
            {
                if (0 > id)
                    return new Result<HistoricWeatherResult>(null, false, "City Id must be a positive number.");

                var response = ApiClient.GetResponse("/history/city?id=" + id + "&start="+ TimeHelper.ToUnixTimestamp(startDateTime) +
                    "&end=" + TimeHelper.ToUnixTimestamp(endDateTime));

                return Deserializer.GetHistoryWeatherHourly(response);
            }
            catch (Exception ex)
            {
                return new Result<HistoricWeatherResult> { Items = null, Success = false, Message = ex.Message };
            }
        }

        /// <summary>
        ///     Get the weather history  for a specific city by indicating its 'OpenwWeatherMap' identifier, language and units
        ///     (metric or imperial)..
        /// </summary>
        /// <param name="id">City 'OpenwWeatherMap' identifier.</param>
        /// <param name="startDateTime">Data start of historic data</param>
        /// <param name="endDateTime">Data end of historic data</param>
        /// <param name="language">
        ///     The language of the information returned (example: English - en, Russian - ru, Italian - it,
        ///     Spanish - sp, Ukrainian - ua, German - de, Portuguese - pt, Romanian - ro, Polish - pl, Finnish - fi, Dutch - nl,
        ///     French - fr, Bulgarian - bg, Swedish - se, Chinese Traditional - zh_tw, Chinese Simplified - zh_cn, Turkish - tr ,
        ///     Czech - cz, Galician - gl, Vietnamese - vi, Arabic - ar, Macedonian - mk, Slovak - sk).
        /// </param>
        /// <param name="units">The units of the date (metric or imperial).</param>
        /// <returns>The historic weather information.</returns>
        public static Result<HistoricWeatherResult> GetByCityId(int id, DateTime startDateTime, DateTime endDateTime, String language, String units)
        {
            try
            {

                if (0 > id)
                    return new Result<HistoricWeatherResult>(null, false, "City Id must be a positive number.");
                var response =
                    ApiClient.GetResponse("/history/city?id=" + id + "&lang=" + language + "&units=" +
                                          units + "&start=" + TimeHelper.ToUnixTimestamp(startDateTime) + 
                                          "&end=" + TimeHelper.ToUnixTimestamp(endDateTime));

                return Deserializer.GetHistoryWeatherHourly(response);
            }
            catch (Exception ex)
            {
                return new Result<HistoricWeatherResult> { Items = null, Success = false, Message = ex.Message };
            }
        }

        /// <summary>
        ///     Get the weather history for a specific city by indicating the city and country names.
        /// </summary>
        /// <param name="city">Name of the city.</param>
        /// <param name="country">Country of the city.</param>
        /// <param name="startDateTime">Data start of historic data</param>
        /// <param name="endDateTime">Data end of historic data</param>
        /// <returns>The historic weather information.</returns>
        public static Result<HistoricWeatherResult> GetByCityName(String city, String country, DateTime startDateTime, DateTime endDateTime)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(city) || String.IsNullOrEmpty(country))
                    return new Result<HistoricWeatherResult>(null, false, "City and/or Country cannot be empty.");

                var response =
                    ApiClient.GetResponse("/history/city?q=" + city + "," + country + "&start=" + TimeHelper.ToUnixTimestamp(startDateTime) +
                    "&end=" + TimeHelper.ToUnixTimestamp(endDateTime));

                return Deserializer.GetHistoryWeatherHourly(response);
            }
            catch (Exception ex)
            {
                return new Result<HistoricWeatherResult> { Items = null, Success = false, Message = ex.Message };
            }
        }

        /// <summary>
        ///     Get the weather history for a specific city by indicating the city, country, language and units (metric or
        ///     imperial).
        /// </summary>
        /// <param name="city">Name of the city.</param>
        /// <param name="country">Country of the city.</param>
        /// <param name="startDateTime">Data start of historic data</param>
        /// <param name="endDateTime">Data end of historic data</param>
        /// <param name="language">
        ///     The language of the information returned (example: English - en, Russian - ru, Italian - it,
        ///     Spanish - sp, Ukrainian - ua, German - de, Portuguese - pt, Romanian - ro, Polish - pl, Finnish - fi, Dutch - nl,
        ///     French - fr, Bulgarian - bg, Swedish - se, Chinese Traditional - zh_tw, Chinese Simplified - zh_cn, Turkish - tr ,
        ///     Czech - cz, Galician - gl, Vietnamese - vi, Arabic - ar, Macedonian - mk, Slovak - sk).
        /// </param>
        /// <param name="units">The units of the date (metric or imperial).</param>
        /// <returns>The historic weather information.</returns>
        public static Result<HistoricWeatherResult> GetByCityName(String city, String country, DateTime startDateTime, DateTime endDateTime, String language,
            String units)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(city) || String.IsNullOrEmpty(country))
                    return new Result<HistoricWeatherResult>(null, false, "City and/or Country cannot be empty.");

                var response =
                    ApiClient.GetResponse("/history/city?q=" + city + "," + country + "&lang=" +
                                          language + "&units=" + units + "&start=" + TimeHelper.ToUnixTimestamp(startDateTime) +
                                            "&end=" + TimeHelper.ToUnixTimestamp(endDateTime));

                return Deserializer.GetHistoryWeatherHourly(response);
            }
            catch (Exception ex)
            {
                return new Result<HistoricWeatherResult> { Items = null, Success = false, Message = ex.Message };
            }
        }

        /// <summary>
        ///     Get the weather history for a specific city by indicating its coordinates.
        /// </summary>
        /// <param name="lat">Latitud of the city.</param>
        /// <param name="lon">Longitude of the city.</param>
        /// <param name="startDateTime">Data start of historic data</param>
        /// <param name="endDateTime">Data end of historic data</param>
        /// <returns>The historic weather information.</returns>
        public static Result<HistoricWeatherResult> GetByCoordinates(double lat, double lon, DateTime startDateTime, DateTime endDateTime)
        {
            try
            {
                var response =
                    ApiClient.GetResponse("/history/city?lat=" + lat + "&lon=" + lon + "&start=" + TimeHelper.ToUnixTimestamp(startDateTime) +
                    "&end=" + TimeHelper.ToUnixTimestamp(endDateTime));
                return Deserializer.GetHistoryWeatherHourly(response);
            }
            catch (Exception ex)
            {
                return new Result<HistoricWeatherResult> { Items = null, Success = false, Message = ex.Message };
            }
        }

        /// <summary>
        ///     Get the weather history for a specific city by indicating its coordinates, language and units (metric or imperial).
        /// </summary>
        /// <param name="lat">Latitud of the city.</param>
        /// <param name="lon">Longitude of the city.</param>
        /// <param name="startDateTime">Data start of historic data</param>
        /// <param name="endDateTime">Data end of historic data</param>
        /// <param name="language">
        ///     The language of the information returned (example: English - en, Russian - ru, Italian - it,
        ///     Spanish - sp, Ukrainian - ua, German - de, Portuguese - pt, Romanian - ro, Polish - pl, Finnish - fi, Dutch - nl,
        ///     French - fr, Bulgarian - bg, Swedish - se, Chinese Traditional - zh_tw, Chinese Simplified - zh_cn, Turkish - tr ,
        ///     Czech - cz, Galician - gl, Vietnamese - vi, Arabic - ar, Macedonian - mk, Slovak - sk).
        /// </param>
        /// <param name="units">The units of the date (metric or imperial).</param>
        /// <returns>The historic weather information.</returns>
        public static Result<HistoricWeatherResult> GetByCoordinates(double lat, double lon, DateTime startDateTime, DateTime endDateTime, String language,
            String units)
        {
            try
            {
                var response =
                    ApiClient.GetResponse("/history/city?lat=" + lat + "&lon=" + lon + "&lang=" +
                                          language + "&units=" + units + "&start=" + TimeHelper.ToUnixTimestamp(startDateTime) +
                                            "&end=" + TimeHelper.ToUnixTimestamp(endDateTime));

                return Deserializer.GetHistoryWeatherHourly(response);
            }
            catch (Exception ex)
            {
                return new Result<HistoricWeatherResult> { Items = null, Success = false, Message = ex.Message };
            }
        }
    }
}