﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task4
{
    //             Анализ
    //  -  В файле содержится список имен и соответствующие номера телефонов
    //     Найти номера по первой букве имени
    //  - usecases: считать номера телефонов с файла 
    //              выбрать записи по первой букве имени
    //  - structures: PhoneNumber-Номер телефона [Сформировать структуру номера телефона]
    //  - decomposing: [Получить PhoneNumber из файла, Запустить машину запросов, Найти PhoneNumber по букве ]
    class Program
    {
        struct PhoneNumber
        {
            public string Name;
            public int Number;
        }

        static void Main(string[] args)
        {
            var phoneNumbers = LoadData("../Numbers.txt");
            var output = Find(phoneNumbers, RunAnsweringMachine());
            foreach (var item in output)
                Console.WriteLine($"Имя: {item.Name}, Номер: {item.Number}");
        }

        private static char RunAnsweringMachine()
        {
            Console.WriteLine("Введите первую букву имени: ");
            return Convert.ToChar(Console.ReadLine());
        }

        private static List<PhoneNumber> Find(PhoneNumber[] pn, char lit) => 
            pn.Where(item => item.Name[0] == lit).ToList();
        
        private static PhoneNumber[] LoadData(string fileName)
        {
            string wrap;
            using (var file = new StreamReader(fileName))
            {
                wrap = file.ReadToEnd();
            }
            return ReadNumbers(wrap);
        }

        private static PhoneNumber[] ReadNumbers(string wrap)
        {
            var numbers = wrap.Split("\n");
            var array = new PhoneNumber[numbers.Length];

            for (var i = 0; i < numbers.Length; i++)
            {
                var temp = numbers[i].Split(" ");
                array[i].Name = temp[0];
                array[i].Number = Convert.ToInt32(temp[1]);
            }                      
            return array;
        }
    }
}
