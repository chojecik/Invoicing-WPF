using Invoicing_WPF.Database;
using Invoicing_WPF.Interfaces;
using Invoicing_WPF.View.Pages;
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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        private readonly IUserService _userService;
        private readonly Frame _mainFrame;
        public Register(IUserService userService, Frame mainFrame)
        {
            _mainFrame = mainFrame;
            _userService = userService;
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var user = _userService.CreateUser(new User
            {
                FirstName = firstName.Text,
                LastName = lastName.Text,
                Email = email.Text
            }, password.Password);

            if(user != null)
            {
                _mainFrame.Content = new Home(user, _userService, _mainFrame);
            }
        }
    }
}
