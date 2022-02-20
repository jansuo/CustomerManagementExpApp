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
using CustomersBLL.Services;

namespace CustomerManagementClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly ICustomerService _customerService;
        public MainWindow(ICustomerService customerService)
        {
            InitializeComponent();
            _customerService = customerService;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var customers = await _customerService.GetCustomersAsync();
                if (customers != null)
                {
                    DG.ItemsSource = customers;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }
    }
}
