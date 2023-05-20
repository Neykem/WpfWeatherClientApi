using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WpfWeatherClientApi.Model.Data;

namespace WpfWeatherClientApi.Domain.Interface
{
    interface IWearherDayRepository
    {
        Task<WeatherDay> GetWeatherInCityForToday(string cityName);
        WeatherDay GetWeatherDayForDate(DateTime dateTime);
    }
}
