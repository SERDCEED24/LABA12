using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CarsLibrary;

namespace _12_3
{
    public class MyTree<T> where T : IInit, ICloneable, IComparable, new()
    {
        // Поля
        Point<T>? root = null;
        int count = 0;

        // Свойства
        public int Count => count;
        public Point<T>? Root => root;

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
            while (point != null && !isExist)
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
        public void TransformToSearchTree()
        {
            Stack<Point<T>> inS = new Stack<Point<T>>();
            Stack<Point<T>> outS = new Stack<Point<T>>();
            Point<T> item, temp;
            if (root != null)
            {
                inS.Push(root);
                while (inS.Count > 0)
                {
                    temp = inS.Pop();
                    outS.Push(temp);
                    if (temp.Left != null)
                        inS.Push(temp.Left);
                    if (temp.Right != null)
                        inS.Push(temp.Right);
                }
                root = new Point<T>(outS.Pop().Data);
                while (outS.Count > 0)
                {
                    item = outS.Pop();
                    AddPoint((T)item.Data);
                }
            }
        }
        public void NumberOfLeavesInBranches(Point<T>? point, ref int k)
        {
            if (point != null)
            {
                NumberOfLeavesInBranches(point.Left, ref k);
                if (point.Left == null && point.Right == null)
                {
                    k++;
                }
                NumberOfLeavesInBranches(point.Right, ref k);
            }
        }
        public int NumberOfLeaves()
        {
            int n = 0;
            NumberOfLeavesInBranches(root, ref n);
            return n;
        }
        public MyTree<T> Clone()
        {
            MyTree<T> clonedTree = new MyTree<T>(0);
            clonedTree.root = ClonePoint(this.root);
            clonedTree.count = this.count;
            return clonedTree;
        }
        private Point<T>? ClonePoint(Point<T>? point)
        {
            if (point == null)
            {
                return null;
            }
            T clonedData = (T)point.Data.Clone();
            Point<T> clonedPoint = new Point<T>(clonedData);
            clonedPoint.Left = ClonePoint(point.Left);
            clonedPoint.Right = ClonePoint(point.Right);
            return clonedPoint;
        }
        void ClearFromPoint(Point<T>? point)
        {
            if (point != null)
            {
                ClearFromPoint(point.Left);
                ClearFromPoint(point.Right);
                point.Left = null;
                point.Right = null;
            }
        }
        public void Clear()
        {
            ClearFromPoint(root);
            root = null;
            count = 0;
        }
        public bool Remove(T key)
        {
            bool isRemoved;
            (root, isRemoved) = RemoveFromPoint(root, key);
            if (isRemoved)
            {
                count--;
            }
            return isRemoved;
        }
        private (Point<T>?, bool) RemoveFromPoint(Point<T>? point, T key)
        {
            if (point == null)
            {
                return (null, false);
            }

            int compare = key.CompareTo(point.Data);

            if (compare > 0)
            {
                (point.Left, var isRemoved) = RemoveFromPoint(point.Left, key);
                return (point, isRemoved);
            }
            else if (compare < 0)
            {
                (point.Right, var isRemoved) = RemoveFromPoint(point.Right, key);
                return (point, isRemoved);
            }
            else
            {
                if (point.Left == null)
                {
                    return (point.Right, true);
                }
                else if (point.Right == null)
                {
                    return (point.Left, true);
                }
                else
                {
                    Point<T> minLargerNode = point.Right;
                    while (minLargerNode.Left != null)
                    {
                        minLargerNode = minLargerNode.Left;
                    }
                    point.Data = minLargerNode.Data;
                    (point.Right, var isRemoved) = RemoveFromPoint(point.Right, minLargerNode.Data);
                    return (point, isRemoved);
                }
            }
        }
    }
}