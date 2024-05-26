using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarsLibrary;

namespace _12_4
{
    public class MyCollection<T>: MyHashTable<T>, ICollection<T>, IEnumerable<T> where T : IInit, ICloneable, new()
    {
        // Конструкторы
        public MyCollection() : base() { }

        public MyCollection(int length) : base(length)
        {
            for (int i = 0; i < length; i++)
            {
                T item = new T();
                item.RandomInit(); // Предполагаем, что IInit имеет метод RandomInit
                AddItem(item);
            }
        }

        public MyCollection(MyCollection<T> c) : base(c.Capacity)
        {
            foreach (T item in c)
            {
                AddItem((T)item.Clone());
            }
        }

        // Свойства
        public bool IsReadOnly => false;

        // Методы
        public void Add(T item)
        {
            AddItem(item);
        }
        public void Clear()
        {
            for (int i = 0; i < Capacity; i++)
            {
                table[i] = default;
                wasDeleted[i] = false;
            }
            count = 0;
        }
        public bool Contains(T item)
        {
            return base.Contains(item);
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            if (array.Length - arrayIndex < count)
                throw new ArgumentException("The destination array has fewer elements than the collection.");

            int j = arrayIndex;
            for (int i = 0; i < Capacity; i++)
            {
                if (table[i] != null)
                {
                    array[j++] = table[i];
                }
            }
        }
        public bool Remove(T item)
        {
            return RemoveData(item);
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Capacity; i++)
            {
                if (table[i] != null)
                {
                    yield return table[i];
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    /*
    public class MyEnumerator<T> : IEnumerator<T> where T : IInit, ICloneable, new()
    {
        MyCollection<T> _collection;
        int _currentIndex;
        T _currentItem;

        public MyEnumerator(MyCollection<T> collection)
        {
            _collection = collection;
            _currentIndex = -1; // Начинаем перед первым элементом
            _currentItem = default(T);
        }

        public T Current => _currentItem;

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            while (++_currentIndex < _collection.Capacity)
            {
                if (_collection.Table[_currentIndex] != null)
                {
                    _currentItem = _collection.Table[_currentIndex];
                    return true;
                }
            }
            return false;
        }

        public void Reset()
        {
            _currentIndex = -1;
            _currentItem = default(T);
        }

        public void Dispose()
        {
            
        }
    }
    */
}
