using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace APIsAndJSON
{
    public class OpenWeatherMapAPI
    {
        IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
        public void getWeather(string city) {
            var client = new HttpClient();
            string apiKey = config.GetSection("ApiSettings:apikey_weather").Value;
            string weatherURL = $"https://api.openweathermap.org/geo/1.0/direct?q=Houston,TX,US&appid={apiKey}";
            var weatherResponse = client.GetStringAsync(weatherURL).Result;
            Console.WriteLine(weatherResponse);
        }
    }
}
