using EntityCL.Enemies;
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

namespace MainMenu.Forms.Caves
{
    /// <summary>
    /// Interaction logic for CaveMiddle.xaml
    /// </summary>
    public partial class CaveMiddle : GameWindow
    {
        public CaveMiddle()
        {
            InitializeComponent();

            AddEnemy(new GoblinC(MainPlayer), GameScreen, 1400, 300);
            AddEnemy(new GoblinC(MainPlayer), GameScreen, 1250, 700);
            AddEnemy(new GoblinC(MainPlayer), GameScreen, 900, 400);


            AddToCanvas(MainPlayer.EntityRect, GameScreen, 100, (int)Application.Current.MainWindow.Height / 2);

            GameScreen.Focus();
            GameTimer.Interval = TimeSpan.FromMilliseconds(16);
            GameTimer.Tick += GameTick;
            GameTimer.Start();
        }
        
        private void GameTick(object sender, EventArgs e)
        {
            PlayerHealthBar.Value = MainPlayer.HealthPoints;
            PlayerStaminaBar.Value = MainPlayer.Stamina;
            RestEstus.Content = MainPlayer.AmountOfEstus;
            RestCoins.Content = MainPlayer.AmountOfSoulCoins;

            MainPlayer.SetEntityBehavior(GameScreen, inputManager, DefaultFriction);

            foreach (var enemy in Enemies)
            {
                enemy.SetEntityBehavior(itemRemover);
            }

            foreach (var element in GameScreen.Children.OfType<Rectangle>())
            {
                if ((string)element.Tag == "wall")
                {
                    Rect wallHitbox = new Rect(Canvas.GetLeft(element), Canvas.GetTop(element), element.Width, element.Height);

                    if (inputManager.UpKeyPressed && MainPlayer.EntityHitBox.IntersectsWith(wallHitbox))
                    {
                        inputManager.UpKeyPressed = false;
                        Canvas.SetTop(MainPlayer.EntityRect, Canvas.GetTop(MainPlayer.EntityRect) + 5);
                    }
                    if (inputManager.LeftKeyPressed && MainPlayer.EntityHitBox.IntersectsWith(wallHitbox))
                    {
                        inputManager.LeftKeyPressed = false;
                        Canvas.SetLeft(MainPlayer.EntityRect, Canvas.GetLeft(MainPlayer.EntityRect) + 5);
                    }
                    if (inputManager.DownKeyPressed && MainPlayer.EntityHitBox.IntersectsWith(wallHitbox))
                    {
                        inputManager.DownKeyPressed = false;
                        Canvas.SetTop(MainPlayer.EntityRect, Canvas.GetTop(MainPlayer.EntityRect) - 5);
                    }
                    if (inputManager.RightKeyPressed && MainPlayer.EntityHitBox.IntersectsWith(wallHitbox))
                    {
                        inputManager.RightKeyPressed = false;
                        Canvas.SetLeft(MainPlayer.EntityRect, Canvas.GetLeft(MainPlayer.EntityRect) - 5);
                    }
                    foreach (var enemy in Enemies)
                    {
                        if (enemy.EntityHitBox.IntersectsWith(wallHitbox))
                        {
                            enemy.WallHit();
                        }
                    }
                }
                if ((string)element.Tag == "door")
                {
                    Rect doorHitbox = new Rect(Canvas.GetLeft(element), Canvas.GetTop(element), element.Width, element.Height);
                    if (MainPlayer.EntityHitBox.IntersectsWith(doorHitbox))
                    {
                        inputManager.RightKeyPressed = false;
                        Canvas.SetLeft(MainPlayer.EntityRect, Canvas.GetLeft(MainPlayer.EntityRect) - MainPlayer.EntityRect.Height);
                        GameTimer.Stop();
                        Enemies.Clear();
                        new CaveFinal().Show();
                        Close();
                    }
                }
            }

            foreach (Rectangle element in itemRemover)
            {
                GameScreen.Children.Remove(element);
            }

            if (MainPlayer.HealthPoints == 0)
            {
                GameOver("Don't lose health next time, dude!");
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
    }
}
