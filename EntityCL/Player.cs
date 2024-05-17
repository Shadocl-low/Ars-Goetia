using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
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
        public float Stamina { get; protected set; }
        public RotateTransform Rotating { get; protected set; }
        public bool IsHealing { get; protected set; }
        public Player(string name, int maxhp, int hp, int atk, string weapon, int estus) : base(name, maxhp, hp, atk)
        {
            Weapon = weapon;
            AmoutOfEstus = estus;
            Speed = 5;
            Stamina = 100f;
            ImuneState = false;
            IsHealing = false;

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
                IsHealing = true;
                AmoutOfEstus--;
                int HealthAmount = 2;
                Speed /= 5;
                while (HealthAmount > 0) 
                {
                    await Task.Delay(1000);
                    if (HealthPoints < MAXHealthPoints) HealthPoints += 1;
                    HealthAmount--;
                }
                IsHealing = false;
                Speed = 5;
            }
        }
        public void Moving(Canvas GameScreen, bool UpKeyPressed, bool LeftKeyPressed, bool DownKeyPressed, bool RightKeyPressed, float SpeedX, float SpeedY, float Friction, bool SprintKeyPressed)
        {
            if (UpKeyPressed && Canvas.GetTop(EntityRect) > 0)
            {
                SpeedY += Speed;
            }
            if (LeftKeyPressed && Canvas.GetLeft(EntityRect) > 0)
            {
                SpeedX -= Speed;
                RotateWay.ScaleX = -1;
            }
            if (DownKeyPressed && Canvas.GetTop(EntityRect) < GameScreen.ActualHeight - EntityRect.ActualHeight)
            {
                SpeedY -= Speed;
            }
            if (RightKeyPressed && Canvas.GetLeft(EntityRect) < GameScreen.ActualWidth - EntityRect.ActualWidth)
            {
                SpeedX += Speed;
                RotateWay.ScaleX = 1;
            }
            if (SprintKeyPressed)
            {
                if (Stamina > 0f && !IsHealing)
                {
                    Speed = 10;
                    Stamina--;
                }
                if (Stamina <= 0)
                {
                    Speed = 5;
                }
            }
            else if (!SprintKeyPressed)
            {
                if (Stamina <= 100f)
                {
                    Stamina += 0.5f;
                }
                if (!IsHealing)
                {
                    Speed = 5;
                }
            }

            SpeedX = SpeedX * Friction;
            SpeedY = SpeedY * Friction;

            EntityRect.RenderTransform = RotateWay;

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

            if (RotateWay.ScaleX == 1)
            {
                AttackHitBox = new Rect(Canvas.GetLeft(EntityRect) + 77, Canvas.GetTop(EntityRect) + EntityRect.Height / 2, 60, 30);
            }
            else
            {
                AttackHitBox = new Rect(Canvas.GetLeft(EntityRect) - 40, Canvas.GetTop(EntityRect) + EntityRect.Height / 2, 60, 30);
            }
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
