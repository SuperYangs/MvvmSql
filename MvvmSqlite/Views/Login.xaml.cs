using MvvmSqlite.BLL;
using MvvmSqlite.ViewModels;
using System.Windows;

namespace MvvmSqlite.Views
{
    /// <summary>
    /// LoginView.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            //loginBLL.CreateLoginTable();
        }
    }
}
