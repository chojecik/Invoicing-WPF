using Invoicing_WPF.Interfaces;
using Invoicing_WPF.View.Pages;
using System.Windows;
using System.Windows.Controls;

namespace Invoicing_WPF.Pages
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        private readonly IUserService _userService;
        private readonly Frame _mainFrame;
        private const string IncorrectCredentials = "Nieprawidłowy adres email lub hasło";
        public Login(Frame mainFrame, IUserService userService)
        {
            _mainFrame = mainFrame;
            _userService = userService;
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            var user = _userService.Authenticate(loginInput.Text, passwordInput.Password);

            if(user != null)
            {
                incorrectCredentials.Content = string.Empty;
                _mainFrame.Content = new Home(user, _userService, _mainFrame);
            }

            incorrectCredentials.Content = IncorrectCredentials;
        }
    }
}
