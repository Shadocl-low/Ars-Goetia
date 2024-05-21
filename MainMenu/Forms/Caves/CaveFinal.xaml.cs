using EntityCL;
using EntityCL.Bosses;
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
    public partial class CaveFinal : GameWindow
    {
        public SlimeBoss KingSlime { get; protected set; }
        public CaveFinal()
        {
            InitializeComponent();

            KingSlime = new SlimeBoss(mainPlayer: MainPlayer, GameScreen, Enemies);

            Enemies.Add(KingSlime);

            foreach (var enemy in Enemies)
            {
                AddToCanvas(enemy.EntityRect, GameScreen, 1000, 300);
            }

            AddToCanvas(MainPlayer.EntityRect, GameScreen, 100, (int)Application.Current.MainWindow.Height / 2);
            AddToCanvas(KingSlime.HealthBar, GameScreen, 294, 16);

            GameScreen.Focus();
            GameTimer.Interval = TimeSpan.FromMilliseconds(16);
            GameTimer.Tick += GameTick;
            GameTimer.Start();
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
            if (e.Key == Key.LeftShift)
            {
                SprintKeyPressed = false;
            }
            if (e.Key == Key.LeftCtrl)
            {
                BlockKeyPressed = false;
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
        private void GameTick(object sender, EventArgs e)
        {
            MainPlayer.Moving(GameScreen, UpKeyPressed, LeftKeyPressed, DownKeyPressed, RightKeyPressed, SpeedX, SpeedY, Friction);
            MainPlayer.Sprinting(SprintKeyPressed);
            MainPlayer.StaminaRegen();
            MainPlayer.Block(BlockKeyPressed);

            PlayerHealthBar.Value = MainPlayer.HealthPoints;
            PlayerStaminaBar.Value = MainPlayer.Stamina;
            RestEstus.Content = MainPlayer.AmoutOfEstus;
            RestCoins.Content = MainPlayer.AmountOfSoulCoins;

            MainPlayer.SetHitbox();

            foreach (var enemy in Enemies)
            {
                enemy.SetEntityBehavior(itemRemover);
            }

            foreach (var element in GameScreen.Children.OfType<Rectangle>())
            {
                if ((string)element.Tag == "wall")
                {
                    Rect wallHitbox = new Rect(Canvas.GetLeft(element), Canvas.GetTop(element), element.Width, element.Height);

                    if (UpKeyPressed && MainPlayer.EntityHitBox.IntersectsWith(wallHitbox))
                    {
                        UpKeyPressed = false;
                        Canvas.SetTop(MainPlayer.EntityRect, Canvas.GetTop(MainPlayer.EntityRect) + 5);
                    }
                    if (LeftKeyPressed && MainPlayer.EntityHitBox.IntersectsWith(wallHitbox))
                    {
                        LeftKeyPressed = false;
                        Canvas.SetLeft(MainPlayer.EntityRect, Canvas.GetLeft(MainPlayer.EntityRect) + 5);
                    }
                    if (DownKeyPressed && MainPlayer.EntityHitBox.IntersectsWith(wallHitbox))
                    {
                        DownKeyPressed = false;
                        Canvas.SetTop(MainPlayer.EntityRect, Canvas.GetTop(MainPlayer.EntityRect) - 5);
                    }
                    if (RightKeyPressed && MainPlayer.EntityHitBox.IntersectsWith(wallHitbox))
                    {
                        RightKeyPressed = false;
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
                        RightKeyPressed = false;
                        Canvas.SetLeft(MainPlayer.EntityRect, Canvas.GetLeft(MainPlayer.EntityRect) - MainPlayer.EntityRect.Height);
                        GameTimer.Stop();
                        Enemies.Clear();
                        new CastleStart().Show();
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
                
                KingSlime.StopTimer();
                
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