using Invoicing_WPF.Interfaces;
using Invoicing_WPF.Services;
using System.Windows;
using Unity;

namespace Invoicing_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IUserService, UserService>();

            var mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();
        }
    }
}