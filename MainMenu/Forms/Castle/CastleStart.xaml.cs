using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using EntityCL;
using EntityCL.Enemies;
using ObjectsCL;
using MainMenu;
using MainMenu.Forms.Castle;

namespace MainMenu
{
    public partial class CastleStart : GameWindow
    {
        public CastleStart()
        {
            InitializeComponent();

            AddEnemy(new ArcherC(MainPlayer), GameScreen, 1250, 20);
            AddEnemy(new ArcherC(MainPlayer), GameScreen, 1250, 770);

            AddToCanvas(MainPlayer.EntityRect, GameScreen, 100, (int)Application.Current.MainWindow.Height / 2);

            GameScreen.Focus();
            GameTimer.Interval = TimeSpan.FromMilliseconds(16);
            GameTimer.Tick += GameTick;
            GameTimer.Start();

            ShotsInterval.Interval = TimeSpan.FromSeconds(rand.Next(3, 8));
            ShotsInterval.Tick += ShotsTick;
            ShotsInterval.Start();
        }
        private void GameTick(object sender, EventArgs e)
        {
            MainPlayer.SetEntityBehavior(GameScreen, inputManager.UpKeyPressed, inputManager.LeftKeyPressed, inputManager.DownKeyPressed, inputManager.RightKeyPressed, SpeedX, SpeedY, DefaultFriction, inputManager.SprintKeyPressed, inputManager.BlockKeyPressed);

            PlayerHealthBar.Value = MainPlayer.HealthPoints;
            PlayerStaminaBar.Value = MainPlayer.Stamina;
            RestEstus.Content = MainPlayer.AmoutOfEstus;
            RestCoins.Content = MainPlayer.AmountOfSoulCoins;

            foreach (var enemy in Enemies)
            {
                enemy.SetEntityBehavior(itemRemover);
            }

            foreach (var element in GameScreen.Children.OfType<Rectangle>())
            {
                if ((string)element.Tag == "arrow")
                {
                    Rect ArrowHitBox = new Rect(Canvas.GetLeft(element), Canvas.GetTop(element), element.Width, element.Height);

                    if (MainPlayer.EntityHitBox.IntersectsWith(ArrowHitBox))
                    {
                        itemRemover.Add(element);
                        MainPlayer.TakeDamageFrom(new ArcherC(MainPlayer));
                    }
                }
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
                        if (enemy is ArcherC && (enemy as ArcherC).arrow != null)
                        {
                            if ((enemy as ArcherC).arrow.ArrowHitbox.IntersectsWith(wallHitbox))
                            {
                                itemRemover.Add((enemy as ArcherC).arrow.ArrowRect);
                            }
                        }
                    }
                }
                if ((string)element.Tag == "door")
                {
                    Rect doorHitbox = new Rect(Canvas.GetLeft(element), Canvas.GetTop(element), element.Width, element.Height);
                    if (MainPlayer.EntityHitBox.IntersectsWith(doorHitbox))
                    {
                        inputManager.RightKeyPressed = false;
                        Canvas.SetLeft(MainPlayer.EntityRect, Canvas.GetLeft(MainPlayer.EntityRect) - MainPlayer.EntityRect.Width);
                        GameTimer.Stop();
                        Enemies.Clear();
                        ShotsInterval.Stop();
                        new CastleMiddle().Show();
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
        private void ShotsTick(object sender, EventArgs e)
        {
            foreach (ArcherC archers in Enemies)
            {
                archers.CreateArrow(GameScreen, MainPlayer);
                archers.arrow.SetTargetAim(Canvas.GetLeft(MainPlayer.EntityRect) + MainPlayer.EntityRect.Width / 2, Canvas.GetTop(MainPlayer.EntityRect));
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
