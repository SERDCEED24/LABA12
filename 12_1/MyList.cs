using CarsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _12_1
{
    public class MyList<T> where T : IInit, ICloneable, new()
    {
        // Поля
        Point<T>? beg = null;
        Point<T>? end = null;
        int count = 0;

        // Свойство
        public int Count => count;

        // Конструкторы
        public MyList() { }
        public MyList(int size)
        {
            if (size < 0) throw new Exception("Размер списка не может быть меньше 0!");
            beg = MakeRandomData();
            end = beg;
            for (int i = 1; i < size; i++)
            {
                T newItem = MakeRandomItem();
                AddToEnd(newItem);
            }
            count = size;
        }
        public MyList(T[] collection)
        {
            if (collection == null)
                throw new Exception("Коллекция равна null!");
            if (collection.Length == 0)
                throw new Exception("Коллекция пуста!");
            T newData = (T)collection[0].Clone();
            beg = new Point<T>(newData);
            end = beg;
            for (int i = 1; i < collection.Length; i++)
            {
                AddToEnd(collection[i]);
            }
        }

        // Методы и статические функции
        public Point<T> GetBeg()
        {
            return beg;
        }
        public static Point<T> MakeRandomData()
        {
            T data = new T();
            data.RandomInit();
            return new Point<T>(data);
        }
        public static T MakeRandomItem()
        {
            T data = new T();
            data.RandomInit();
            return data;
        }
        public void AddToBegin(T item)
        {
            T newData = (T)item.Clone();
            Point<T> newItem = new Point<T>(newData);
            count++;
            if (beg != null)
            {
                beg.Prev = newItem;
                newItem.Next = beg;
                beg = newItem;
            }
            else
            {
                beg = newItem;
                end = beg;
            }
        }
        public void AddToEnd(T item)
        {
            T newData = (T)item.Clone();
            Point<T> newItem = new Point<T>(newData);
            count++;
            if (end != null)
            {
                end.Next = newItem;
                newItem.Prev = end;
                end = newItem;
            }
            else
            {
                beg = newItem;
                end = beg;
            }
        }
        public void Print()
        {
            if (count == 0)
                Console.WriteLine("Список пустой.");
            Point<T>? current = beg;
            for (int i = 0; current != null; i++)
            {
                Console.WriteLine(current);
                current = current.Next;
            }
        }
        public Point<T>? FindItem(T item)
        {
            Point<T>? current = beg;
            while (current != null)
            {
                if (current.Data == null)
                    throw new Exception("Data является null!");
                if (current.Data.Equals(item))
                    return current;
                current = current.Next;
            }
            return null;
        }
        public bool RemoveItem(T item)
        {
            if (beg == null) throw new Exception("Список пуст!");
            Point<T>? pos = FindItem(item);
            if (pos == null) return false;
            count--;
            // Один элемент
            if (beg == end)
            {
                beg = end = null;
                return true;
            }
            // Первый элемент
            if (pos.Prev == null)
            {
                beg = beg?.Next;
                beg.Prev = null;
                return true;
            }
            // Последний элемент
            if (pos.Next == null)
            {
                end = end?.Prev;
                end.Next = null;
                return true;
            }
            // Обычный элемент
            Point<T> prev = pos.Prev;
            Point<T> next = pos.Next;
            pos.Next.Prev = prev;
            pos.Prev.Next = next;
            return true;
        }
        public void Clear()
        {
            beg = end = null;
            count = 0;
        }
        public MyList<T> Clone()
        {
            MyList<T> listClone = new MyList<T>();
            Point<T>? current = beg;
            T? itemClone;
            while (current != null)
            {
                if (current.Data != null)
                {
                    itemClone = (T)current.Data.Clone();
                }
                else
                {
                    itemClone = default(T);
                }
                listClone.AddToEnd(itemClone);
                current = current.Next;
            }
            return listClone;
        }
    }
}

