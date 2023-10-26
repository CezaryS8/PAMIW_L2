using P04WeatherForecastAPI.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.Services
{
    public interface IAccuWeatherService
    {
        Task<City[]> GetLocations(string locationName);
        Task<Weather> GetCurrentConditions(string cityKey);
        Task<HistoricalCurrentConditions[]> GetHistoricalCurrentConditions(string cityKey);
        Task<City[]> GetTopCitiesList();
        Task<DailyForecastRoot> GetOneDayOfDailyForecasts(string cityKey);

    }
}
