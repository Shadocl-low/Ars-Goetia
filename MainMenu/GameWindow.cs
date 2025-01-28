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
        public float SpeedX { get; protected set; }
        public float SpeedY { get; protected set; }
        public const float DefaultFriction = 0.75f;
        private const string GameTitle = "ARS GOETIA";
        public InputManager inputManager;

        public EscMenu Menu = new EscMenu();

        public Random rand = new Random();

        public List<Rectangle> itemRemover = new List<Rectangle>();
        public List<EnemyAC> Enemies = new List<EnemyAC>();

        public DispatcherTimer GameTimer = new DispatcherTimer();
        public DispatcherTimer ShotsInterval = new DispatcherTimer();

        public Player MainPlayer = new Player("Shadocl", 10, 10, 1, "Sword and shild", 5);
        public GameWindow()
        {
            inputManager = new InputManager(MainPlayer);
        }
        public static void AddToCanvas<T>(T obj, Canvas gameScreen, int x, int y) where T : UIElement
        {
            Canvas.SetLeft(obj, x);
            Canvas.SetTop(obj, y);
            gameScreen.Children.Add(obj);
        }
        public void RestartGame()
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
        public void GameOver(string message)
        {
            GameTimer.Stop();
            ShotsInterval.Stop();
            MessageBox.Show(message, GameTitle);
            RestartGame();
        }
        public void AddEnemy(EnemyAC enemy, Canvas GameScreen, int x, int y)
        {
            Enemies.Add(enemy);
            AddToCanvas(enemy.EntityRect, GameScreen, x, y);
        }
        public void KeyBoardUp(object sender, KeyEventArgs e) => inputManager.HandleKey(e, false);
        public void KeyBoardDown(object sender, KeyEventArgs e) => inputManager.HandleKey(e, true);
    }
}
