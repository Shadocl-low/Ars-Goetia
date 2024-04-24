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
using EntityCL.Enemies;
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
        private float SpeedX, SpeedY, Friction = 0.75f, Speed = 5;
        private double TargetAimY, TargetAimX;

        List<ArcherC> EnemiesList = new List<ArcherC>();
        List<Rectangle> itemRemover = new List<Rectangle>();

        Player MainPlayer = new Player("Shadocl", 10, 10, 2, "Sword and shild", 5);
        ArcherC archer = new ArcherC();
        ArcherC archer2 = new ArcherC();
        public GameForm()
        {
            InitializeComponent();

            EnemiesList.Add(archer);
            
            AddToCanvas(EnemiesList[0].EntityRect, GameScreen, rand.Next(500, 1000), rand.Next(100, 700));

            AddToCanvas(MainPlayer.EntityRect, GameScreen, 100, (int)Application.Current.MainWindow.Height / 2);

            GameScreen.Focus();
            GameTimer.Interval = TimeSpan.FromMilliseconds(16);
            GameTimer.Tick += GameTick;
            GameTimer.Start();

            ShotsInterval.Interval = TimeSpan.FromSeconds(2);
            ShotsInterval.Tick += ShotsTick;
            ShotsInterval.Start();
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
            if (e.Key == Key.Q)
            {
                MainPlayer.DrinkEstus();
            }
        }
        private void GameTick(object sender, EventArgs e)
        {
            MainPlayer.Moving(GameScreen, UpKeyPressed, LeftKeyPressed, DownKeyPressed, RightKeyPressed, SpeedX, SpeedY, Speed, Friction);

            PlayerHealthBar.Value = MainPlayer.HealthPoints;
            RestEstus.Content = MainPlayer.AmoutOfEstus;

            foreach (var element in GameScreen.Children.OfType<Rectangle>())
            {
                if (element is Rectangle && (string)element.Tag == "arrow")
                {
                    Rect ArrowHitBox = new Rect(Canvas.GetLeft(element), Canvas.GetTop(element), element.Width, element.Height);

                    archer.arrow.Flying(TargetAimX, TargetAimY, itemRemover);

                    MainPlayer.SetHitBox();
                    if (MainPlayer.EntityHitBox.IntersectsWith(ArrowHitBox))
                    {
                        itemRemover.Add(element);
                        MainPlayer.TakeDamage(archer.AttackDamage);
                    }

                    if (Canvas.GetTop(element) < 10 || Canvas.GetLeft(element) < 10 || Canvas.GetLeft(element) > 1560 || Canvas.GetTop(element) > 850)
                    {
                        itemRemover.Add(element);
                    }
                }
            }

            foreach (Rectangle element in itemRemover)
            {
                GameScreen.Children.Remove(element);
            }

            if (MainPlayer.HealthPoints == 0)
            {
                GameOver("Don't lose healt next time, dude!");
            }
        }
        private void ShotsTick(object sender, EventArgs e)
        {
            EnemiesList[0].CreateArrow(GameScreen, MainPlayer);

            TargetAimX = Canvas.GetLeft(MainPlayer.EntityRect) + MainPlayer.EntityRect.Width / 2;
            TargetAimY = Canvas.GetTop(MainPlayer.EntityRect);
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
            ShotsInterval.Stop();
            MessageBox.Show(message, "ARS GOETIA");

            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
    }
}
