﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    //             Анализ
    //  - Подсчитать количество вхождений каждой буквы в строке
    //  - usecases: считать строку с клавиатуры
    //  -           получить количество вхождений букв
    //  - structures: LettersDictionary-Словарь букв
    //  - decomposing: [Считать строку с консоли, Сформировать словарь, Вычислить количество букв, Обновить словарь]
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToLower();
            var lettersDictionary = OccurrencesCount(input);
            Console.WriteLine($"Количество букв: ");
            
            foreach (var item in lettersDictionary)
            {
                Console.WriteLine($"{item.Key}: {item.Value} раз(а)");
            }
        }
        private static Dictionary<char, int> OccurrencesCount(string wrap)
        {
            var lettersDictionary = new Dictionary<char, int>();
            foreach (var item in wrap)
            {
                if (!lettersDictionary.ContainsKey(item))
                    lettersDictionary.Add(item, 1);

                foreach (var kpair in new Dictionary<char, int>(lettersDictionary)
                    .Where(kpair => kpair.Key == item))
                {
                    lettersDictionary[kpair.Key] = lettersDictionary[kpair.Key] + 1;
                }
            }
            return lettersDictionary;
        }
    }
}
