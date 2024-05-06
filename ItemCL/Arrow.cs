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
        public Rectangle ArrowRect { get; protected set; }
        public Arrow(ArcherC parent, Canvas screen, Player terget)
        {
            Parent = parent;
            Screen = screen;
            Target = terget;

            ArrowRect = new Rectangle();
            ArrowRect.Tag = "arrow";
            ArrowRect.Height = 5;
            ArrowRect.Width = 20;
            ArrowRect.Fill = Brushes.Brown;
            ArrowRect.Stroke = Brushes.Black;
            ArrowRect.RenderTransformOrigin = new Point(0.5, 0.5);

            Canvas.SetLeft(ArrowRect, Canvas.GetLeft(Parent.EntityRect) - Parent.EntityRect.Width / 2);
            Canvas.SetTop(ArrowRect, Canvas.GetTop(Parent.EntityRect) + Parent.EntityRect.Height / 2);

            double TargetAimY = Canvas.GetTop(Target.EntityRect);
            double TargetAimX = Canvas.GetLeft(Target.EntityRect) + Target.EntityRect.Width / 2;

            ArrowRect.RenderTransform = new RotateTransform(Calculation.GetDeegrese(ArrowRect, TargetAimX, TargetAimY) * 180 / Math.PI);

            Screen.Children.Add(ArrowRect);
        }
        public void Flying(double TargetAimX, double TargetAimY, List<Rectangle> itemRemover)
        {
            List<double> xy = Calculation.Normalize(Parent.EntityRect, TargetAimX, TargetAimY);
            Canvas.SetLeft(ArrowRect, Canvas.GetLeft(ArrowRect) + (xy[0] * 20));
            Canvas.SetTop(ArrowRect, Canvas.GetTop(ArrowRect) + (xy[1] * 20));
        }
        public void RemoveFromCanvas(List<Rectangle> itemRemover)
        {
            if (Canvas.GetTop(ArrowRect) < 10 || Canvas.GetLeft(ArrowRect) < 10 || Canvas.GetLeft(ArrowRect) > 1560 || Canvas.GetTop(ArrowRect) > 850)
            {
                itemRemover.Add(ArrowRect);
            }
        }
    }
}
