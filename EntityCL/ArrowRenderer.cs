using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Shapes;

namespace EntityCL
{
    public class ArrowRenderer
    {
        public Rectangle ArrowRect { get; private set; }
        public Canvas Screen { get; private set; }

        public ArrowRenderer(Canvas screen, EnemyAC parent, Player target)
        {
            Screen = screen;
            ArrowRect = new Rectangle
            {
                Tag = "arrow",
                Height = 5,
                Width = 20,
                Fill = Brushes.Brown,
                Stroke = Brushes.Black,
                RenderTransformOrigin = new Point(0.5, 0.5)
            };

            Canvas.SetLeft(ArrowRect, Canvas.GetLeft(parent.EntityRect) + 15);
            Canvas.SetTop(ArrowRect, Canvas.GetTop(parent.EntityRect) + parent.EntityRect.Height / 2);
            Screen.Children.Add(ArrowRect);
        }

        public void RotateArrow(double targetAimX, double targetAimY)
        {
            ArrowRect.RenderTransform = new RotateTransform(CalculateVector.GetDeegrese(ArrowRect, targetAimX, targetAimY) * 180 / Math.PI);
        }

        public void UpdatePosition(double x, double y)
        {
            Canvas.SetLeft(ArrowRect, Canvas.GetLeft(ArrowRect) + x);
            Canvas.SetTop(ArrowRect, Canvas.GetTop(ArrowRect) + y);
        }
    }
}
