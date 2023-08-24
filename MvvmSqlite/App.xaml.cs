using MvvmSqlite.Views;
using Prism.DryIoc;
using Prism.Ioc;
using System.Windows;
using System.Windows.Threading;

namespace MvvmSqlite
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App:PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell(Window shell)
        {
            var login = Container.Resolve<Login>();
            if (login.ShowDialog()==false)
            {
                Application.Current?.Shutdown();
            }
            else
            {
                base.InitializeShell(shell);
            }
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<Dispatcher>(() => Application.Current.Dispatcher);

        }
    }
}
