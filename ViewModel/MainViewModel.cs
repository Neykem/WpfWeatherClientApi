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
        // Инициализация команды для загрузки новых данных о погоде
        public IAsyncRelayCommand ReloadedViewCommand { get; }
        // Инициализация свойств привязки данных 
        #region
        private string _apiKey;
        private string _cityName;
        private string _locationCode;
        private string _tempirature;
        private string _description;
        private string _windSpeed;
        private string _sourseImageWither;
        private string _textSearch;
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }
        public string TextSearch { get => _textSearch; set { _textSearch = value; OnPropertyChanged(); } }
        public string ApiKey { get => _apiKey;  set { _apiKey = value; OnPropertyChanged(); } }
        public string CityName { get => _cityName;  set { _cityName = value; OnPropertyChanged(); } }
        public string WindSpeed { get => _windSpeed; set { _windSpeed = value; OnPropertyChanged(); } }
        public string Description { get => _description; set { _description = value; OnPropertyChanged(); } }
        public string Tempirature { get => _tempirature; set { _tempirature = value; OnPropertyChanged(); } }
        public string LocationCode { get => _locationCode; set { _locationCode = value; OnPropertyChanged(); } }
        public string SourseImageWither { get => _sourseImageWither; set { _sourseImageWither = value; OnPropertyChanged(); } }
        #endregion 
        public MainViewModel()
        {
            CurrentView = this;
            ApiKey = "61ec2e2f7bc340da9d70fde7ce39d17d";
            TextSearch = "London";
            SourseImageWither = "/Style/Image/2.png";

            ReloadedViewCommand = new AsyncRelayCommand(CallCommandRellay);

        }
        //Асинхронный вызов для команды и заполнение свойств ноывми данными
        private async Task<WeatherDay> CallCommandRellay()
        {
            IWearherDayRepository wearherDayRepository = new WeatherDayRepository(_apiKey);
            var result = await wearherDayRepository.GetWeatherInCityForToday(_textSearch);

            Tempirature = (result.Main.Temp - 273).ToString("00") + '\u2103';
            CityName = result.Name;
            LocationCode = result.Coord.Lon.ToString() + " " + result.Coord.Lat.ToString();
            WindSpeed = result.Wind.Speed.ToString("00.0");
            Description = result.Weather.FirstOrDefault().Description;

            return result;
        }
    }
}
