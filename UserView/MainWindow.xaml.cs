using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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

namespace UserView
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

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            var adress = new Uri("http://127.0.0.1:4040/IContract");
            var bindings = new BasicHttpBinding();
            var endpoint = new EndpointAddress(adress);

            var factory = new ChannelFactory<IContract>(bindings, endpoint);
            var chanel = factory.CreateChannel();
            var forecast = chanel.GetData();

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
