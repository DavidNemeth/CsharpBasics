using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Generics
{
    class MyList<T> : IEnumerable<T>
    {
        T[] sourceArray;
        public MyList(int catacity = 5)
        {
            sourceArray = new T[catacity];
        }
        public void Add(T item)
        {
            EnsureCapacity();
            sourceArray[Count++] = item;

        }
        public void AddRange(IEnumerable<T> items)
        {
            T[] newItemsArray = items.ToArray();
            InsertRange(Count, items);
        }
        public void RemoveAll(Predicate<T> pred)
        {
            for (int i = 0; i < Count; i++)
            {
                if (pred(sourceArray[i]))
                {
                    Remove(sourceArray[i]);
                    i--;
                }
            }
        }
        public void Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);                
            }            
        }
        public int IndexOf(T item)
        {
            return Array.IndexOf<T>(sourceArray, item, 0, Capacity);
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return sourceArray[i];
            }
        }
        public void RemoveAt(int index)
        {
            if (index >= Count)
            {
                return;
            }
            Array.Copy(sourceArray, index + 1, sourceArray, index, Count - (index + 1));
            Count--;
        }
        public void RemoveRange(int index, int count)
        {
            if (index + count > Count)
            {
                return;
            }
            Array.Copy(sourceArray, index + count, sourceArray, index, Count - (index + count));
            Count -= count;
        }
        public void InsertRange(int index, IEnumerable<T> newList)
        {
            T[] newItemsArray = newList.ToArray();
            EnsureCapacity(newItemsArray.Length + Count);
            Array.Copy(sourceArray, index, sourceArray, index + newItemsArray.Length, Count - index);
            Array.Copy(newItemsArray, 0, sourceArray, index, newItemsArray.Length);
            Count += newItemsArray.Length;
        }
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        public T this[int index]
        {
            get
            {
                OutOfRange(index);
                return sourceArray[index];
            }
            set
            {
                OutOfRange(index);
                sourceArray[index] = value;
            }
        }
        public int Capacity
        {
            get { return sourceArray.Length; }
        }
        public int Count { get; private set; }
        public void Clear()
        {
            Count = 0;
            if (typeof(T).BaseType.Equals(typeof(ValueType)))
            {
                return;
            }
            for (int i = 0; i < Count; i++)
            {
                sourceArray[i] = default(T);
            }
        }
        public void TrimExcess()
        {
            T[] newArray = new T[Count];
            Array.Copy(sourceArray, newArray, Count);
            sourceArray = newArray;
        }
        public void Insert(int index, T item)
        {
            EnsureCapacity();
            Array.Copy(sourceArray, index, sourceArray, index + 1, Count - index);
            sourceArray[index] = item;
            Count++;
        }
        public MyList<T> GetRange(int index, int amount)
        {
            MyList<T> ret = new MyList<T>(amount);
            Array.Copy(sourceArray, index, ret.sourceArray, 0, amount);
            ret.Count = amount;
            return ret;
        }
        void OutOfRange(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
        }
        void EnsureCapacity()
        {
            EnsureCapacity(Count + 1);
        }
        void EnsureCapacity(int neededCapacity)
        {
            if (neededCapacity > Capacity)
            {
                int targetSize = sourceArray.Length * 2;
                if (targetSize < neededCapacity)
                {
                    targetSize = neededCapacity;
                }
                Array.Resize(ref sourceArray, targetSize);
            }
        }
    }
}