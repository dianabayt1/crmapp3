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
    /// Interaction logic for ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        public ClientsPage()
        {
            InitializeComponent();
            //DGridClients.ItemsSource = CRM_bdEntities.GetContext().clients.ToList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPageClients((sender as Button).DataContext as clients));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPageClients(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var clientsForRemoving = DGridClients.SelectedItems.Cast<clients>().ToList();
            if(MessageBox.Show($"Вы точно хотите удалить следующие {clientsForRemoving.Count()} элементов?","Внимаение", 
                MessageBoxButton.YesNo,MessageBoxImage.Question)== MessageBoxResult.Yes)
            {
                try
                {
                    CRM_bdEntities.GetContext().clients.RemoveRange(clientsForRemoving);
                    CRM_bdEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DGridClients.ItemsSource = CRM_bdEntities.GetContext().clients.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                
                CRM_bdEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridClients.ItemsSource = CRM_bdEntities.GetContext().clients.ToList();

            }
        }
    }
}
