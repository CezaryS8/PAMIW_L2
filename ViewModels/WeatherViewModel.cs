using P04WeatherForecastAPI.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public class WeatherViewModel
    {
        // public WeatherViewModel(Weather weather, DailyForecastRoot dailyForecastRoot, HistoricalCurrentConditions[] historicalCurrentConditions)
        public WeatherViewModel(Weather weather, DailyForecastRoot dailyForecastRoot)
        {
            CurrentTemperature = weather.Temperature.Metric.Value;
            HasPrecipitation = weather.HasPrecipitation;
            TodayMinTemperature = dailyForecastRoot.DailyForecasts[0].Temperature.Minimum.Value;
            TodayMaxTemperature = dailyForecastRoot.DailyForecasts[0].Temperature.Maximum.Value;
            // HistoricalCurrentConditions = historicalCurrentConditions;
        }
        public double CurrentTemperature { get; set; }
        public bool HasPrecipitation { get; set;}
        public double TodayMinTemperature { get; set; }
        public double TodayMaxTemperature { get; set; }
        // public HistoricalCurrentConditions[] HistoricalCurrentConditions { get; set; }

    }
}
