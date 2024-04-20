using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MainMenu.Forms
{
    /// <summary>
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        public SplashScreen()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            SplashScreenImage.Opacity += 1;
            if (SplashScreenImage.Opacity > 3)
            {
                timer.Stop();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Task.Delay(1000).Wait();
                this.Close();
            }
        }
    }
}
