using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenWeatherClient.Test
{
    [TestClass]
    public class OpenWeatherClientTest
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            var openWeather = new OpenWeather();
            var weatherData = await openWeather.GetWeatherAsync(cityName: "Tokyo");
            Assert.IsNotNull(weatherData);
            Assert.AreEqual(expected: "Tokyo", actual: weatherData.Name);
        }
    }
}
