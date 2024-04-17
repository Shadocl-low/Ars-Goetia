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
using System.Windows.Shapes;

namespace MainMenu
{
    /// <summary>
    /// Interaction logic for OptionMenu.xaml
    /// </summary>
    public partial class OptionMenu : Window
    {
        List<Page> ControlsPages = new List<Page>();
        List<LinearGradientBrush> linearGradientBrushes = new List<LinearGradientBrush>();
        public OptionMenu()
        {
            InitializeComponent();
            InitializeEmptyBrush();
            InitializeBrush();

            ControlsPages.Add(new OptionPages.Controls());
            ControlsPages.Add(new OptionPages.Window());
            OptionControl.Content = ControlsPages[0];
        }
        protected void InitializeBrush()
        {
            LinearGradientBrush ButtonUnderlineBrush = new LinearGradientBrush();
            ButtonUnderlineBrush.StartPoint = new Point(0.5, 0);
            ButtonUnderlineBrush.EndPoint = new Point(0.5, 1);

            ButtonUnderlineBrush.GradientStops.Add(new GradientStop(Colors.Black, 0.7));
            ButtonUnderlineBrush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF673535"), 1));

            linearGradientBrushes.Add(ButtonUnderlineBrush);
        }
        protected void InitializeEmptyBrush()
        {
            LinearGradientBrush ButtonUnderlineBrush = new LinearGradientBrush();
            ButtonUnderlineBrush.StartPoint = new Point(0.5, 0);
            ButtonUnderlineBrush.EndPoint = new Point(0.5, 1);

            ButtonUnderlineBrush.GradientStops.Add(new GradientStop(Colors.Black, 0.7));
            ButtonUnderlineBrush.GradientStops.Add(new GradientStop(Colors.Black, 1));

            linearGradientBrushes.Add(ButtonUnderlineBrush);
        }

        private void QuitBtnOption_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Task.Delay(1000);
            this.Hide();

        }

        private void ShowGameOptions(object sender, RoutedEventArgs e)
        {
            OptionControl.Content = ControlsPages[0];

            GameOptions.Background = linearGradientBrushes[1];
            WindowOptions.Background = linearGradientBrushes[0];
        }

        private void ShowWindowOptions(object sender, RoutedEventArgs e)
        {
            OptionControl.Content = ControlsPages[1];

            GameOptions.Background = linearGradientBrushes[0];
            WindowOptions.Background = linearGradientBrushes[1];
        }
    }
}
