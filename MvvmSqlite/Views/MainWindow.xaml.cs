using System;
using System.Windows;

namespace MvvmSqlite.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //cmb_SexSelect.ItemsSource = Enum.GetNames(typeof(Sex));

        }
    }
    public enum Sex
    {
        男,
        女
    }

}
