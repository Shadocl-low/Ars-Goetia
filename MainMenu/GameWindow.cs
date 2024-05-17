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
        public double TargetAimY { get; protected set; }
        public double TargetAimX { get; protected set; }
        public bool UpKeyPressed { get; protected set; }
        public bool DownKeyPressed { get; protected set; }
        public bool LeftKeyPressed { get; protected set; }
        public bool RightKeyPressed { get; protected set; }
        public float SpeedX { get; protected set; }
        public float SpeedY { get; protected set; }
        public float Friction = 0.75f;

        public EscMenu Menu = new EscMenu();

        public Random rand = new Random();

        public List<Rectangle> itemRemover = new List<Rectangle>();
        public List<ArcherC> Archers = new List<ArcherC>();

        public DispatcherTimer GameTimer = new DispatcherTimer();
        public DispatcherTimer ShotsInterval = new DispatcherTimer();

        public Player MainPlayer = new Player("Shadocl", 10, 10, 1, "Sword and shild", 5);
        public ArcherC archer = new ArcherC();
        public ArcherC archer2 = new ArcherC();
        public static void AddToCanvas(Rectangle obj, Canvas GameScreen, int x, int y)
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
    }
}
