using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Components.Structures.Arrays
{
    /// <summary>
    /// Содержит массив постоянного размера. Если при добавлении элемента количество 
    /// элементов выходит за пределы массива, первый элемент массива перезаписывается
    /// последним добавленым.
    /// Характеризуется быстрой очисткой, добавлением и обращением к определенному элементу массива.
    /// Следует заметить, что при кол-ве элементов > изначальному размеру массива
    /// доступ к первым [Кол - во добавленых элементов - Длина массива] невозможен.
    /// Хорошо подходит для подсчета среднего арифметоческого с постоянным добавлением элементов
    /// </summary>
    /// <typeparam name="T">Тип элементов</typeparam>
    public class LimitedSizeArray<T> : IList<T>, IEnumerator<T>
    {
        private T[] _array;
        private int _firstArrayIndex;

        private int _firstIndex;

        public int Count { get; private set; }

        public bool IsReadOnly { get { return false; } }

        public LimitedSizeArray(int size)
        {
            _array = new T[size];
            Clear();
        }

        public T this[int index]
        {
            get
            {
                if (!IsIndexInRange(index))
                {
                    return default(T);
                }
                return _array[ToArrayIndex(index)];
            }

            set
            {
                if (IsIndexInRange(index))
                {
                    _array[ToArrayIndex(index)] = value;
                }
            }
        }

        private bool IsIndexInRange(int index)
        {
            return index >= 0 && index >= _firstIndex && index < Count;
        }

        private int ToArrayIndex(int index)
        {
            return (_firstArrayIndex + index) % _array.Length;
        }

        public void Add(T element)
        {
            Count++;

            if (Count > _array.Length)
            {
                _firstArrayIndex++;
            }

            this[Count - 1] = element;
        }

        public override string ToString()
        {
            string result = "";
            for (int i = _firstIndex; i < _firstIndex + Count; i++)
            {
                result = result + i + " : " + this[i] + "|| ";
            }
            return result;
        }

        [Obsolete("Complex operation!")]
        public int IndexOf(T item)
        {
            int index = 0;

            foreach (T t in this)
            {
                if (item.Equals(t))
                {
                    return index;
                }
                index++;
            }

            return -1;
        }

        [Obsolete("Complex operation")]
        public void Insert(int index, T item)
        {
            if (IsIndexInRange(index))
            {
                for (int i = index + 1; i < Count; i++)
                {
                    this[i - 1] = this[i];
                }
                Count--;
            }
        }

        [Obsolete("Complex operation")]
        public void RemoveAt(int index)
        {
            if (IsIndexInRange(index))
            {
                for (int i = index; i < Count - 1; i++)
                {
                    this[i] = this[i + 1];
                }
                Count--;
            }
        }

        public void Clear()
        {
            _firstIndex = 0;
            Count = 0;
            _firstArrayIndex = 0;
        }

        [Obsolete("Complex operation")]
        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            int count = Mathf.Min(_array.Length, Count);
            if (array.Length - arrayIndex > count)
            {
                Debug.LogError("Array length should not exceed " + count);
                return;
            }

            for (int i = _firstIndex; i < Count; i++)
            {
                array[i - _firstIndex + arrayIndex] = this[i];
            }
        }

        [Obsolete("Complex operation")]
        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index == -1)
            {
                return false;
            }
            RemoveAt(index);

            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        #region IEnumerator

        private int _enumerableIndex;

        public T Current { get { return this[_enumerableIndex]; } }

        object IEnumerator.Current { get { return Current; } }

        public bool MoveNext()
        {
            _enumerableIndex++;
            return _enumerableIndex < Count;
        }

        public void Reset()
        {
            _enumerableIndex = _firstIndex;
        }

        public void Dispose()
        {
            int arraySize = _array.Length;
            Clear();
            _array = new T[arraySize];
        }

        #endregion
    }
}


