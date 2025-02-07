using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCL
{
    public class Vector2D
    {
        public double X { get; }
        public double Y { get; }

        public Vector2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double Length()
        {
            return Math.Sqrt(X * X + Y * Y);
        }

        public Vector2D Normalize()
        {
            double length = Length();
            return new Vector2D(X / length, Y / length);
        }

        public double Angle()
        {
            return Math.Atan2(Y, X);
        }

        public static Vector2D FromCoordinates(double x, double y)
        {
            return new Vector2D(x, y);
        }
    }
}
