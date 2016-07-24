using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace BotWebApi.Models
{


    public class WeatherState
    {
        public int WeatherId { get; set; }
        public decimal Temp { get; set; }
        public string Description { get; set; }
        public int Cloudiness { get; set; }

        public static WeatherState FromJson(string jsonString)
        {
            var obj = (JObject)JsonConvert.DeserializeObject(jsonString);
            var weatherId = obj["weather"][0].Value<int>("id");
            var desc = obj["weather"][0].Value<string>("description");
            var temp = obj["main"]["temp"].Value<decimal>();
            var clouds = obj["clouds"]["all"].Value<int>();
            return new WeatherState() { Cloudiness = clouds, Description = desc, Temp = temp, WeatherId = weatherId };
        }
    }
}