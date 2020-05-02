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

namespace Invoicing_WPF.Pages
{
    /// <summary>
    /// Interaction logic for SaleInvoices.xaml
    /// </summary>
    public partial class SaleInvoices : Page
    {
        private readonly Frame _frame;
        public SaleInvoices(Frame frame)
        {
            _frame = frame;
            InitializeComponent();
        }

        private void GenerateSaleInvoiceBtn_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new GenerateSaleInvoice();
        }
    }
}
