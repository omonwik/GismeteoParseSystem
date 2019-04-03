using System.Windows;

namespace UserView
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RefreshWeatherForecast();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshWeatherForecast();
        }

        private void RefreshWeatherForecast()
        {
            var forecast = GismeteoDataManager.GetActualForecast();

            City.Text = forecast.City;
            Temperature.Text = forecast.Temperature;
            Feeling.Text = forecast.Feeling;
            Wind.Text = forecast.Wind;
            Pressure.Text = forecast.Pressure;
            Humidity.Text = forecast.Humidity;
            GeomagneticField.Text = forecast.GeomagneticField;
            WaterTemperature.Text = forecast.WaterTemperature;
            LastUpdateDate.Content = forecast.ParseDate;
        }
    }
}
