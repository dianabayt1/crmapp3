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
    /// Interaction logic for AddEditPageProducts.xaml
    /// </summary>
    public partial class AddEditPageProducts : Page
    {
        private products _currentProduct = new products();
        public AddEditPageProducts(products selectedProduct)
        {
            
            
            if (selectedProduct != null)
                _currentProduct = selectedProduct;
            InitializeComponent();
            DataContext = _currentProduct;
            ComboBox_Type.ItemsSource = CRM_bdEntities.GetContext().types.ToList();

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (_currentProduct.id_product == null)
                errors.AppendLine("Укажите ID");
            if (_currentProduct.type == null)
                errors.AppendLine("Укажите тип");
            if (_currentProduct.name == null)
                errors.AppendLine("Укажите название");
            if (_currentProduct.price == null)
                errors.AppendLine("Укажите цену");
            if (_currentProduct.added_bonuses == null)
                errors.AppendLine("Укажите добавляемые бонусы");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            
            CRM_bdEntities.GetContext().products.Add(_currentProduct);
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

        private void ComboBox_Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
