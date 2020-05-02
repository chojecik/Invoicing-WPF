using Invoicing_WPF.Interfaces;
using Invoicing_WPF.Pages;
using System.Windows;

namespace Invoicing_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IUserService _userService;
        public MainWindow(IUserService userService)
        {
            _userService = userService;
            InitializeComponent();
            MainFrame.Content = new Welcome(MainFrame, _userService);
        }
    }
}
