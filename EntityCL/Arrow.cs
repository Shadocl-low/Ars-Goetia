using EntityCL.Enemies;
using EntityCL.Interfaces;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Xml.Linq;
using System.Windows;
using System.Windows.Shapes;

namespace EntityCL
{
    public class Arrow
    {
        public EnemyAC Parent { get; protected set; }
        public Player Target { get; protected set; }
        public ArrowRenderer Renderer { get; protected set; }
        public System.Windows.Rect ArrowHitbox { get; protected set; }
        public double TargetAimX { get; protected set; }
        public double TargetAimY { get; protected set; }

        public Arrow(EnemyAC parent, Canvas screen, Player target)
        {
            Parent = parent;
            Target = target;
            Renderer = new ArrowRenderer(screen, parent, target);

            double targetAimY = Canvas.GetTop(Target.EntityRect);
            double targetAimX = Canvas.GetLeft(Target.EntityRect) + Target.EntityRect.Width / 2;
            Renderer.RotateArrow(targetAimX, targetAimY);
        }

        public void SetTargetAim(double AimX, double AimY)
        {
            TargetAimX = AimX;
            TargetAimY = AimY;
        }

        public void Flying(double TargetAimX, double TargetAimY, List<Rectangle> itemRemover)
        {
            List<double> xy = CalculateVector.Normalize(Parent.EntityRect, TargetAimX, TargetAimY);
            Renderer.UpdatePosition(xy[0] * 20, xy[1] * 20);
        }

        public void WallHit(List<Rectangle> itemRemover)
        {
            if (Canvas.GetTop(Renderer.ArrowRect) < 10 || Canvas.GetLeft(Renderer.ArrowRect) < 10 ||
                Canvas.GetLeft(Renderer.ArrowRect) > 1560 || Canvas.GetTop(Renderer.ArrowRect) > 850)
            {
                itemRemover.Add(Renderer.ArrowRect);
            }
        }

        public void SetArrowHitbox()
        {
            ArrowHitbox = new Rect(Canvas.GetLeft(Renderer.ArrowRect), Canvas.GetTop(Renderer.ArrowRect), Renderer.ArrowRect.Width, Renderer.ArrowRect.Height);
        }
    }
}
