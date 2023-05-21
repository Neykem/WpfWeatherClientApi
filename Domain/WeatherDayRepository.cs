using System;
using System.Net.Http;
using System.Collections.Generic;
using WpfWeatherClientApi.Domain.Interface;
using WpfWeatherClientApi.Model.Data;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Linq;

namespace WpfWeatherClientApi.Domain
{
    internal class WeatherDayRepository : IWearherDayRepository
    {
        private readonly HttpClient httpClient;
        private string _apiKey { get; set; }
        public WeatherDayRepository(string apiKey)
        {
            httpClient = new HttpClient();
            _apiKey = apiKey;
        }

        public WeatherDay GetWeatherDayForDate(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        async public Task<WeatherDay> GetWeatherInCityForToday(string cityName)
        {
            string req = "https://api.openweathermap.org/data/2.5/weather?q=" + cityName + "&appid=" + _apiKey + "&lang=ru";
            HttpResponseMessage response = await httpClient.GetAsync(req);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                WeatherDay weatherDay = JsonConvert.DeserializeObject<WeatherDay>(json);
                List<WeatherDay> weatherData = new List<WeatherDay>();
                weatherData.Add(weatherDay);

                return weatherDay;
            }
            else
            {
                throw new Exception($"Ошибка загрузки данных! Код ошибки: {response.StatusCode}");
            }
            throw new NotImplementedException();
        }
    }
}
