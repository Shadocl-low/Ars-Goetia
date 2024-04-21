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
using MainMenu.Forms;
using System.Windows.Threading;
using ItemCL;
using EntityCL;
using System.Xml.Linq;

namespace MainMenu
{
    /// <summary>
    /// Interaction logic for GameForm.xaml
    /// </summary>
    public partial class GameForm : Window
    {
        EscMenu Menu = new EscMenu();
        private DispatcherTimer GameTimer = new DispatcherTimer();
        private DispatcherTimer ShotsInterval = new DispatcherTimer();
        Random rand = new Random();
        
        private bool UpKeyPressed, DownKeyPressed, LeftKeyPressed, RightKeyPressed;
        private float SpeedX, SpeedY, Friction = 0.75f, Speed = 2;
        private double TargetAimY, TargetAimX;

        Rectangle KnightPlayer = CreateMainCharacter();
        List<Rectangle> Enemies = new List<Rectangle>();
        Player ActualKnightPlayer = new Player("Shadocl", 10, 10, 2, "Sword and shild", 5);
        public GameForm()
        {
            InitializeComponent();

            Enemies.Add(CreateArcherEnemy());

            AddToCanvas(Enemies[0], GameScreen, 1000, 200);
            AddToCanvas(KnightPlayer, GameScreen, 100, (int)Application.Current.MainWindow.Height / 2);

            GameScreen.Focus();
            GameTimer.Interval = TimeSpan.FromMilliseconds(16);
            GameTimer.Tick += GameTick;
            GameTimer.Start();

            ShotsInterval.Interval = TimeSpan.FromSeconds(6);
            ShotsInterval.Tick += ShotsTick;
            ShotsInterval.Start();
        }
        public static Rectangle CreateMainCharacter()
        {
            Rectangle KnightPlayer = new Rectangle();
            KnightPlayer.Height = 50;
            KnightPlayer.Width = 50;
            ImageBrush KnightImage = new ImageBrush();
            KnightImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/MainCharacter.png"));
            KnightPlayer.Fill = KnightImage;
            return KnightPlayer;
        }
        public static Rectangle CreateArcherEnemy()
        {
            Rectangle ArcherEnemy = new Rectangle();
            ArcherEnemy.Height = 50;
            ArcherEnemy.Width = 50;
            ImageBrush ArcherImage = new ImageBrush();
            ArcherImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/ArcherEnemy.png"));
            ArcherEnemy.Fill = ArcherImage;
            ScaleTransform ArcherScaleTransform = new ScaleTransform();
            ArcherScaleTransform.ScaleX = -1;
            ArcherScaleTransform.CenterX = 0.5;
            ArcherEnemy.RenderTransform = ArcherScaleTransform;
            return ArcherEnemy;
        }
        public static void AddToCanvas(Rectangle obj, Canvas GameScreen, int x, int y)
        {
            Canvas.SetLeft(obj, x);
            Canvas.SetTop(obj, y);
            GameScreen.Children.Add(obj);
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
        private List<double> Normalize(Canvas GameField, Rectangle Element, Rectangle Player)
        {
            double Model = Math.Sqrt(Math.Pow(Canvas.GetTop(Player), 2) + Math.Pow(Canvas.GetTop(Element), 2));
            double X = Canvas.GetLeft(Element) / Model;
            double Y = Canvas.GetTop(Element) / Model;
            return new List<double> { X, Y };
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

            PlayerHealth.Content = "HP: " + ActualKnightPlayer.HealthPoints;

            foreach (var element in GameScreen.Children.OfType<Rectangle>())
            {
                if (element is Rectangle && (string)element.Tag == "arrow" && Canvas.GetLeft(Enemies[0]) != Canvas.GetLeft(KnightPlayer))
                {
                    List<double> xy = Normalize(GameScreen, Enemies[0], KnightPlayer);
                    Canvas.SetLeft(element, Canvas.GetLeft(element) - ((Canvas.GetLeft(Enemies[0]) - TargetAimX) / xy[0]) * (Friction * 0.5));
                    Canvas.SetTop(element, Canvas.GetTop(element) - ((Canvas.GetTop(Enemies[0]) - TargetAimY) / xy[1]) * (Friction * 0.5));
                }
            }
        }
        private void ShotsTick(object sender, EventArgs e)
        {
            Rectangle newArrow = new Rectangle
            {
                Tag = "arrow",
                Height = 5,
                Width = 20,
                Fill = Brushes.Brown,
                Stroke = Brushes.Black
            };

            Canvas.SetLeft(newArrow, Canvas.GetLeft(Enemies[0]) - Enemies[0].Width);
            Canvas.SetTop(newArrow, Canvas.GetTop(Enemies[0]) + Enemies[0].Height / 2);

            GameScreen.Children.Add(newArrow);

            TargetAimY = Canvas.GetTop(KnightPlayer) + 25;
            TargetAimX = Canvas.GetLeft(KnightPlayer) + 25;
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
