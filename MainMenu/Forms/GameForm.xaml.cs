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
using System.Windows.Navigation;
using MainMenu.Pages;
using System.Windows.Threading;
using ItemCL;

namespace MainMenu
{
    /// <summary>
    /// Interaction logic for GameForm.xaml
    /// </summary>
    public partial class GameForm : Window
    {
        EscMenu Menu = new EscMenu();
        private DispatcherTimer GameTimer = new DispatcherTimer();
        
        private bool UpKeyPressed, DownKeyPressed, LeftKeyPressed, RightKeyPressed;
        private float SpeedX, SpeedY, Friction = 0.75f, Speed = 2;
        public GameForm()
        {
            InitializeComponent();
            GameScreen.Focus();

            GameTimer.Interval = TimeSpan.FromMilliseconds(16);
            GameTimer.Tick += GameTick;
            GameTimer.Start();

            Item Box1 = new Box(100, 100, 50);
        }
        private void KeyBoardUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W)
            {
                UpKeyPressed = false;
            }
            if (e.Key == Key.A)
            {
                LeftKeyPressed = false;
            }
            if (e.Key == Key.S)
            {
                DownKeyPressed = false;
            }
            if (e.Key == Key.D)
            {
                RightKeyPressed = false;
            }
        }
        private void KeyBoardDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W)
            {
                UpKeyPressed = true;
            }
            if (e.Key == Key.A)
            {
                LeftKeyPressed = true;
            }
            if (e.Key == Key.S)
            {
                DownKeyPressed = true;
            }
            if (e.Key == Key.D)
            {
                RightKeyPressed = true;
            }
        }
        private void GameTick(object sender, EventArgs e)
        {
            if (UpKeyPressed && Canvas.GetTop(KnightPlayer) > 20)
            {
                SpeedY += Speed;
            }
            if (LeftKeyPressed && Canvas.GetLeft(KnightPlayer) > 20)
            {
                SpeedX -= Speed;
            }
            if (DownKeyPressed && Canvas.GetTop(KnightPlayer) < GameScreen.ActualHeight - 70)
            {
                SpeedY -= Speed;
            }
            if (RightKeyPressed && Canvas.GetLeft(KnightPlayer) < GameScreen.ActualWidth - 70)
            {
                SpeedX += Speed;
            }

            SpeedX = SpeedX * Friction;
            SpeedY = SpeedY * Friction;

            Canvas.SetTop(KnightPlayer, Canvas.GetTop(KnightPlayer) - SpeedY);
            Canvas.SetLeft(KnightPlayer, Canvas.GetLeft(KnightPlayer) + SpeedX);
        }

        private void ShowMenu(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape && EscMenuFrame.Content != Menu)
            {
                EscMenuFrame.Content = Menu;
                EscMenuFrame.Height = 860;
                EscMenuFrame.Width = 1920;
            }
            else if (e.Key == Key.Escape && EscMenuFrame.Content == Menu)
            {
                EscMenuFrame.Content = null;
            }
        }
        private void GameOver(string message)
        {
            GameTimer.Stop();
            MessageBox.Show(message, "ARS GOETIA");

            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
    }
}
