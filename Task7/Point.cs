using System;
using System.IO;

namespace Task7
{
    public class Point
    {
        private double _x;
        public double X => _x;

        private double _y;
        public double Y => _y;
        public void ReadFromFile(StreamReader sr)
        { 
            var wrap = sr.ReadLine().Split(' ');
            _x = double.Parse(wrap[0]);
            _y = double.Parse(wrap[1]);
        }
        public double DistanceToPoint(Point p) =>                    
            Math.Sqrt((Math.Pow(_x - p._x, 2) + Math.Pow(_y - p._y, 2)));
    }
}