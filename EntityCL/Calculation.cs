using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace EntityCL
{
    public static class Calculation
    {
        public static List<double> GetVectorCoordinates(Rectangle Element, double TargetX, double TargetY)
        {
            double Xcord = TargetX - Canvas.GetLeft(Element);
            double Ycord = TargetY - Canvas.GetTop(Element);
            return new List<double> { Xcord, Ycord };
        }
        public static List<double> Normalize(Rectangle Element, double TargetX, double TargetY)
        {
            List<double> Coordinates = GetVectorCoordinates(Element, TargetX, TargetY);
            double Model = Math.Sqrt(Math.Pow(Coordinates[0], 2) + Math.Pow(Coordinates[1], 2));
            double X = Coordinates[0] / Model;
            double Y = Coordinates[1] / Model;
            return new List<double> { X, Y };
        }
        public static double GetDeegrese(Rectangle Element, double TargetX, double TargetY)
        {
            List<double> Coordinates = GetVectorCoordinates(Element, TargetX, TargetY);
            return Math.Atan(Coordinates[1] / Coordinates[0]);
        }
    }
}
