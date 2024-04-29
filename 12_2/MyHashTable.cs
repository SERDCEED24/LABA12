using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarsLibrary;

namespace _12_2
{
    public class MyHashTable<T> where T : IInit, ICloneable, new()
    {
        // Поля
        T[] table;
        int count = 0;
        double fillRatio;

        // Свойства
        public int Capacity => table.Length;
        public int Count => count;

        // Конструктор
        public MyHashTable(int size = 10, double fillRatio = 0.72)
        {
            table = new T[size];
            this.fillRatio = fillRatio;
        }

        //Методы
        public bool Contains(T data)
        {
            return !(FindItem(data) < 0);
        }
        public bool RemoveData(T data)
        {
            int index = FindItem(data);
            if (index < 0)
                return false;
            count--;
            table[index] = default;
            return true;
        }
        public void Print()
        {
            int i = 0;
            foreach (T item in table)
            {
                Console.WriteLine($"{i}:{item}");
                i++;
            }
        }
        public void AddItem(T item)
        {
            if ((double)Count / Capacity > fillRatio)
            {
                T[] temp = (T[])table.Clone();
                table = new T[temp.Length * 2];
                count = 0;
                for (int i = 0; i < temp.Length; i++)
                    AddData(temp[i]);
            }
            AddData(item);
        }
        private int GetIndex(T data)
        {
            return Math.Abs(data.GetHashCode()) % Capacity;
        }
        public void AddData(T data)
        {
            if (data == null)
                return;
            int index = GetIndex(data);
            int current = index;
            if (table[index] != null)
            {
                while (current < table.Length && table[current] != null)
                    current++;
                if (current == table.Length)
                {
                    current = 0;
                    while (current < index && table[current] != null)
                        current++;
                    if (current == index)
                    {
                        throw new Exception("Нет места в таблице!");
                    }
                }
            }
            table[current] = data;
            count++;
        }
        public int FindItem(T data)
        {
            int index = GetIndex(data);
            if (table[index] != null)
                return -1;
            if (table[index].Equals(data))
                return index;
            else
            {
                int current = index;
                while (current < table.Length)
                {
                    if (table[current] != null && table[current].Equals(data))
                        return current;
                    current++;
                }
                current = 0;
                while (current < index)
                {
                    if (table[current] != null && table[current].Equals(data))
                        return current;
                    current++;
                }
            }
            return -1;
        }
    }
}
