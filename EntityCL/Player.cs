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
using System.Xml.Linq;

namespace EntityCL
{
    public class Player : EntityAC
    {
        public Rect AttackHitBox { get; protected set; }
        public string Weapon { get; protected set; }
        public int AmoutOfEstus { get; protected set; }
        public int Speed { get; protected set; }
        public float Stamina { get; protected set; }
        public ImageBrush KnightImage { get; protected set; }
        private bool IsHealing { get; set; }
        private bool IsAttacking { get; set; }
        private bool IsShielded { get; set; }
        public int AmountOfSoulCoins { get; protected set; }
        public Player(string name, int maxhp, int hp, int atk, string weapon, int estus) : base(name, maxhp, hp, atk)
        {
            Weapon = weapon;
            AmoutOfEstus = estus;
            Speed = 5;
            Stamina = 100f;
            ImuneState = false;
            IsHealing = false;
            AmountOfSoulCoins = 0;

            EntityRect = new Rectangle();
            EntityRect.Height = 55;
            EntityRect.Width = 47;
            KnightImage = new ImageBrush();
            KnightImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Player/MainCharacterClaymore.png"));
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
        public void Moving(Canvas GameScreen, bool UpKeyPressed, bool LeftKeyPressed, bool DownKeyPressed, bool RightKeyPressed, float SpeedX, float SpeedY, float Friction)
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
        public override async void Attack()
        {
            IsAttacking = true;
            if (Stamina >= 30)
            {

                Stamina -= 30f;

                KnightImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Player/MainCharacterClaymoreAttack.png"));

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

                KnightImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Player/MainCharacterClaymore.png"));
                AttackHitBox = new Rect();
                EntityRect.Width = 47;
                EntityRect.Fill = KnightImage;
            }
            IsAttacking = false;
        }
        public void DeleteAttackHitbox()
        {
            AttackHitBox = new Rect();
        }
        public void Sprinting(bool SprintKeyPressed)
        {
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
                if (!IsHealing)
                {
                    Speed = 5;
                }
            }
        }
        public void SetSoulCoins(EnemyAC enemy)
        {
            AmountOfSoulCoins += enemy.SoulCoins;
        }
        public void StaminaRegen()
        {
            if (Stamina <= 100f)
            {
                Stamina += 0.5f;
            }
        }
        public void Block(bool BlockKeyPressed)
        {
            if (BlockKeyPressed)
            {
                Speed = 2;
                IsShielded = true;
                KnightImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Player/MainCharacterClaymoreShieldUp.png"));
            }
            else if (!IsAttacking)
            {
                IsShielded = false;
                KnightImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Player/MainCharacterClaymore.png"));
            }
        }
        public override void TakeDamageFrom(EntityAC Entity)
        {
            if (IsShielded && Stamina >= (Entity as EnemyAC).Strength)
            {
                ImuneState = true;
                Stamina -= (Entity as EnemyAC).Strength;
            }
            base.TakeDamageFrom(Entity);
        }
    }
}
