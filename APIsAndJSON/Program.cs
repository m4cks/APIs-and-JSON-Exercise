namespace APIsAndJSON
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's entertain ourselves with a quick Kanye West and Ron Swanson conversation: \n\n");

            RonVSKanyeAPI.RonKanyeConversation();

            Console.WriteLine("\n\nBelow is the implementation of the OpenWeather API: \n\n");

            OpenWeatherMapAPI.GetTemperatures();
        }
    }
}
