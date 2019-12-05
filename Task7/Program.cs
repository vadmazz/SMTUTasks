﻿using System;
using System.IO;

namespace Task7
{
    //                     Анализ
    //  - На плоскости задан прямоугольнгик 4 точками
    //    Если S больше заданной то трактор, иначе мотоблок
    //    Вывести координаты и чем его пахать
    //    1 м2 n - мотоблок, N - трактор
    //    Сколько бензина для вспашки участка?
    //  - usecases: считать из файла координаты прямоугольника,
    //                    считать из файла координаты точки
    //              определить технику для прямоугольника
    //                    проверить условие для промоугольника
    //              определить кол-во бензина.
    //  - entities: Point-Точка [Считать с файла, Определить дистанцию до],
    //              Rect-Прямоугольник [Считать с файла, Вычислить площадь],
    //              Tractor-техника [Абстрагировать выбор техники],
    //              BigTractor, SmallTractor-конкретная техника [Уточнить технику, Вычислить затраты бензина].
    class Program
    {
        static void Main(string[] args)
        {
            var rectangle = ReadRectangle("rectangle.txt");
            Tractor technique;
            if (IsBiggerThan(rectangle))
            {
                technique = new BigTractor("consumptions.txt");
            }
            else
                technique = new SmallTractor("consumptions.txt");
            Console.WriteLine(CreateMarkupString(technique, rectangle) + $"{technique}");
        }

        private static string CreateMarkupString(Tractor t, Rectangtle r) => 
            $"Rectangle data:\n{r.A.X}{r.A.Y}\n{r.B.X}{r.B.Y}" +
            $"\n{r.C.X}{r.C.Y}\n{r.D.X}{r.D.Y}\n" +
            $"Total Consumption: {t.GetTotalConsumption(r.GetSquare())}";
        
        private static bool IsBiggerThan(Rectangtle r) =>
            r.GetSquare() > double.Parse(Console.ReadLine());
     
        private static Rectangtle ReadRectangle(string path)
        {
            //using declaration from C# 8.0. Lifetime как у using{..,} 
            using var reader = new StreamReader(path);
            var rectangle = new Rectangtle();
            rectangle.ReadFromFile(reader);
            return rectangle;
        }
    }
}