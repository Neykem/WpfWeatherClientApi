using System.Linq;
using System.Windows;
using WpfWeatherClientApi.Domain;
using WpfWeatherClientApi.Domain.Interface;

namespace WpfWeatherClientApi.View
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
    }
}
