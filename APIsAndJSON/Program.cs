using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;

namespace APIsAndJSON;

public class Program
{
    static void Main(string[] args)
    {

        var client = new HttpClient();
        var kanyeURL = "https://api.kanye.rest/";
//        var kanyeResponse = client.GetStringAsync(kanyeURL).Result;
  //      var kanyeQuote = JsonObject.Parse(kanyeResponse)["quote"].ToString();

        var swansonURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
//        var swansonResponse = client.GetStringAsync(swansonURL).Result;
  //      var swansonQuote = JsonObject.Parse(swansonResponse)[0];

        for (int i = 0; i < 5; i++) {
            var kanyeResponse = client.GetStringAsync(kanyeURL).Result;
            var kanyeQuote = JsonObject.Parse(kanyeResponse)["quote"].ToString();

            var swansonResponse = client.GetStringAsync(swansonURL).Result;
            var swansonQuote = JsonObject.Parse(swansonResponse)[0];

            Console.WriteLine($"Kanye: {kanyeQuote}");
            Console.WriteLine($"Swanson: {swansonQuote}");
        }
    }
}
