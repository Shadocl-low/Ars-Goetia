using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Controls;
using System.Windows;

namespace EntityCL
{
    public class Player : EntityAC
    {
        public Rect AttackHitBox { get; protected set; }
        public string Weapon { get; protected set; }
        public int AmoutOfEstus { get; protected set; }
        public int Speed { get; protected set; }
        public Player(string name, int maxhp, int hp, int atk, string weapon, int estus) : base(name, maxhp, hp, atk)
        {
            Weapon = weapon;
            AmoutOfEstus = estus;
            Speed = 5;
            ImuneState = false;

            EntityRect = new Rectangle();
            EntityRect.Height = 55;
            EntityRect.Width = 47;
            ImageBrush KnightImage = new ImageBrush();
            KnightImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/MainCharacterClaymore.png"));
            EntityRect.Fill = KnightImage;
        }
        public async void DrinkEstus()
        {
            if (HealthPoints < MAXHealthPoints && AmoutOfEstus != 0)
            {
                AmoutOfEstus--;
                int HealthAmount = 2;
                Speed /= 5;
                while (HealthAmount > 0) 
                {
                    await Task.Delay(1000);
                    if (HealthPoints < MAXHealthPoints) HealthPoints += 1;
                    HealthAmount--;
                }
                Speed = 5;
            }
        }
        public void Moving(Canvas GameScreen, bool UpKeyPressed, bool LeftKeyPressed, bool DownKeyPressed, bool RightKeyPressed, float SpeedX, float SpeedY, float Friction)
        {
            if (UpKeyPressed && Canvas.GetTop(EntityRect) > 0)
            {
                SpeedY += Speed;
            }
            if (LeftKeyPressed && Canvas.GetLeft(EntityRect) > 0)
            {
                SpeedX -= Speed;
            }
            if (DownKeyPressed && Canvas.GetTop(EntityRect) < GameScreen.ActualHeight - EntityRect.ActualHeight)
            {
                SpeedY -= Speed;
            }
            if (RightKeyPressed && Canvas.GetLeft(EntityRect) < GameScreen.ActualWidth - EntityRect.ActualWidth)
            {
                SpeedX += Speed;
            }

            SpeedX = SpeedX * Friction;
            SpeedY = SpeedY * Friction;

            Canvas.SetTop(EntityRect, Canvas.GetTop(EntityRect) - SpeedY);
            Canvas.SetLeft(EntityRect, Canvas.GetLeft(EntityRect) + SpeedX);
        }
        public override void SetHitbox()
        {
            EntityHitBox = new Rect(Canvas.GetLeft(EntityRect), Canvas.GetTop(EntityRect), 47, 55);
        }
        public async void Attack(Canvas GameScreen, List<Rectangle> itemRemover)
        {
            ImageBrush KnightImage = new ImageBrush();
            KnightImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/MainCharacterClaymoreAttack.png"));

            AttackHitBox = new Rect(Canvas.GetLeft(EntityRect) + 77, Canvas.GetTop(EntityRect) + EntityRect.Height / 2, 60, 30);
            EntityRect.Width = 87;
            EntityRect.Fill = KnightImage;

            await Task.Delay(300);

            KnightImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/MainCharacterClaymore.png"));
            AttackHitBox = new Rect();
            EntityRect.Width = 47;
            EntityRect.Fill = KnightImage;
        }
        public void DeleteAttackHitbox()
        {
            AttackHitBox = new Rect();
        }
    }
}
