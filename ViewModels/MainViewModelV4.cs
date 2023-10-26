﻿using CommunityToolkit.Mvvm.ComponentModel;
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
        // private HistoricalCurrentConditions[] _historicalCurrentConditions;
        private readonly IAccuWeatherService _accuWeatherService;
        // private readonly FavoriteCitiesView _favoriteCitiesView;
        // private readonly FavoriteCityViewModel _favoriteCityViewModel;


        // public MainViewModelV4(IAccuWeatherService accuWeatherService, FavoriteCityViewModel favoriteCityViewModel, FavoriteCitiesView favoriteCitiesView)
        public MainViewModelV4(IAccuWeatherService accuWeatherService)
        {
            // _favoriteCitiesView = favoriteCitiesView;
            // _favoriteCityViewModel = favoriteCityViewModel;
            _accuWeatherService = accuWeatherService;
            Cities = new ObservableCollection<CityViewModel>(); // podejście nr 2 
        }

        [ObservableProperty]
        private WeatherViewModel weatherView;


        public CityViewModel SelectedCity
        {
            get => _selectedCity;
            set
            {
                _selectedCity = value;
                OnPropertyChanged();
                LoadWeather();
            }
        }

         
        private async void LoadWeather()
        {
            if(SelectedCity != null)
            {
                _weather = await _accuWeatherService.GetCurrentConditions(SelectedCity.Key); 
                _dailyForecastRoot = await _accuWeatherService.GetOneDayOfDailyForecasts(SelectedCity.Key);
                // _historicalCurrentConditions = await _accuWeatherService.GetHistoricalCurrentConditions(SelectedCity.Key);

                // WeatherView = new WeatherViewModel(_weather, _dailyForecastRoot, _historicalCurrentConditions);
                WeatherView = new WeatherViewModel(_weather, _dailyForecastRoot);
            }
        } 

        // podajście nr 2 do przechowywania kolekcji obiektów:
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

        // [RelayCommand]
        // public void OpenFavotireCities()
        // {
        //     _favoriteCityViewModel.SelectedCity = new FavoriteCity() { Name = "Warsaw" };
        //     _favoriteCitiesView.Show();
        // }
    }
}