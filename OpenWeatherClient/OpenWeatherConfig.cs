using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace OpenWeatherClient
{
    class OpenWeatherConfig
    {
        public static string AppId => ConfigurationManager.AppSettings[name: "openWeather:AppId"];
    }
}
