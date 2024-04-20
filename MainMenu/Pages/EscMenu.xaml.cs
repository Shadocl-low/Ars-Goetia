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

namespace MainMenu.Pages
{
    /// <summary>
    /// Interaction logic for EscMenu.xaml
    /// </summary>
    public partial class EscMenu : Page
    {
        List<Window> Forms = new List<Window>();
        public EscMenu()
        {
            InitializeComponent();

        }
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            new OptionMenu().Show();
            Task.Delay(1000);
            new GameForm().Hide();
        }

        private void QuitToMenu_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Task.Delay(1000);
            new GameForm().Hide();
        }
        private void QuitFromGame_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
