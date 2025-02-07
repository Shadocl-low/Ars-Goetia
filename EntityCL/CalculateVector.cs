using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace EntityCL
{
    public static class CalculateVector
    {
        public static Vector2D GetVectorCoordinates(Rectangle element, double targetX, double targetY)
        {
            double x = targetX - Canvas.GetLeft(element);
            double y = targetY - Canvas.GetTop(element);
            return new Vector2D(x, y);
        }

        public static Vector2D Normalize(Rectangle element, double targetX, double targetY)
        {
            Vector2D vector = GetVectorCoordinates(element, targetX, targetY);
            return vector.Normalize();
        }

        public static double GetDeegrese(Rectangle element, double targetX, double targetY)
        {
            Vector2D vector = GetVectorCoordinates(element, targetX, targetY);
            return vector.Angle();
        }
    }
}
