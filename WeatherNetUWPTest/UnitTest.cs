using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using WeatherNet;
using WeatherNet.Clients;
using System.Threading.Tasks;

namespace WeatherNetUWPTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task GetCurrentWeatherByCityNameTest()
        {
            //Specifying optional settings
            ClientSettings.ApiUrl = "http://api.openweathermap.org/data/2.5";
            ClientSettings.ApiKey = "2de143494c0b295cca9337e1e96b00e0"; //Provide your own ApiKey here, this is just for testing


            //Exist
            var result = await CurrentWeather.GetByCityNameAsync("Dublin", "Ireland", "se", "metric");
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Item);


            result = await CurrentWeather.GetByCityNameAsync("Dublin", "Ireland", "nl", "imperial");
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Item);
        }

        [TestMethod]
        public async Task GetCurrentCurrentWeatherByCityIdTest()
        {
            //Does not exist
            var result = await CurrentWeather.GetByCityIdAsync(1111111);
            Assert.IsFalse(result.Success);
            Assert.IsNull(result.Item);

            //Exist
            result = await CurrentWeather.GetByCityIdAsync(2964574);
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Item);
        }

        [TestMethod]
        public async Task GetCurrentCurrentWeatherByCityCoordinatesTest()
        {
            //Does Not Exist
            var result = await CurrentWeather.GetByCoordinatesAsync(-1984453.363665, -1984453.363665);
            Assert.IsFalse(result.Success);
            Assert.IsNull(result.Item);

            //Exist
            result = await CurrentWeather.GetByCoordinatesAsync(53.363665, -6.255541);
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Item);

            result = await CurrentWeather.GetByCoordinatesAsync(53.363665, -6.255541, "nl", "imperial");
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Item);
        }


        [TestMethod]
        public async Task GetFiveDaysForecastByCityNameTest()
        {
            //Does not exist
            var result = await FiveDaysForecast.GetByCityNameAsync("12345325231432", "32412342134231");
            Assert.IsFalse(result.Success);
            Assert.IsNull(result.Items);

            //Exist
            result = await FiveDaysForecast.GetByCityNameAsync("Dublin", "Ireland");
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.Items.Count > 0);
            Assert.IsNotNull(result.Items[0]);

            result = await FiveDaysForecast.GetByCityNameAsync("Dublin", "Ireland", "de", "metric");
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.Items.Count > 0);
            Assert.IsNotNull(result.Items[0]);
        }

        [TestMethod]
        public async Task GetFiveDaysForecastByCityIdTest()
        {
            //Does not exist
            var result = await FiveDaysForecast.GetByCityIdAsync(-2964574);
            Assert.IsFalse(result.Success);
            Assert.IsNull(result.Items);

            //Exist
            result = await FiveDaysForecast.GetByCityIdAsync(2964574);
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.Items.Count > 0);
            Assert.IsNotNull(result.Items[0]);

            result = await FiveDaysForecast.GetByCityIdAsync(2964574, "de", "metric");
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.Items.Count > 0);
            Assert.IsNotNull(result.Items[0]);
        }

        [TestMethod]
        public async Task GetFiveDaysForecastByCityCoordinatesTest()
        {
            //Does not exist
            var result = await FiveDaysForecast.GetByCoordinatesAsync(-1984453.363665, -1984453.363665);
            Assert.IsFalse(result.Success);
            Assert.IsNull(result.Items);

            //Exist
            result = await FiveDaysForecast.GetByCoordinatesAsync(53.363665, -6.255541, "se", "imperial");
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.Items.Count > 0);
            Assert.IsNotNull(result.Items[0]);
        }


        [TestMethod]
        public async Task GetSixteenDaysForecastByCityNameTest()
        {
            //Does not exist
            var result = await SixteenDaysForecast.GetByCityNameAsync("testcitytest2", "testcitytest2", 14);
            Assert.IsFalse(result.Success);
            Assert.IsNull(result.Items);

            //Exist
            result = await SixteenDaysForecast.GetByCityNameAsync("Dublin", "Ireland", 14);
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.Items.Count > 0);
            Assert.IsNotNull(result.Items[0]);
        }

        [TestMethod]
        public async Task GetSixteenDaysForecastByCityIdTest()
        {
            //Does not exist
            var result = await SixteenDaysForecast.GetByCityIdAsync(1111111, 5);
            Assert.IsFalse(result.Success);
            Assert.IsNull(result.Items);

            //Exist
            result = await SixteenDaysForecast.GetByCityIdAsync(2964574, 14);
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.Items.Count > 0);
            Assert.IsNotNull(result.Items[0]);
        }

        [TestMethod]
        public async Task GetSixteenDaysForecastByCityCoordinatesTest()
        {
            //Does not exist
            var result = await SixteenDaysForecast.GetByCoordinatesAsync(-1984453.363665, -1984453.363665, 14);
            Assert.IsFalse(result.Success);
            Assert.IsNull(result.Items);

            //Exist
            result = await SixteenDaysForecast.GetByCoordinatesAsync(53.363665, -6.255541, 14);//, "se", "metric");
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.Items.Count > 0);
            Assert.IsNotNull(result.Items[0]);
        }
    }
}
