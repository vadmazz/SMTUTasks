using System;

namespace Task6
{
    //                   Анализ
    //  - Заданы 2 окружности пересекаются ли они?
    //    Заданы центром и радиусом
    //    Если не пересекаются вывести просто "Нет, не пересекаются"
    //    Если пересекаются то вывести да пересекаются и их характеристики
    //    Ввод характеристик производится с клавиатуры
    //  - usecases: считать характеристики 2 окружностей с клавиатуры, 
    //              проверить на пересечение
    //              вывести результат по итогам проверки
    //  - entities: Point-Точка [Определить дистанцию до],
    //              Circle-Окружность [Определить пересечение]
    //              Manager-Main(args) [Реализовать ответственность сущностей в текущей задаче]
    class Program
    {
        static void Main(string[] args)
        {
            var circles = ReadCircles();
            if (circles[0].IsIntersect(circles[1]))
                Console.WriteLine($"Да, пересекаются\n{circles[0].GetMarkupParameters()}\n" +
                                  $"{circles[1].GetMarkupParameters()}");
            else
                Console.WriteLine("Нет, не пересекаются");
        }
        private static Circle[] ReadCircles()
        {
            var circles = new Circle[2];
            circles[0] = ReadCircle();
            circles[1] = ReadCircle();
            return circles;
        }
        private static Circle ReadCircle()
        {
            Console.WriteLine("Введите координаты окружности через пробел: ");
            var w = Console.ReadLine().Split(' ');
            Console.WriteLine("Введите радиус");
            var r = double.Parse(Console.ReadLine());
            return new Circle(new Point(double.Parse(w[0]), double.Parse(w[1])),
                r);            
        }
    }
}