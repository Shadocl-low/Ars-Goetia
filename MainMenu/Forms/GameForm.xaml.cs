﻿using System;
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
using EntityCL;
using EntityCL.Enemies;
using System.Xml.Linq;
using ObjectsCL;
using MainMenu;
using System.Data;
using MainMenu.Forms.Caves;
using System.Runtime.CompilerServices;

namespace MainMenu
{
    public partial class GameForm : GameWindow
    {
        public GameForm()
        {
            InitializeComponent();

            Archers.Add(archer);
            Archers.Add(archer2);

            foreach (ArcherC archers in Archers)
            {
                AddToCanvas(archers.EntityRect, GameScreen, rand.Next(500, 1000), rand.Next(100, 700));
            }

            AddToCanvas(MainPlayer.EntityRect, GameScreen, 100, (int)Application.Current.MainWindow.Height / 2);

            GameScreen.Focus();
            GameTimer.Interval = TimeSpan.FromMilliseconds(16);
            GameTimer.Tick += GameTick;
            GameTimer.Start();

            ShotsInterval.Interval = TimeSpan.FromSeconds(rand.Next(3, 8));
            ShotsInterval.Tick += ShotsTick;
            ShotsInterval.Start();
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
            if (e.Key == Key.Q)
            {
                MainPlayer.DrinkEstus();
            }
            if (e.Key == Key.F)
            {
                MainPlayer.Attack(GameScreen, itemRemover);
            }
        }
        private void GameTick(object sender, EventArgs e)
        {
            MainPlayer.Moving(GameScreen, UpKeyPressed, LeftKeyPressed, DownKeyPressed, RightKeyPressed, SpeedX, SpeedY, Friction, SprintKeyPressed);

            PlayerHealthBar.Value = MainPlayer.HealthPoints;
            PlayerStaminaBar.Value = MainPlayer.Stamina;
            RestEstus.Content = MainPlayer.AmoutOfEstus;

            MainPlayer.SetHitbox();

            foreach (ArcherC archers in Archers)
            {
                archers.SetHitbox();
                archers.RotateRect(MainPlayer.EntityRect);

                archers.Death(itemRemover);
                if (archers.EntityHitBox.IntersectsWith(MainPlayer.AttackHitBox))
                {
                    MainPlayer.DeleteAttackHitbox();
                    archers.TakeDamage(MainPlayer.AttackDamage);
                }

                if (archers.arrow != null)
                {
                    archers.arrow.Flying(TargetAimX, TargetAimY, itemRemover);
                    archers.arrow.RemoveFromCanvas(itemRemover);
                }
            }

            foreach (var element in GameScreen.Children.OfType<Rectangle>())
            {
                if ((string)element.Tag == "arrow")
                {
                    Rect ArrowHitBox = new Rect(Canvas.GetLeft(element), Canvas.GetTop(element), element.Width, element.Height);

                    if (MainPlayer.EntityHitBox.IntersectsWith(ArrowHitBox))
                    {
                        itemRemover.Add(element);
                        MainPlayer.TakeDamage(archer.AttackDamage);
                    }
                }
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
                }
                if ((string)element.Tag == "door")
                {
                    Rect doorHitbox = new Rect(Canvas.GetLeft(element), Canvas.GetTop(element), element.Width, element.Height);
                    if (MainPlayer.EntityHitBox.IntersectsWith(doorHitbox))
                    {
                        RightKeyPressed = false;
                        Canvas.SetLeft(MainPlayer.EntityRect, Canvas.GetLeft(MainPlayer.EntityRect)-MainPlayer.EntityRect.Width);
                        GameTimer.Stop();
                        ShotsInterval.Stop();
                        new CaveStart().Show();
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
            foreach (ArcherC archers in Archers)
            {
                archers.CreateArrow(GameScreen, MainPlayer);
            }
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
