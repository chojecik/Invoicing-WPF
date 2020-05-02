using Invoicing_WPF.Database;
using Invoicing_WPF.Enums;
using Invoicing_WPF.Interfaces;
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

namespace Invoicing_WPF.View.Pages
{
    /// <summary>
    /// Interaction logic for CostInvoices.xaml
    /// </summary>
    public partial class CostInvoices : Page
    {
        private readonly IUserService _userService;
        public CostInvoices(IUserService userService, User user)
        {
            _userService = userService;
            InitializeComponent();

            dataGrid.ItemsSource = _userService.GetUsersInvoicesByType((int)user.UserId, InvoiceType.Cost);
        }
    }
}
