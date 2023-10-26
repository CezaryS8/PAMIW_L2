using P04WeatherForecastAPI.Client.Models;
using P04WeatherForecastAPI.Client.Services;
using P04WeatherForecastAPI.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace P04WeatherForecastAPI.Client
{    
    public partial class MainWindow : Window
    {
        private readonly MainViewModelV4 _viewModel;
        public MainWindow(MainViewModelV4 viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
            //accuWeatherService = new AccuWeatherService();
        }

        // AccuWeatherService accuWeatherService;
        // public MainWindow()
        // {
        //     InitializeComponent();
        //     accuWeatherService = new AccuWeatherService();
        // }

        // private async void btnSearch_Click(object sender, RoutedEventArgs e)
        // {
            
        //     City[] cities= await accuWeatherService.GetLocations(txtCity.Text);

        //     lbData.ItemsSource = cities;
        // }
        

        // private async void lbData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        // {
        //     var selectedCity= (City)lbData.SelectedItem;
        //     if(selectedCity != null)
        //     {
        //         var weather = await accuWeatherService.GetCurrentConditions(selectedCity.Key);
        //         lblCityName.Content = selectedCity.LocalizedName;
        //         double tempValue = weather.Temperature.Metric.Value;
        //         lblTemperatureValue.Content = Convert.ToString(tempValue);

        //         HistoricalCurrentConditions[] historicalCurrentConditionsArray= await accuWeatherService.GetHistoricalCurrentConditions(selectedCity.Key);
        //         lbHistoricalCurrentConditions.ItemsSource = historicalCurrentConditionsArray;

        //         DailyForecastRoot dailyForecastRoot= await accuWeatherService.GetOneDayOfDailyForecasts(selectedCity.Key);
        //         DailyForecast dailyForecast = dailyForecastRoot.DailyForecasts[0];
        //         double minTempValue = dailyForecast.Temperature.Minimum.Value;
        //         lblMinTemperatureValue.Content = Convert.ToString(minTempValue);
        //         double maxTempValue = dailyForecast.Temperature.Maximum.Value;
        //         lblMaxTemperatureValue.Content = Convert.ToString(maxTempValue);

        //     }
        // }
        // private async void btnSearchTopCities_Click(object sender, RoutedEventArgs e)
        // {
            
        //     City[] topCities= await accuWeatherService.GetTopCitiesList();

        //     lbTopCities.ItemsSource = topCities;
        // }
        

    }
}
