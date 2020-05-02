using Invoicing_WPF.Database;
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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        private readonly IUserService _userService;
        private readonly Frame _mainFrame;
        private readonly User user;
        public Home(User user, IUserService userService, Frame mainFrame)
        {
            _userService = userService;
            _mainFrame = mainFrame;
            this.user = user;
            InitializeComponent();
            welcomeLabel.Content = $"Witaj {user.FirstName} {user.LastName}";
        }

        private void costInvoicesBtn_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Content = new CostInvoices(_userService, user);
        }
    }
}
