using WpfWeatherClientApi.Domain;

namespace WpfWeatherClientApi.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        public RelayCommand ReloadedViewCommand { get; set; }

        private string _cityName;
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

        public string WindSpeed { get => _windSpeed; set { _windSpeed = value; OnPropertyChanged(); } }
        public string Description { get => _description; set { _description = value; OnPropertyChanged(); } }
        public string Tempirature { get => _tempirature; set { _tempirature = value; OnPropertyChanged(); } }
        public string LocationCode { get => _locationCode; set { _locationCode = value; OnPropertyChanged(); } }
        public string CityName { get => _cityName; set { _cityName = value; OnPropertyChanged(); } }
        public string SourseImageWither { get => _sourseImageWither; set { _sourseImageWither = value; OnPropertyChanged(); } }

        public MainViewModel()
        {
            CurrentView = this;
            SourseImageWither = "/Style/Image/2.png";

            ReloadedViewCommand = new RelayCommand(o =>
            {
                
            });
        }
    }
}
