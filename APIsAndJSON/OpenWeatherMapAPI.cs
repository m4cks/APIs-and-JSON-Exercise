using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{

    // Gilroy coords: [37.0058, -121.5683]
    // Lima coords: [-12.0432, -77.0282]

    // API call: https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={API key}&units=imperial
    // Add "&units=imperial" at the end for Fahrenheit

    public class OpenWeatherMapAPI
    {

        static double limaLat = -12.0432;
        static double limaLon = -77.0282;

        static double gilroyLat = 37.0058;
        static double gilroyLon = -121.5683;

        static string apiKey = "df408d2c2c35f927055fca367a5bf674";

        public static void GetTemperatures()
        {
            HttpClient client = new HttpClient();

            var gilroyResponse = client.GetStringAsync($"https://api.openweathermap.org/data/2.5/weather?lat={gilroyLat}&lon={gilroyLon}&appid={apiKey}&units=imperial").Result;
            var gilroyResult = JObject.Parse(gilroyResponse).GetValue("main").ToString();
            var gilroyTemp = JObject.Parse(gilroyResult).GetValue("temp").ToString();
            var gilroyLow = JObject.Parse(gilroyResult).GetValue("temp_min").ToString();
            var gilroyHigh = JObject.Parse(gilroyResult).GetValue("temp_max").ToString();

            var limaResponse = client.GetStringAsync($"https://api.openweathermap.org/data/2.5/weather?lat={limaLat}&lon={limaLon}&appid={apiKey}&units=metric").Result;
            var limaResult = JObject.Parse(limaResponse).GetValue("main").ToString();
            var limaTemp = JObject.Parse(limaResult).GetValue("temp").ToString();
            var limaLow = JObject.Parse(limaResult).GetValue("temp_min").ToString();
            var limaHigh = JObject.Parse(limaResult).GetValue("temp_max").ToString();

            Console.WriteLine($"Gilroy's temp is: {gilroyTemp} Fahrenheit.\n\tIts low is {gilroyLow} Fahrenheit.\n\tIts high is {gilroyHigh} Fahrenheit.");
            Console.WriteLine($"Lima's temp is: {limaTemp} Celsius.\n\tIts low is {limaLow} Celsius.\n\tIts high is {limaHigh} Celsius.");

        }
          
    }
}
