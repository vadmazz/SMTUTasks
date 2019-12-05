﻿using System;

namespace Calc
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("--itteration--");
                var a = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Otvet:" + Math.Pow(Math.Cos(( a / 180D ) * Math.PI), 2));
            }
        }
    }
}
