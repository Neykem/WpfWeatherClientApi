using System.Linq;
using System.Windows;
using WpfWeatherClientApi.Domain;
using WpfWeatherClientApi.Domain.Interface;

namespace WpfWeatherClientApi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        async private void Button_Click(object sender, RoutedEventArgs e)
        {
            IWearherDayRepository wearherDayRepository = new WeatherDayRepository("61ec2e2f7bc340da9d70fde7ce39d17d");

            var a = await wearherDayRepository.GetWeatherInCityForToday("London");
            
        }
    }
}
