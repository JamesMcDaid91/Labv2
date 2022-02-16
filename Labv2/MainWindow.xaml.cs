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

namespace Labv2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Entities db = new Entities();
        public MainWindow()
        {
            InitializeComponent();
        }
        //Ex1
        private void buttonQueryEx1_Click(object sender, RoutedEventArgs e)
        {
            var query = from c in db.Customers
                        select c.CompanyName;
            listboxCustomerEx1.ItemsSource = query.ToList();
        }

        private void buttonQueryEx2_Click(object sender, RoutedEventArgs e)
        {
            var query = from c in db.Customers
                        select c;
            DataGridCustomerEx2.ItemsSource = query.ToList().Distinct();
        }

        private void buttonQueryEx3_Click(object sender, RoutedEventArgs e)
        {
            var query = from o in db.Orders
                        where o.Customer.City.Equals("London")
                        || o.Customer.City.Equals("Paris")
                        || o.Customer.Country.Equals("USA")
                        orderby o.Customer.CompanyName
                        select new
                        {
                            CustomerName = o.Customer.CompanyName,
                            City = o.Customer.City,
                            Address = o.ShipAddress
                        };
            DataGridCustomerEx3.ItemsSource = query.ToList().Distinct();
        }

        private void buttonQueryEx4_Click(object sender, RoutedEventArgs e)
        {
            var query = from p in db.Products
                        where p.Category.CategoryName.Equals("Beverages")
                        orderby p.ProductID descending
                        select new
                        {
                            p.ProductID,
                            p.ProductName,
                            p.Category.CategoryName,
                            p.UnitPrice
                        };
            DataGridCustomerEx4.ItemsSource = query.ToList();
        }

        private void buttonQueryEx5_Click(object sender, RoutedEventArgs e)
        {
            Product p = new Product()
            {
                ProductName = "Kickapoo Jungle Joy Juice",
                UnitPrice = 12.49m,
                CategoryID = 1
            };

            db.Products.Add(p);
            db.SaveChanges();

            ShowProducts(DataGridCustomerEx5);
        }
        private void ShowProducts(DataGrid currentGrid)
        {
            var query = from p in db.Products
                        where p.Category.CategoryName.Equals("Beverages")
                        orderby p.ProductID descending
                        select new
                        {
                            p.ProductID,
                            p.ProductName,
                            p.Category.CategoryName,
                            p.UnitPrice
                        };

            currentGrid.ItemsSource = query.ToList();
        }

        private void buttonQueryEx6_Click(object sender, RoutedEventArgs e)
        {
            Product p1 = (db.Products.Where(p => p.ProductName.StartsWith("Kick")).Select(p => p).First());

            p1.UnitPrice = 100m;

            db.SaveChanges();
            ShowProducts(DataGridCustomerEx6);
        }

        private void buttonQueryEx7_Click(object sender, RoutedEventArgs e)
        {
            var products = from p in db.Products
                           where p.ProductName.StartsWith("Kick")
                           select p;
            foreach (var item in products)
            {
                item.UnitPrice = 100m;
            }

            db.SaveChanges();
            ShowProducts(DataGridCustomerEx7);
        }

        private void buttonQueryEx8_Click(object sender, RoutedEventArgs e)
        {
            var products = from p in db.Products
                           where p.ProductName.StartsWith("Kick")
                           select p;

            db.Products.RemoveRange(products);
            db.SaveChanges();
            ShowProducts(DataGridCustomerEx8);
        }

        private void buttonQueryEx9_Click(object sender, RoutedEventArgs e)
        {
            var query = db.Customers_By_City("London");
            DataGridCustomerEx9.ItemsSource = query.ToList();
        }
        

    }
}
