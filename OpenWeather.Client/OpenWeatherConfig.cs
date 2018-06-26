using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace OpenWeather.Client
{
    class OpenWeatherConfig
    {
        public static string AppId => ConfigurationManager.AppSettings[name: "openWeather:AppId"];
    }
}
