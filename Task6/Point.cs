using System;

namespace Task6
{
    public class Point
    {
        private double _x;
        private double _y;

        public Point(double x, double y)
        {
            _x = x;
            _y = y;
        }
        public double DistanceToPoint(Point p) =>
            Math.Sqrt(Math.Pow(_x - p._x, 2) + Math.Pow(_y - p._y, 2));
        public string GetMarkupParameters() =>
            $"X: {_x}, Y: {_y}";
    }
}