﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task5
{
    //             Анализ
    //  -  В файле есть отрезки. Определить из каких отрезков можно построить уникальные прямоугольные треугольники.
    //     Вывести эти отрезки.
    //  - usecases: считать характеристики 2 окружностей с клавиатуры, 
    //              проверить на пересечение
    //              вывести результат по итогам проверки
    //  - structures: Point-Точка [Считать из файла, Определить дистанцию до],
    //                Cut-Отрезок [Сериализовать из файла, Вычислить длину]
    //                Triangle-Треугольник [Сравнить с другим, Определить правильность]
    //  - decomposing: [Получить данные, Найти прямоугольные треугольники, Вывести отрезки прямоугльников]
    struct Point
    {
        private double _x;
        private double _y;

        public double DistanceToPoint(Point p) =>                    
            Math.Sqrt((Math.Pow(_x - p._x, 2) + Math.Pow(_y - p._y, 2)));        

        public void SerializeFromFile(StreamReader sr)
        {
            var wrap = sr.ReadLine().Split(' ');
            _x = double.Parse(wrap[0]);
            _y = double.Parse(wrap[1]);
        }
    }

    struct Cut
    {
        private Point _start;
        private Point _end;

        public double GetLength() =>                    
            _start.DistanceToPoint(_end);        

        public void SerializeFromFile(StreamReader sr)
        {
            _start.SerializeFromFile(sr);
            _end.SerializeFromFile(sr);
        }
    }

    struct Triangle
    {
        private Cut _a;
        private Cut _b;
        private Cut _c;

        public Triangle(Cut a, Cut b, Cut c)
        {
            _a = a;
            _b = b;
            _c = c;
        }
        public bool IsRight()
        {
            var a2 = Math.Pow(_a.GetLength(), 2);
            var b2 = Math.Pow(_b.GetLength(), 2);
            var c2 = Math.Pow(_c.GetLength(), 2);

            return a2 == b2 + c2 ||
                b2 == a2 + c2 ||
                c2 == b2 + a2;                         
        }
        public bool IsSame(Triangle tr)
        {
            var a2 = Math.Pow(_a.GetLength(), 2);
            var b2 = Math.Pow(_b.GetLength(), 2);
            var c2 = Math.Pow(_c.GetLength(), 2);

            return (a2 + b2 + c2 == Math.Pow(tr._a.GetLength(), 2) +
                Math.Pow(tr._b.GetLength(), 2) +
                Math.Pow(tr._c.GetLength(), 2));
        }
        public string GetInfo() =>       
            $"A: {_a.GetLength()} B: {_b.GetLength()} C: {_c.GetLength()}";        
    }

    class Program
    {
        static void Main(string[] args)
        {
            var cuts = ReadCutsFromFile();
            if (cuts != null)
            {
                var triangles = FindRightTriangles(cuts);
                if (triangles.Any())
                    ShowCuts(triangles);
                else
                    Console.WriteLine("Невозможно построить прямоугольный треугольник!");
            }
            else
                Console.WriteLine("Не удалось построить отрезки из файла!");
        }

        private static void ShowCuts(List<Triangle> triangles)
        {
            Console.WriteLine("Можно построить прямоугольные треугольники из следующих отрезков: ");
            foreach (var triangle in triangles)
            {
                Console.WriteLine(triangle.GetInfo());
            }
        }
        private static List<Triangle> FindRightTriangles(List<Cut> cuts)
        {
            var result = new List<Triangle>();
            foreach (var cut1 in cuts)
            {
                foreach (var cut2 in cuts)
                {
                    foreach (var cut3 in cuts)
                    {
                        var triangle = new Triangle(cut1, cut2, cut3);
                        if (triangle.IsRight())
                        {
                            if (result.Any())
                                foreach (var item in result)
                                {
                                    if (!triangle.IsSame(item))
                                        result.Add(triangle);
                                }
                            else
                                result.Add(triangle);
                        }                            
                    }
                }
            }
            return result;
        }
        private static List<Cut> ReadCutsFromFile()
        {            
            var cuts = new List<Cut>();
            using (var sr = new StreamReader("Cuts.txt"))
            {
                while (!sr.EndOfStream)
                {
                    var cut = new Cut();
                    cut.SerializeFromFile(sr);
                    cuts.Add(cut);
                }
            }           
            return cuts;
        }
    }
}