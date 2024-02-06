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

namespace Koloskov41size
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public ProductPage()
        {
            InitializeComponent();

            var currentProduct = Koloskov41Entities.GetContext().Product.ToList();

            ProductListView.ItemsSource = currentProduct;

            ProductALL.Text = Convert.ToString(currentProduct.Count);

            ComboSort.SelectedIndex = 0;
            ComboFilt.SelectedIndex = 0;

            UpdateProduct();
        }

        private void UpdateProduct()
        {
            var currentProduct = Koloskov41Entities.GetContext().Product.ToList();

            if(ComboFilt.SelectedIndex == 0)
            {
                
            }
            if (ComboFilt.SelectedIndex == 1)
            {
                currentProduct = currentProduct.Where(p => (p.ProductCurrentDiscount >= 0 && p.ProductCurrentDiscount < 10)).ToList();
            }
            if (ComboFilt.SelectedIndex == 2)
            {
                currentProduct = currentProduct.Where(p => (p.ProductCurrentDiscount >= 10 && p.ProductCurrentDiscount < 15)).ToList();
            }
            if (ComboFilt.SelectedIndex == 3)
            {
                currentProduct = currentProduct.Where(p => (p.ProductCurrentDiscount >= 15)).ToList();
            }

            currentProduct = currentProduct.Where(p => p.ProductName.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

            if(ComboSort.SelectedIndex == 0)
            {

            }
            if (ComboSort.SelectedIndex == 1)
            {
                currentProduct = currentProduct.OrderBy(p => p.ProductCost).ToList();
            }
            if (ComboSort.SelectedIndex == 2)
            {
                currentProduct = currentProduct.OrderByDescending(p => p.ProductCost).ToList();
            }

            ProductRightNow.Text = Convert.ToString(currentProduct.Count);

            ProductListView.ItemsSource = currentProduct;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage());
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateProduct();
        }

        private void ComboFilt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProduct();
        }

        private void ComboSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProduct();
        }
    }
}
