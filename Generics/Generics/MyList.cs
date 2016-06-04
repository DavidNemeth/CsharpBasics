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
            sourceArray[Length++] = item;

        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
            {
                yield return sourceArray[i];
            }
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
        private void OutOfRange(int index)
        {
            if (index >= Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
        }
        public int Capacity
        {
            get { return sourceArray.Length; }
        }
        public int Length { get; private set; }
        public void Clear()
        {
            Length = 0;
            if (typeof(T).BaseType.Equals(typeof(ValueType)))
            {
                return;
            }
            for (int i = 0; i < Length; i++)
            {
                sourceArray[i] = default(T);
            }
        }
        public void TrimExcess()
        {
            T[] newArray = new T[Length];
            Array.Copy(sourceArray, newArray, Length);
            sourceArray = newArray;
        }
        internal void Insert(int index, T item)
        {
            EnsureCapacity();
            Array.Copy(sourceArray, index, sourceArray, index + 1, Length - index);
            sourceArray[index] = item;
            Length++;
        }
        public void InsertRange(int index, IEnumerable<T> newList)
        {
            int newListCount = newList.Count();
            EnsureCapacity(Length + newListCount);
            Array.Copy(sourceArray, index, sourceArray, index + newListCount, Length - index);
            foreach (T newItem in newList)
            {
                sourceArray[index++] = newItem;
            }
            Length += newListCount;
        }
        private void EnsureCapacity()
        {
            EnsureCapacity(Length + 1);
        }
        private void EnsureCapacity(int neededCapacity)
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