using System;
using System.Collections.Generic;
using System.IO;

namespace Task8
{
    
    //                  Анализ
    //   - В файле находятся дома.
    //     Необходимо по заданному имени улицы вывести
    //     отсортированный список домов.
    //     Пользователь выбирает сортировать по количеству жильцов или по номеру дома,
    //     а также в порядке возрастания или убывания их выводить.
    //  -  usecases: Считать из файла Дома->Улицы,
    //               Принять у пользователя запрос,
    //                    Отсортировать дома по запросу
    //               Выдать ответ по запросу
    //  -  entities: House-Дом [Считать с файла],
    //               Street-Улица[],
//                   AnsweringMachine-Менеджер[Запустить машину запросов, Сортировать, Выдать ответ]
    class Program
    {
        struct House
        {
            public int Number;
            public Street Street;
            public int ResidentsCount;
            public void ReadFromFile(StreamReader sr)
            {
                var lines = sr.ReadLine().Trim().Split(',');
                Number = int.Parse(lines[1]);
                Street.Name = lines[0];
                ResidentsCount = int.Parse(lines[2]);
            }
        }
        struct Street
        {
            public string Name;
        }
        
        static void Main(string[] args)
        {
            var houses = ReadHouses("houses.txt");
            RunAnsweringMachine(ref houses);
            foreach (var house in houses)
            {
                Console.WriteLine(house.Number + " " + house.ResidentsCount);
            }
        }

        private static void RunAnsweringMachine(ref List<House> houses)
        {
            Console.WriteLine("Введите способ соритровки:\nПо числу жителей - 0\nПо Номеру дома - 1");
            var query = int.Parse(Console.ReadLine());
            switch (query)
            {
                case 0:
                    DoSortByCount(ref houses);
                    break;
                case 1:
                    DoSortByNumber(ref houses);
                    break;
                default:
                    Console.WriteLine("Неверно");
                    break;
            }
        }
        private static void DoSortByNumber(ref List<House> houses)
        {
            houses.Sort((house, house1) =>
            {
                if (house.Number > house1.Number) return 1;
                if (house.Number < house1.Number) return -1;
                return 0;
            });
        }
        private static void DoSortByCount(ref List<House> houses)
        {
            houses.Sort((house, house1) =>
            {
                if (house.ResidentsCount > house1.ResidentsCount) return 1;
                if (house.ResidentsCount < house1.ResidentsCount) return -1;
                return 0;
            });
        }
        private static List<House> ReadHouses(string path)
        {
            var output = new List<House>();
            using var sr = new StreamReader(path);
            while (!sr.EndOfStream)
            {
                var h = new House();
                h.ReadFromFile(sr);
                output.Add(h);   
            }
            return output;
        }
    }
}