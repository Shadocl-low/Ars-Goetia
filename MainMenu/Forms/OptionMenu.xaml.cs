using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
using MainMenu.Pages;

namespace MainMenu
{
    /// <summary>
    /// Interaction logic for OptionMenu.xaml
    /// </summary>
    public partial class OptionMenu : Window
    {
        Controls controls = new Controls();
        Resolution resolution = new Resolution();
        List<LinearGradientBrush> linearGradientBrushes = new List<LinearGradientBrush>();
        public OptionMenu()
        {
            InitializeComponent();
            InitializeEmptyBrush();
            InitializeBrush();

            OptionControl.Content = controls;

        }
        protected void InitializeBrush()
        {
            LinearGradientBrush UnderlineBrush = new LinearGradientBrush();
            UnderlineBrush.StartPoint = new Point(0.5, 0);
            UnderlineBrush.EndPoint = new Point(0.5, 1);

            UnderlineBrush.GradientStops.Add(new GradientStop(Colors.Black, 0.7));
            UnderlineBrush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF454545"), 1));

            linearGradientBrushes.Add(UnderlineBrush);
        }
        protected void InitializeEmptyBrush()
        {
            LinearGradientBrush UnderlineBrush = new LinearGradientBrush();
            UnderlineBrush.StartPoint = new Point(0.5, 0);
            UnderlineBrush.EndPoint = new Point(0.5, 1);

            UnderlineBrush.GradientStops.Add(new GradientStop(Colors.Black, 0.7));
            UnderlineBrush.GradientStops.Add(new GradientStop(Colors.Black, 1));

            linearGradientBrushes.Add(UnderlineBrush);
        }
        private void QuitBtnOption_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Hide();

        }
        private void ShowGameOptions(object sender, RoutedEventArgs e)
        {
            OptionControl.Content = controls;

            GameOptionsUnderline.Background = linearGradientBrushes[1];
            WindowOptionsUnderline.Background = linearGradientBrushes[0];
        }

        private void ShowWindowOptions(object sender, RoutedEventArgs e)
        {
            OptionControl.Content = resolution;

            GameOptionsUnderline.Background = linearGradientBrushes[0];
            WindowOptionsUnderline.Background = linearGradientBrushes[1];
        }
        
    }
}
