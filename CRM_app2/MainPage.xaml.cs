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

namespace CRM_app2
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Clients_button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ClientsPage());
        }

        private void Sales_Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ClientsPage());
        }

        private void Manager_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Products_Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ProductsPage());
        }
    }
}
