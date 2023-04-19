using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace APIsAndJSON
{
    public class OpenWeatherMapAPI
    {
        public void getWeather(string city, string state)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var client = new HttpClient();
            string apiKey = config.GetConnectionString("ApiKey");
            string locationURL = $"https://api.openweathermap.org/geo/1.0/direct?q={city},{state},US&appid={apiKey}";
            var locationResponse = client.GetStringAsync(locationURL).Result;
            var locationJson = JsonObject.Parse(locationResponse)[0];
            var lat = locationJson["lat"];
            var lon = locationJson["lon"];

            string weatherURL = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&units=imperial&appid={apiKey}";
            var weatherResponse = client.GetStringAsync(weatherURL).Result;
            var weatherJson = JsonObject.Parse(weatherResponse);
            Console.WriteLine($"City: {weatherJson["name"]}");
            Console.WriteLine($"Weather: {weatherJson["main"]["temp"]}F");
        }
    }
}
