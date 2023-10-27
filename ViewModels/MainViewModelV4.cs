using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using P04WeatherForecastAPI.Client.Commands;
using P04WeatherForecastAPI.Client.DataSeeders;
using P04WeatherForecastAPI.Client.Models;
using P04WeatherForecastAPI.Client.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    // przekazywanie wartosci do innego formularza 
    public partial class MainViewModelV4 : ObservableObject
    {
        private CityViewModel _selectedCity;
        private Weather _weather;
        private DailyForecastRoot _dailyForecastRoot;
        private HistoricalCurrentConditions[] _historicalCurrentConditions;
        private readonly IAccuWeatherService _accuWeatherService;
        public MainViewModelV4(IAccuWeatherService accuWeatherService)
        {
            _accuWeatherService = accuWeatherService;
            Cities = new ObservableCollection<CityViewModel>();
            TopCities = new ObservableCollection<TopCityViewModel>();
        }

        [ObservableProperty]
        private WeatherViewModel weatherView;
        [ObservableProperty]
        private TopCityViewModel topCityView;


        public CityViewModel SelectedCity
        {
            get => _selectedCity;
            set
            {
                _selectedCity = value;
                OnPropertyChanged();
                LoadWeather();
                // LoadTopCities();
            }
        }


        private async void LoadWeather()
        {
            if (SelectedCity != null)
            {
                _weather = await _accuWeatherService.GetCurrentConditions(SelectedCity.Key);
                _dailyForecastRoot = await _accuWeatherService.GetOneDayOfDailyForecasts(SelectedCity.Key);
                _historicalCurrentConditions = await _accuWeatherService.GetHistoricalCurrentConditions(SelectedCity.Key);

                WeatherView = new WeatherViewModel(_weather, _dailyForecastRoot, _historicalCurrentConditions);
            }
        }

        public ObservableCollection<CityViewModel> Cities { get; set; }

        [RelayCommand]
        public async void LoadCities(string locationName)
        {
            // podejście nr 2:
            var cities = await _accuWeatherService.GetLocations(locationName);
            Cities.Clear();
            foreach (var city in cities)
                Cities.Add(new CityViewModel(city));
        }

        public ObservableCollection<TopCityViewModel> TopCities { get; set; }

        [RelayCommand]
        public async void LoadTopCities()
        {
            var topCities = await _accuWeatherService.GetTopCitiesList();
            Cities.Clear();
            foreach (var city in topCities)
                TopCities.Add(new TopCityViewModel(city));
        }
    }
}
