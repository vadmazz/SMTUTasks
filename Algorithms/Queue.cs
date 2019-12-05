﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public class Data<T>
    {
        public T Array { get; set; }
        public Data<T> Next { get; set; } // ссылка на Next
 
        public Data(T data)
        {
            Array = data;
        }
    }
    public class Queue<T>
    {
        Data<T> head;
        Data<T> tail;
        int count;

        public void Enqueue(T data)// добавление
        {
            Data<T> temp = tail; //Сохраняем хвост очереди в буфер
            Data<T> dat = new Data<T>(data);
            tail = dat; // новый класс дата теперь конец
            if (count == 0)
                head = tail;
            else
                temp.Next = tail;
            count++;
        }

        public T Dequeue()
        {
            T output = head.Array;
            head = head.Next;
            count--;
            return output;
        }
    }
}
