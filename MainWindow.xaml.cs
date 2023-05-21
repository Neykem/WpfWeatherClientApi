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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void Window_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            this.DragMove();
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
