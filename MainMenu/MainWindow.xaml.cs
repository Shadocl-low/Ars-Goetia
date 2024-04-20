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
        List<Window> Forms = new List<Window>();
        public MainWindow()
        {
            InitializeComponent();

            Forms.Add(new GameForm());
            Forms.Add(new OptionMenu());
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Forms[0].Show();
            Task.Delay(1000);
            this.Hide();
        }
        private void Option_Click(object sender, RoutedEventArgs e)
        {
            Forms[1].Show();
            Task.Delay(1000);
            this.Hide();
        }
        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
