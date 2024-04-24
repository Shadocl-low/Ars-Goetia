using MainMenu.Pages;
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

namespace MainMenu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OptionMenu optMenu = new OptionMenu();
        GameForm gameForm = new GameForm();
        KeysControl keys = new KeysControl();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = keys;
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            gameForm.Show();
            this.Hide();
        }
        private void Option_Click(object sender, RoutedEventArgs e)
        {
            optMenu.Show();
            this.Hide();
        }
        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
