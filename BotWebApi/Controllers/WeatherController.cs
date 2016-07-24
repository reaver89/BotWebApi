using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
using BotWebApi.Models;
using Newtonsoft.Json;

namespace BotWebApi.Controllers
{
    public class WeatherController : ApiController
    {
        private const string WheaterApiKey = "5b5e86ccf1c24f93841eb1d66904b778";
        private const int RostovCityId = 501175;

        private const string GetCurrentWeatherByIdUrlFormat = "http://api.openweathermap.org/data/2.5/weather?id={0}&lang=ru&units=metric&APPID=" + WheaterApiKey;
        private const string GetCurrentWeatherByNameUrlFormat = "http://api.openweathermap.org/data/2.5/weather?q={0}&lang=ru&units=metric&APPID=" + WheaterApiKey;

        // GET api/<controller>
        public JsonResult<WeatherState> Get()
        {
            string url = string.Format(GetCurrentWeatherByIdUrlFormat, RostovCityId);
            string response;
            using (var client = new HttpClient())
            {
                response = client.GetStringAsync(url).Result;
            }

            return Json(WeatherState.FromJson(response), new JsonSerializerSettings(), Encoding.Unicode);
        }

        [System.Web.Http.Route("api/weather/{name}")]
        public JsonResult<WeatherState> Get(string name)
        {
            string url = string.Format(GetCurrentWeatherByNameUrlFormat, name);
            string response;
            using (var client = new HttpClient())
            {
                response = client.GetStringAsync(url).Result;
            }

            return Json(WeatherState.FromJson(response), new JsonSerializerSettings(), Encoding.Unicode);
        }
    }
}