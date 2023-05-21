using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

using WpfWeatherClientApi.Domain;
using WpfWeatherClientApi.Domain.Interface;
using WpfWeatherClientApi.Model.Data;

namespace WpfWeatherClientApi.ViewModel
{
    internal class MainViewModel : ObservableObject 
    {
        public IAsyncRelayCommand ReloadedViewCommand { get; }

        private string _apiKey;
        private object _cityName;
        private string _locationCode;
        private string _tempirature;
        private string _description;
        private string _windSpeed;
        private string _sourseImageWither;
        private object _textSearch;
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }
        public object TextSearch
        {
            get { return _textSearch; }
            set { _textSearch = value; OnPropertyChanged(); }
        }

        public string ApiKey
        {
            get { return _apiKey; }
            set { _apiKey = value; OnPropertyChanged(); }
        }

        public string WindSpeed { get => _windSpeed; set { _windSpeed = value; OnPropertyChanged(); } }
        public string Description { get => _description; set { _description = value; OnPropertyChanged(); } }
        public string Tempirature { get => _tempirature; set { _tempirature = value; OnPropertyChanged(); } }
        public string LocationCode { get => _locationCode; set { _locationCode = value; OnPropertyChanged(); } }
        public object CityName 
        {
            get { return _textSearch; }
            set { _textSearch = value; OnPropertyChanged(); }
        }

        public string SourseImageWither { get => _sourseImageWither; set { _sourseImageWither = value; OnPropertyChanged(); } }

        public MainViewModel() : base()
        {
            CurrentView = this;
            ApiKey = "61ec2e2f7bc340da9d70fde7ce39d17d";
            TextSearch = "London";
            SourseImageWither = "/Style/Image/2.png";

            ReloadedViewCommand = new AsyncRelayCommand(CallCommandRellay);

        }

        private async Task<WeatherDay> CallCommandRellay()
        {
            IWearherDayRepository wearherDayRepository = new WeatherDayRepository(_apiKey);
            var result = await wearherDayRepository.GetWeatherInCityForToday("London");
            CityName = (result.Main.Temp - 273).ToString("00") + '\u2103';
            CurrentView = this;
            return result;
        }
    }
}
