using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_3
{
    public class Point<T> where T : IComparable
    {
        // Свойства
        public T? Data { get; set; }
        public Point<T>? Left { get; set; }
        public Point<T>? Right { get; set; }

        // Конструкторы
        public Point()
        {
            this.Data = default(T?);
            this.Left = null;
            this.Right = null;
        }
        public Point(T data)
        {
            this.Data = data;
            this.Left = null;
            this.Right = null;
        }

        // Методы
        public override string? ToString()
        {
            return Data == null ? "" : Data.ToString();
        }
        public int CompareTo(Point<T> other)
        {
            return Data.CompareTo(other.Data);
        }
    }
}
