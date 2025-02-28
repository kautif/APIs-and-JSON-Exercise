﻿using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;

namespace APIsAndJSON;

public class Program
{
    static void Main(string[] args)
    {
        #region Exercise 1
        var client = new HttpClient();
        var kanyeURL = "https://api.kanye.rest/";
        var swansonURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

        for (int i = 0; i < 5; i++)
        {
            var kanyeResponse = client.GetStringAsync(kanyeURL).Result;
            var kanyeQuote = JsonObject.Parse(kanyeResponse)["quote"].ToString();

            var swansonResponse = client.GetStringAsync(swansonURL).Result;
            var swansonQuote = JsonObject.Parse(swansonResponse)[0];

            Console.WriteLine($"Kanye: {kanyeQuote}");
            Console.WriteLine($"Swanson: {swansonQuote}");
        }
        #endregion

        var op = new OpenWeatherMapAPI();
        op.getWeather("Hoover", "AL");


    }
}
