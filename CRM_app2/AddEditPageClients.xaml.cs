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
    /// Interaction logic for AddEditPageClients.xaml
    /// </summary>
    public partial class AddEditPageClients : Page
    {
        private clients _currentClient = new clients();
        public AddEditPageClients(clients selectedClient)
        {
            if (selectedClient != null)
                _currentClient = selectedClient;
            InitializeComponent();
            DataContext = _currentClient;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrEmpty(_currentClient.name))
                errors.AppendLine("Укажите имя клиента");
            if (string.IsNullOrEmpty(_currentClient.phone_number))
                errors.AppendLine("Укажите номер телефона клиента");
            if (string.IsNullOrEmpty(_currentClient.name))
                errors.AppendLine("Укажите имя клиента");
            if (string.IsNullOrEmpty(_currentClient.name))
                errors.AppendLine("Укажите имя клиента");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            CRM_bdEntities.GetContext().clients.Add(_currentClient);
            try
            {
                CRM_bdEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            

        }
    }
}
