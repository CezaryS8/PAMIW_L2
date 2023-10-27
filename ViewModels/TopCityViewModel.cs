using P04WeatherForecastAPI.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public class TopCityViewModel
    {
        public string LocalizedName { get; set; }
        public string Key { get; set; }
        public string AdministrativeAreaLocalizedName { get; set; }

        public TopCityViewModel(City city)
        {
            LocalizedName = city.LocalizedName; 
            Key = city.Key;
            AdministrativeAreaLocalizedName = city.AdministrativeArea.LocalizedName;
        }

    }
}
