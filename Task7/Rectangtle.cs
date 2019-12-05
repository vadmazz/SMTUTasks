﻿using System;
using System.IO;

namespace Task7
{
    public class Rectangtle
    {
        private Point _a = new Point();
        public Point A => _a;

        private Point _b = new Point();
        public Point B => _b;

        private Point _c = new Point();
        public Point C => _c;

        private Point _d = new Point();
        public Point D => _d;

        public void ReadFromFile(StreamReader sr)
        {
            _a.ReadFromFile(sr);
            _b.ReadFromFile(sr);
            _c.ReadFromFile(sr);
            _d.ReadFromFile(sr);
        }
        
        public double GetSquare()
        {
            var ab = GetLength(_a, _b);
            var bc = GetLength(_b, _c);
            var cd = GetLength(_c, _d);
            var da = GetLength(_d, _a);
            var h = (ab + bc + cd + da) / 2;//полупериметр

            return Math.Sqrt((h - ab) * (h - bc) * (h - cd) * (h - da));
        }
        private static double GetLength(Point a, Point b) =>                    
            a.DistanceToPoint(b);      
    }
}