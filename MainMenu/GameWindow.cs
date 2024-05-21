using EntityCL;
using EntityCL.Enemies;
using MainMenu.Forms.Caves;
using MainMenu.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MainMenu
{
    public class GameWindow : Window
    {
        public bool UpKeyPressed { get; protected set; }
        public bool DownKeyPressed { get; protected set; }
        public bool LeftKeyPressed { get; protected set; }
        public bool RightKeyPressed { get; protected set; }
        public bool SprintKeyPressed { get; protected set; }
        public bool BlockKeyPressed { get; protected set; }
        public float SpeedX { get; protected set; }
        public float SpeedY { get; protected set; }
        public float Friction = 0.75f;

        public EscMenu Menu = new EscMenu();

        public Random rand = new Random();

        public List<Rectangle> itemRemover = new List<Rectangle>();
        public List<EnemyAC> Enemies = new List<EnemyAC>();

        public DispatcherTimer GameTimer = new DispatcherTimer();
        public DispatcherTimer ShotsInterval = new DispatcherTimer();

        public Player MainPlayer = new Player("Shadocl", 10, 10, 1, "Sword and shild", 5);
        
        public static void AddToCanvas(Rectangle obj, Canvas GameScreen, int x, int y)
        {
            Canvas.SetLeft(obj, x);
            Canvas.SetTop(obj, y);
            GameScreen.Children.Add(obj);
        }
        public static void AddToCanvas(Control obj, Canvas GameScreen, int x, int y)
        {
            Canvas.SetLeft(obj, x);
            Canvas.SetTop(obj, y);
            GameScreen.Children.Add(obj);
        }
        public void GameOver(string message)
        {
            GameTimer.Stop();
            ShotsInterval.Stop();
            MessageBox.Show(message, "ARS GOETIA");

            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
        public void AddEnemy(EnemyAC enemy, Canvas GameScreen, int x, int y)
        {
            Enemies.Add(enemy);
            AddToCanvas(enemy.EntityRect, GameScreen, x, y);
        }
        public void KeyBoardUp(object sender, KeyEventArgs e)
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
            if (e.Key == Key.LeftShift)
            {
                SprintKeyPressed = false;
            }
            if (e.Key == Key.LeftCtrl)
            {
                BlockKeyPressed = false;
            }
        }
        public void KeyBoardDown(object sender, KeyEventArgs e)
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
            if (e.Key == Key.LeftShift)
            {
                SprintKeyPressed = true;
            }
            if (e.Key == Key.LeftCtrl)
            {
                BlockKeyPressed = true;
            }
            if (e.Key == Key.Q)
            {
                MainPlayer.DrinkEstus();
            }
            if (e.Key == Key.F)
            {
                MainPlayer.Attack();
            }
        }
    }
}
