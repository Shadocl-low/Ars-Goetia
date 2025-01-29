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
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Threading;
using System.Windows.Media.Media3D;

namespace EntityCL
{
    public class Player : EntityAC
    {
        public int AmountOfEstus { get; private set; }
        public int AmountOfSoulCoins { get; private set; }
        public int Speed { get; private set; }
        public float Stamina { get; private set; }
        public Rect AttackHitBox { get; private set; }
        public ImageBrush KnightImage { get; private set; }

        private bool IsHealing { get; set; }
        private bool IsAttacking { get; set; }
        private bool IsShielded { get; set; }

        private PlayerParam Parameters;
        public Player(string name, int hp, int atk, int coins, int estus) : base(name, hp, atk)
        {
            Parameters = new PlayerParam(hp, atk, coins, estus, 47, 55);

            ImuneState = false;
            IsHealing = false;

            SetupEntityParameters();
            SetupEntityAppearance();
        }
        private void SetupEntityParameters()
        {
            MAXHealthPoints = Parameters.MAXDefaultHealth;
            HealthPoints = Parameters.DefaultHealth;
            AttackDamage = Parameters.DefaultAttackDamage;
            AmountOfSoulCoins = Parameters.AmountOfSoulCoins;
            AmountOfEstus = Parameters.AmountOfEstus;
            Speed = Parameters.Speed;
            Stamina = Parameters.Stamina;
        }
        private void SetupEntityAppearance()
        {
            EntityRect = new Rectangle();
            EntityRect.Height = Parameters.EntityHeight;
            EntityRect.Width = Parameters.EntityWidth;
            KnightImage = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Player/MainCharacterClaymore.png"))
            };
            EntityRect.Fill = KnightImage;
        }
        public async void DrinkEstus()
        {
            if (HealthPoints < MAXHealthPoints && AmountOfEstus != 0)
            {
                IsHealing = true;
                AmountOfEstus--;
                Speed = Parameters.DefaultSpeed / 5;
                for (int i = 0; i < Parameters.EstusHealthRegen; i++)
                {
                    await Task.Delay(1000);
                    if (HealthPoints < MAXHealthPoints) HealthPoints++;
                }
                IsHealing = false;
                Speed = Parameters.DefaultSpeed;
            }
        }
        public void Moving(Canvas GameScreen, InputManager inputManager, float Friction)
        {
            float SpeedX = 0f;
            float SpeedY = 0f;

            if (inputManager.UpKeyPressed && Canvas.GetTop(EntityRect) > 0) SpeedY += Speed;
            if (inputManager.LeftKeyPressed && Canvas.GetLeft(EntityRect) > 0)
            {
                SpeedX -= Speed;
                RotateWay.ScaleX = -1;
            }
            if (inputManager.DownKeyPressed && Canvas.GetTop(EntityRect) < GameScreen.ActualHeight - EntityRect.ActualHeight) SpeedY -= Speed;
            if (inputManager.RightKeyPressed && Canvas.GetLeft(EntityRect) < GameScreen.ActualWidth - EntityRect.ActualWidth)
            {
                SpeedX += Speed;
                RotateWay.ScaleX = 1;
            }

            SpeedX *= Friction;
            SpeedY *= Friction;

            EntityRect.RenderTransform = RotateWay;

            Canvas.SetTop(EntityRect, Canvas.GetTop(EntityRect) - SpeedY);
            Canvas.SetLeft(EntityRect, Canvas.GetLeft(EntityRect) + SpeedX);
        }
        public override void SetHitbox()
        {
            EntityHitBox = new Rect(Canvas.GetLeft(EntityRect), Canvas.GetTop(EntityRect), Parameters.EntityWidth, Parameters.EntityHeight);
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
        public void SetEntityBehavior(Canvas GameScreen, InputManager manager, float Friction)
        {
            Moving(GameScreen, manager, Friction);
            Sprinting(manager.SprintKeyPressed);
            StaminaRegen();
            Block(manager.BlockKeyPressed);
            SetHitbox();
        }
        public override void TakeDamageFrom(EntityAC Entity)
        {
            if (IsShielded && !ImuneState && Stamina >= (Entity as EnemyAC).Strength)
            {
                ImuneState = true;
                ImuneTimer.Start();
                Stamina -= (Entity as EnemyAC).Strength;
            }
            if (!ImuneState && !IsShielded)
            {
                ImuneState = true;
                ImuneTimer.Start();
                HealthPoints -= Entity.AttackDamage;
            };
        }
    }
}
