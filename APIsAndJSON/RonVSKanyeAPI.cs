using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public class RonVSKanyeAPI
    {

        static string kanyeURL = "https://api.kanye.rest";
        static string ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

        public static void RonKanyeConversation()
        {
            var client = new HttpClient();

            Console.WriteLine($"Kanye West says to Ron Swanson, {GetKanyeQuote(client)}\n");

            Console.WriteLine($"Then Ron Swanson says, {GetRonQuote(client)}\n");

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Kanye replies, {GetKanyeQuote(client)}\n");

                Console.WriteLine($"Ron replies, {GetRonQuote(client)}\n");
            }
        }

        public static string GetKanyeQuote(HttpClient client)
        {
            var kanyeResponse = client.GetStringAsync(kanyeURL).Result;
            return "\"" + JObject.Parse(kanyeResponse).GetValue("quote").ToString() + "\"";
        }

        public static string GetRonQuote(HttpClient client)
        {
            var ronResponse = client.GetStringAsync(ronURL).Result;
            return ronResponse.ToString().Replace('[', ' ').Replace(']', ' ').Trim();
        }
    }
}
