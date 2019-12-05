﻿namespace Task6
{
    public class Circle
    {
        private Point _center;
        private double _radius;
        public Circle(Point p, double r)
        {
            _center = p;
            _radius = r;
        }
        public bool IsIntersect(Circle c) =>        
            (_radius + c._radius >=
             _center.DistanceToPoint(c._center));
        public string GetMarkupParameters() =>
            $"Центр: {_center.GetMarkupParameters()}\nРадиус: {_radius}";
    }
}