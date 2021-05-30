using System;
using System.Collections.Generic;
using System.Diagnostics;
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


namespace Weather
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            listBox.ItemsSource = new DataProvider().GetWetherModels();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            listBox2.ItemsSource = new DataProviderPhenomena().GetWetherModels();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            listBox.ItemsSource = "0";
            listBox2.ItemsSource = "0";
        }
    }
}
