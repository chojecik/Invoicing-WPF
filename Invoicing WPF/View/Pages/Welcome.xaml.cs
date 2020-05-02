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

namespace Invoicing_WPF.Pages
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome : Page
    {
        private readonly Frame _mainFrame;
        private readonly IUserService _userService;

        public Welcome(Frame mainFrame, IUserService userService)
        {
            _mainFrame = mainFrame;
            _userService = userService;
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Content = new Login(_mainFrame, _userService);
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Content = new Register(_userService, _mainFrame);
        }
    }
}
