using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CarsLibrary;

namespace _12_3
{
    public class MyTree<T> where T : IInit, IComparable, new()
    {
        // Поля
        Point<T>? root = null;
        int count = 0;

        // Свойство
        public int Count => count;

        // Конструктор
        public MyTree(int length)
        {
            count = length;
            root = MakeTree(length, root);
        }

        // Методы
        public void ShowTree()
        {
            Show(root);
        }
        Point<T>? MakeTree(int length, Point<T>? root)
        {
            if (length == 0)
            {
                return null;
            }
            T data = new T();
            data.RandomInit();
            Point<T> newItem = new Point<T>(data);
            int nl = length / 2;
            int nr = length - nl - 1;
            newItem.Left = MakeTree(nl, newItem.Left);
            newItem.Right = MakeTree(nr, newItem.Right);
            return newItem;
        }
        void Show(Point<T>? point, int spaces = 5)
        {
            if (point != null)
            {
                Show(point.Left, spaces + 5);
                Console.WriteLine(new string(' ', spaces) + point.Data);
                Show(point.Right, spaces + 5);
            }
        }
        void AddPoint(T data)
        {
            Point<T>? point = root;
            Point<T>? current = null;
            bool isExist = false;
            while (point != null && isExist)
            {
                current = point;
                if (point.Data.CompareTo(data) == 0)
                {
                    isExist = true;
                }
                else
                {
                    if (point.Data.CompareTo(data) < 0)
                    {
                        point = point.Left;
                    }
                    else
                    {
                        point = point.Right;
                    }
                }
            }
            if (isExist)
            {
                return;
            }
            Point<T> newPoint = new Point<T>(data);
            if (current.Data.CompareTo(data) < 0)
                current.Left = newPoint;
            else
                current.Right = newPoint;
            count++;
        }
        /*
        void TransformToArray(Point<T>? point, T[] array, ref int current)
        {
            if (point != null)
            {
                TransformToArray(point.Left,array, ref current);
                array[current] = point.Data;
                current++;
                TransformToArray(point.Right,array, ref current);
            }
        }
        public void TransformToFindTree()
        {
            T[] array = new T[count];
            int current = 0;
            TransformToArray(root, array,ref current);
            root = new Point<T>(array[0]);
            count = 0;
            for (int i = 1; i < array.Length; i++)
            {
                AddPoint(array[i]);
            }
        }
        */
        void TransformPointToFindTree(Point<T>? current)
        {
            if (current!= null)
            {
                TransformPointToFindTree(current.Left);
                AddPoint(current.Data);
                TransformPointToFindTree(current.Right);
            }
        }
        public void TransformToFindTree()
        {
            TransformPointToFindTree(root);
        }
    }
}
