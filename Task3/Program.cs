﻿using System;
using System.IO;

namespace Task3
{
    //             Анализ
    //  - Задание:  В файле описание домов, необходимо ответить по запросу пользователя на следующие вопросы:
    //              Сколько этажей в доме? Сколько жителей в доме?
    //              Сколько квартир на этаже и какие у них номера?
    //              Сколько жителей в заданной квартире?
    //  - usecases: считать описание домов с файла
    //              сформировать навигационные структуры данных
    //              Запустить машину запросов
    //                  Определить кол-во этажей в доме
    //                             кол-во жителей в доме
    //                             кол-во квартир на этаже
    //                             кол-во жителей в конкретной квартире
    //                   Пустой запрос, Выйти
    //  - structures: все структуры данных содержат только свойства, без поведения
    //                House-Дом [Хранит множество Этажей > Квартир]
    //                Floor-Этаж [Хранит множество Квартир]
    //                Flat-Квартира [Базовая структура данных]
    //                Question-Вариант запроса [Представление вариантов запросов в формате перечисления]
    //  - decomposing: [Считать дома из файла, Запустить машину запросов, Сформировать ответ на запрос]
    class Program
    {
        #region Структуры
        struct House
        {
            public int Id;
            public int Residents;
            public Floor[] Floors;
        }
        struct Floor
        {
            public int Id;
            public Flat[] Flats;
        }
        struct Flat
        {
            public int Id;
            public int ResidentsCount;
        }
        #endregion

        private enum Question
        {
            HowManyResidentsInHome,
            HowManyFloors,
            HowManyFlatsInFloor,
            HowManyResidentsInFlat,
            Quit,
            Unknown            
        } 

        static void Main(string[] args)
        {
            var houses = LoadData("../Houses.txt");
            RunQuestionHandler(houses);
        }

        private static Question ReadQuestionFromUser()
        {
            Console.WriteLine("Введите номер вопроса вопрос:\n0.Сколько жителей в доме?\n1. Сколько этажей в доме ?\n" +
                "2. Сколько квартир на этаже ?\n" +
                "3. Сколько жителей в заданной квартире ?\n4. Выход");
            return (Question)int.Parse(Console.ReadLine());
        }

        private static void RunQuestionHandler(House[] houses)
        {
            Question question = Question.Unknown;

            while (question != Question.Quit)
            {
                question = ReadQuestionFromUser();

                switch (question)
                {
                    case Question.HowManyResidentsInHome:
                        DoHowManyResidentsInHome(houses);
                        break;
                    case Question.HowManyFloors:
                        DoHowManyFloors(houses);
                        break;
                    case Question.HowManyFlatsInFloor:
                        DoHowManyFlatsInFloor(houses);
                        break;
                    case Question.HowManyResidentsInFlat:
                        DoHowManyResidentsInFlat(houses);
                        break;
                }
            }
            
        }

        private static void DoHowManyResidentsInFlat(House[] houses)
        {
            Console.WriteLine("Введите ID дома: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите ID этажа: ");
            int id2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите ID квартиры: ");
            int id3 = int.Parse(Console.ReadLine());
            Console.WriteLine($"В доме {id} на {id2} этаже в {id3} кватрите {houses[id].Floors[id2].Flats[id3].ResidentsCount} жителей");
        }

        private static void DoHowManyFlatsInFloor(House[] houses)
        {
            Console.WriteLine("Введите ID дома: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите ID этажа: ");
            int id2 = int.Parse(Console.ReadLine());
            Console.WriteLine($"В доме {id} на {id2} этаже {houses[id].Floors[id2].Flats.Length} квартир");
        }

        private static void DoHowManyFloors(House[] houses)
        {
            Console.WriteLine("Введите ID дома: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine($"В доме {id} {houses[id].Floors.Length} этажей");
        }

        private static void DoHowManyResidentsInHome(House[] houses)
        {
            Console.WriteLine("Введите ID дома: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine($"В доме {id} {houses[id].Residents} жителей"); 
        }

        private static House[] LoadData(string fileName)
        {
            string wrap;
            using (StreamReader file = new StreamReader(fileName))
            {
                wrap = file.ReadToEnd();                
            }
            return ReadHouses(wrap);
        }

        private static House[] ReadHouses(string wrap)
        {
            string[] houses = wrap.Split("\n");
            House[] housesArray = new House[houses.Length];
            
            for (int i = 0; i < houses.Length; i++)
            {
                housesArray[i].Id = Convert.ToInt32(houses[i][0]);
                housesArray[i].Residents = Convert.ToInt32(houses[i][3]);
                housesArray[i].Floors = new Floor[houses[i][1]];
                for (int j = 0; j < housesArray[i].Floors.Length; j++)                
                    housesArray[i].Floors[j].Flats = CreateFlats(housesArray[i].Residents, Convert.ToInt32(houses[i][2]));
                
            }
            return housesArray;
        }
        
        private static Flat[] CreateFlats(int houseResidentsCount, int floorsCount)
        {
            Flat[] res = new Flat[floorsCount];

            for (int i = 0; i < floorsCount; i++)
            {
                res[i].Id = i;
                res[i].ResidentsCount = houseResidentsCount / floorsCount;
            }
            return res;
        }
    }
}
