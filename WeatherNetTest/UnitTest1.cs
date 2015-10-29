#region

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherNet;
using WeatherNet.Clients;

#endregion

namespace WeatherNetTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetCurrentWeatherByCityNameTest()
        {
            //Specifying optional settings
            ClientSettings.ApiUrl = "http://api.openweathermap.org/data/2.5";
            ClientSettings.ApiKey = "1234567890";


            //Exist
            var result = CurrentWeather.GetByCityName("Dublin", "Ireland", "se", "metric");
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Item);


            result = CurrentWeather.GetByCityName("Dublin", "Ireland", "nl", "imperial");
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Item);
        }

        [TestMethod]
        public void GetCurrentCurrentWeatherByCityIdTest()
        {
            //Does not exist
            var result = CurrentWeather.GetByCityId(1111111);
            Assert.IsFalse(result.Success);
            Assert.IsNull(result.Item);

            //Exist
            result = CurrentWeather.GetByCityId(2964574);
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Item);
        }

        [TestMethod]
        public void GetCurrentCurrentWeatherByCityCoordinatesTest()
        {
            //Does Not Exist
            var result = CurrentWeather.GetByCoordinates(-1984453.363665, -1984453.363665);
            Assert.IsFalse(result.Success);
            Assert.IsNull(result.Item);

            //Exist
            result = CurrentWeather.GetByCoordinates(53.363665, -6.255541);
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Item);

            result = CurrentWeather.GetByCoordinates(53.363665, -6.255541, "nl", "imperial");
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Item);
        }


        [TestMethod]
        public void GetFiveDaysForecastByCityNameTest()
        {
            //Does not exist
            var result = FiveDaysForecast.GetByCityName("12345325231432", "32412342134231");
            Assert.IsFalse(result.Success);
            Assert.IsNull(result.Items);

            //Exist
            result = FiveDaysForecast.GetByCityName("Dublin", "Ireland");
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.Items.Count > 0);
            Assert.IsNotNull(result.Items[0]);

            result = FiveDaysForecast.GetByCityName("Dublin", "Ireland", "de", "metric");
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.Items.Count > 0);
            Assert.IsNotNull(result.Items[0]);
        }

        [TestMethod]
        public void GetFiveDaysForecastByCityIdTest()
        {
            //Does not exist
            var result = FiveDaysForecast.GetByCityId(-2964574);
            Assert.IsFalse(result.Success);
            Assert.IsNull(result.Items);

            //Exist
            result = FiveDaysForecast.GetByCityId(2964574);
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.Items.Count > 0);
            Assert.IsNotNull(result.Items[0]);

            result = FiveDaysForecast.GetByCityId(2964574, "de", "metric");
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.Items.Count > 0);
            Assert.IsNotNull(result.Items[0]);
        }

        [TestMethod]
        public void GetFiveDaysForecastByCityCoordinatesTest()
        {
            //Does not exist
            var result = FiveDaysForecast.GetByCoordinates(-1984453.363665, -1984453.363665);
            Assert.IsFalse(result.Success);
            Assert.IsNull(result.Items);

            //Exist
            result = FiveDaysForecast.GetByCoordinates(53.363665, -6.255541, "se", "imperial");
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.Items.Count > 0);
            Assert.IsNotNull(result.Items[0]);
        }


        [TestMethod]
        public void GetSixteenDaysForecastByCityNameTest()
        {
            //Does not exist
            var result = SixteenDaysForecast.GetByCityName("testcitytest", "testcitytest", 14);
            Assert.IsFalse(result.Success);
            Assert.IsNull(result.Items);

            //Exist
            result = SixteenDaysForecast.GetByCityName("Dublin", "Ireland", 14);
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.Items.Count > 0);
            Assert.IsNotNull(result.Items[0]);
        }

        [TestMethod]
        public void GetSixteenDaysForecastByCityIdTest()
        {
            //Does not exist
            var result = SixteenDaysForecast.GetByCityId(1111111, 5);
            Assert.IsFalse(result.Success);
            Assert.IsNull(result.Items);

            //Exist
            result = SixteenDaysForecast.GetByCityId(2964574, 14);
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.Items.Count > 0);
            Assert.IsNotNull(result.Items[0]);
        }

        [TestMethod]
        public void GetSixteenDaysForecastByCityCoordinatesTest()
        {
            //Does not exist
            var result = SixteenDaysForecast.GetByCoordinates(-1984453.363665, -1984453.363665, 14);
            Assert.IsFalse(result.Success);
            Assert.IsNull(result.Items);

            //Exist
            result = SixteenDaysForecast.GetByCoordinates(53.363665, -6.255541, 14, "se", "metric");
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.Items.Count > 0);
            Assert.IsNotNull(result.Items[0]);
        }

        [TestMethod]
        public void GetHistoryByCityNameTest()
        {
            ClientSettings.ApiKey = "1234567890";

            //Exist
            var result = HistoricWeather.GetByCityName("Dublin", "Ireland", DateTime.Now.AddDays(-7), DateTime.Now.AddDays(-6));
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.Items.Count > 0);
            Assert.IsNotNull(result.Items[0]);

            //Does not exist
            result = HistoricWeather.GetByCityName("testcitytest", "testcitytest", DateTime.Now.AddDays(-7), DateTime.Now.AddDays(-6));
            Assert.IsFalse(result.Success);
            Assert.IsNull(result.Items);



        }

        [TestMethod]
        public void GetHistoryByCityIdTest()
        {
            ClientSettings.ApiKey = "1234567890";

            //Does not exist
            var result = HistoricWeather.GetByCityId(1111111, DateTime.Now.AddDays(-7), DateTime.Now.AddDays(-6));
            Assert.IsFalse(result.Success);
            Assert.IsNull(result.Items);

            //Exist
            result = HistoricWeather.GetByCityId(2885679, DateTime.Now.AddDays(-7), DateTime.Now.AddDays(-6));
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.Items.Count > 0);
            Assert.IsNotNull(result.Items[0]);
        }

        [TestMethod]
        public void GetHistoryByCityCoordinatesTest()
        {
            ClientSettings.ApiKey = "1234567890";

            //Does not exist
            var result = HistoricWeather.GetByCoordinates(-1984453.363665, -1984453.363665, DateTime.Now.AddDays(-7), DateTime.Now.AddDays(-6));
            Assert.IsFalse(result.Success);
            Assert.IsNull(result.Items);

            //Exist
            result = HistoricWeather.GetByCoordinates(53.363665, -6.255541, DateTime.Now.AddDays(-7), DateTime.Now.AddDays(-6), "se", "metric");
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.Items.Count > 0);
            Assert.IsNotNull(result.Items[0]);
        }

    }
}