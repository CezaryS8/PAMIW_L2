﻿using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using P04WeatherForecastAPI.Client.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.Services
{
    internal class AccuWeatherService : IAccuWeatherService
    {
        private const string base_url = "http://dataservice.accuweather.com";
        private const string autocomplete_endpoint = "locations/v1/cities/autocomplete?apikey={0}&q={1}&language={2}";
        private const string current_conditions_endpoint = "currentconditions/v1/{0}?apikey={1}&language={2}";
        private const string historical_current_conditions_endpoint = "currentconditions/v1/{0}/historical/24?apikey={1}&language={2}";
        private const string top_cities_list_endpoint = "locations/v1/topcities/50/?apikey={0}&language={1}";
        private const string one_day_of_daily_forecasts_endpoint = "forecasts/v1/daily/1day/{0}?apikey={1}&language={2}";

        // private const string one_day_of_daily_forecasts = "forecasts/v1/daily/1day/{0}?apikey={1}&language={2}";
        // "api_key":  "2QkvQQxu21HOJzf4rcEoeb7c2AanB7Mb"
        string api_key;
        string language;

        public AccuWeatherService()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<App>()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetings.json");

            var configuration = builder.Build();
            api_key = configuration["api_key"];
            language = configuration["default_language"];
        }


        public async Task<City[]> GetLocations(string locationName)
        {
            string uri = base_url + "/" + string.Format(autocomplete_endpoint, api_key, locationName, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                City[] cities = JsonConvert.DeserializeObject<City[]>(json);
                return cities;

            }
        }

        public async Task<Weather> GetCurrentConditions(string cityKey)
        {
            string uri = base_url + "/" + string.Format(current_conditions_endpoint, cityKey, api_key, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                Weather[] weathers = JsonConvert.DeserializeObject<Weather[]>(json);
                return weathers.FirstOrDefault();
            }
        }
        public async Task<HistoricalCurrentConditions[]> GetHistoricalCurrentConditions(string cityKey)
        {
            string uri = base_url + "/" + string.Format(historical_current_conditions_endpoint, cityKey, api_key, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                HistoricalCurrentConditions[] historicalCurrentConditionsArray = JsonConvert.DeserializeObject<HistoricalCurrentConditions[]>(json);
                return historicalCurrentConditionsArray;
            }
        }

        public async Task<City[]> GetTopCitiesList()
        {
            string uri = base_url + "/" + string.Format(top_cities_list_endpoint, api_key, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                City[] cities = JsonConvert.DeserializeObject<City[]>(json);
                return cities;
            }
        }

        public async Task<DailyForecastRoot> GetOneDayOfDailyForecasts(string cityKey)
        {
            string uri = base_url + "/" + string.Format(one_day_of_daily_forecasts_endpoint, cityKey, api_key, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                DailyForecastRoot dailyForecastRoot = JsonConvert.DeserializeObject<DailyForecastRoot>(json);
                return dailyForecastRoot;
            }
        }

    }

}
