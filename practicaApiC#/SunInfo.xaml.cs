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

namespace practicaApiC_
{
    /// <summary>
    /// Lógica de interacción para Page1.xaml
    /// </summary>
    public partial class SunInfo : Page
    {
        public SunInfo()
        {
            InitializeComponent();
        }

        private async void loadSunInfo_Click(object sender, RoutedEventArgs e)
        {
            var sunInfo = await SunProcessor.LoadSunInformation();

            sunriseText.Text = $"Sunrise is at {sunInfo.SunRise.ToLocalTime().ToShortTimeString()}";
            sunsetText.Text = $"Sunset is at {sunInfo.SunSet.ToLocalTime().ToShortTimeString()}";
        }
    }
}
