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
            var weatherJson = await openWeather.GetWeatherAsync();
            Assert.IsNotNull(weatherJson);
        }
    }
}
