using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;
using System.Windows.Ink;
using System.Windows.Media.Media3D;
using EntityCL.Enemies;
using MainMenu;
using EntityCL;

namespace ItemCL
{
    public class Arrow
    {
        public ArcherC Parent { get; protected set; }
        public Canvas Screen { get; protected set; }
        public Player Target { get; protected set; }
        public Rectangle newArrow { get; protected set; }
        public Arrow(ArcherC parent, Canvas screen, Player terget)
        {
            Parent = parent;
            Screen = screen;
            Target = terget;

            newArrow = new Rectangle();
            newArrow.Tag = "arrow";
            newArrow.Height = 5;
            newArrow.Width = 20;
            newArrow.Fill = Brushes.Brown;
            newArrow.Stroke = Brushes.Black;
            newArrow.RenderTransformOrigin = new Point(0.5, 0.5);

            Canvas.SetLeft(newArrow, Canvas.GetLeft(Parent.EntityRect) - Parent.EntityRect.Width / 2);
            Canvas.SetTop(newArrow, Canvas.GetTop(Parent.EntityRect) + Parent.EntityRect.Height / 2);


            double TargetAimY = Canvas.GetTop(Target.EntityRect);
            double TargetAimX = Canvas.GetLeft(Target.EntityRect) + Target.EntityRect.Width / 2;

            newArrow.RenderTransform = new RotateTransform(Calculation.GetDeegrese(newArrow, TargetAimX, TargetAimY) * 180 / Math.PI);

            Screen.Children.Add(newArrow);
        }
        public void Flying(double TargetAimX, double TargetAimY, List<Rectangle> itemRemover)
        {
            List<double> xy = Calculation.Normalize(Parent.EntityRect, TargetAimX, TargetAimY);
            Canvas.SetLeft(newArrow, Canvas.GetLeft(newArrow) + (xy[0] * 20));
            Canvas.SetTop(newArrow, Canvas.GetTop(newArrow) + (xy[1] * 20));
        }
    }
}
