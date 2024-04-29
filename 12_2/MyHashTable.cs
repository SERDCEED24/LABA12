using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarsLibrary;

namespace _12_2
{
    public class MyHashTable<T> where T : IInit, ICloneable, new()
    {
        // Поле
        Point<T>?[] table;

        // Свойство
        public int Capacity => table.Length;

        // Конструктор
        public MyHashTable(int length = 10)
        {
            table = new Point<T>[length];
        }

        // Методы
        public void PrintTable()
        {
            for (int i = 0; i < table.Length; i++)
            {
                Console.WriteLine($"{i}:");
                if (table[i] == null)
                {
                    Console.WriteLine(table[i].Data);
                    if (table[i].Next != null)
                    {
                        Point<T>? current = table[i].Next;
                        while (current != null)
                        {
                            Console.WriteLine(current.Data);
                            current = current.Next;
                        }
                    }
                }
            }
        }
        public void AddPoint(T data)
        {
            int index = GetIndex(data);
            if (table[index] == null)
            {
                table[index] = new Point<T>(data);
            }
            else
            {
                Point<T>? current = table[index];
                while (current.Next != null)
                {
                    if (current.Equals(data))
                        return;
                    current = current.Next;
                }
                current.Next = new Point<T>(data);
                current.Next.Prev = current;
            }
        }
        public bool Contains(T data)
        {
            int index = GetIndex(data);
            if (table == null)
                throw new Exception("Таблица пуста!");
            if (table[index] == null)
                return false;
            if (table[index].Data.Equals(data))
                return true;
            else
            {
                Point<T>? current = table[index];
                while (current != null)
                {
                    if (current.Data.Equals(data))
                        return true;
                    current = current.Next;
                }
            }
            return false;
        }
        public bool RemoveData(T data)
        {
            Point<T>? current;
            int index = GetIndex(data);
            if (table[index] == null)
                return false;
            if (table[index].Data.Equals(data))
            {
                if (table[index].Next == null)
                    table[index] = null;
                else
                {
                    table[index] = table[index].Next;
                    table[index].Prev = null;
                }
                return true;
            }
            else
            {
                current = table[index];
                while (current != null)
                {
                    if (current.Data.Equals(data))
                    {
                        Point<T>? prev = current.Prev;
                        Point<T>? next = current.Next;
                        prev.Next = next;
                        current.Prev = null;
                        if (next != null)
                            next.Prev = prev;
                        return true;
                    }
                    current = current.Next;
                }
            }
            return false;
        }
        private int GetIndex(T data)
        {
            return Math.Abs(data.GetHashCode()) % Capacity;
        }
    }
}
