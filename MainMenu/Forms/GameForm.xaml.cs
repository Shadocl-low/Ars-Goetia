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
        List<Rectangle> arrows = new List<Rectangle>();
        Player ActualKnightPlayer = new Player("Shadocl", 10, 10, 2, "Sword and shild", 5);
        public GameForm()
        {
            InitializeComponent();

            Enemies.Add(CreateArcherEnemy());

            for (int i = 0; i < Enemies.Count; i++)
            {
                AddToCanvas(Enemies[i], GameScreen, rand.Next(100, 1000), rand.Next(100, 700));
            }
            
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
        private List<double> GetVectorCoordinates(Rectangle Element, double TargetX, double TargetY)
        {
            double Xcord = TargetX - Canvas.GetLeft(Element);
            double Ycord = TargetY - Canvas.GetTop(Element);
            return new List<double> { Xcord, Ycord };
        }
        private List<double> Normalize(Rectangle Element, double TargetX, double TargetY)
        {
            List<double> Coordinates = GetVectorCoordinates(Element, TargetX, TargetY);
            double Model = Math.Sqrt(Math.Pow(Coordinates[0], 2) + Math.Pow(Coordinates[1], 2));
            double X = Coordinates[0] / Model;
            double Y = Coordinates[1] / Model;
            return new List<double> { X, Y };
        }
        private double GetDeegrese(Rectangle Element, double TargetX, double TargetY)
        {
            List<double> Coordinates = GetVectorCoordinates(Element, TargetX, TargetY);
            return Math.Atan(Coordinates[1]/ Coordinates[0]);
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
                if (element is Rectangle && (string)element.Tag == "arrow")
                {
                    for(int i = 0; i < Enemies.Count; i++)
                    {
                        List<double> xy = Normalize(Enemies[i], TargetAimX, TargetAimY);
                        Canvas.SetLeft(element, Canvas.GetLeft(element) + xy[0] * 20);
                        Canvas.SetTop(element, Canvas.GetTop(element) + xy[1] * 20);

                        Rect arrowHitBox = new Rect(Canvas.GetLeft(element), Canvas.GetTop(element), element.Width, element.Height);
                    
                        if (Canvas.GetTop(element) < 10 || Canvas.GetLeft(element) < 10 || Canvas.GetBottom(element) < 10 || Canvas.GetRight(element) < 10)
                        {
                            arrows.Remove(element);
                            //GameScreen.Children.Remove(element);
                        }
                    }
                }
            }
        }
        private void ShotsTick(object sender, EventArgs e)
        {
            int i = 0;
            for (i = 0; i < Enemies.Count; i++)
            {
                Rectangle newArrow = new Rectangle
                {
                    Tag = "arrow",
                    Height = 5,
                    Width = 20,
                    Fill = Brushes.Brown,
                    Stroke = Brushes.Black,
                };
                newArrow.RenderTransformOrigin = new Point(0.5, 0.5);
                arrows.Add(newArrow);

                Canvas.SetLeft(arrows[i], Canvas.GetLeft(Enemies[i]) - Enemies[i].Width / 2);
                Canvas.SetTop(arrows[i], Canvas.GetTop(Enemies[i]) + Enemies[i].Height / 2);


                TargetAimY = Canvas.GetTop(KnightPlayer);
                TargetAimX = Canvas.GetLeft(KnightPlayer) + KnightPlayer.Width / 2;

                arrows[i].RenderTransform = new RotateTransform(GetDeegrese(arrows[i], TargetAimX, TargetAimY) * 180 / Math.PI);

                GameScreen.Children.Add(arrows[i]);
            }
        }

        private void ShowMenu(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape && EscMenuFrame.Content != Menu)
            {
                EscMenuFrame.Content = Menu;
                EscMenuFrame.Height = 860;
                EscMenuFrame.Width = 1920;

                GameTimer.Stop();
                ShotsInterval.Stop();
            }
            else if (e.Key == Key.Escape && EscMenuFrame.Content == Menu)
            {
                EscMenuFrame.Content = null;
                GameTimer.Start();
                ShotsInterval.Start();
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
