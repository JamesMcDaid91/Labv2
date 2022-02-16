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
        //Ex2

    }
}
