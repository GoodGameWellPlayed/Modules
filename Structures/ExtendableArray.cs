using System;
using System.Collections;
using System.Collections.Generic;

namespace Components.Structures.Arrays
{
    /// <summary>
    /// Массив с фиксированной длиной и сложной операцией расширения.
    /// Быстрая операция очистки.
    /// </summary>
    /// <typeparam name="T">Тип элементов</typeparam>
    public class ExtendableArray<T> : IEnumerable<T>, IDisposable
    {
        //TODO быстрая очистка + IList
        private ExtendableArrayEnumerator _enumerator;
        private bool _setDefaultOnDispose;

        public ExtendableArray(bool setDefaultOnDispose = false)
        {
            _enumerator = new ExtendableArrayEnumerator();
            _setDefaultOnDispose = setDefaultOnDispose;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _enumerator;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _enumerator;
        }

        public void Dispose()
        {
            _enumerator.Dispose(_setDefaultOnDispose);
        }

        public void Add(T obj)
        {
            _enumerator.Add(obj);
        }

        private class ExtendableArrayEnumerator : IEnumerator<T>
        {
            private T[] array;
            private int CountMax { get; set; }
            private const int CountMin = 10;

            private int CurrentCountEnumerator = -1;
            private int CurrentCountAdded = 0;

            public ExtendableArrayEnumerator()
            {
                array = new T[CountMin];
            }

            public T Current
            {
                get
                {
                    return array[CurrentCountEnumerator];
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current as object;
                }
            }

            public void Dispose(bool setDefaultOnDispose)
            {
                CurrentCountAdded = 0;

                if (setDefaultOnDispose)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] = default(T);
                    }
                }
            }

            public bool MoveNext()
            {
                CurrentCountEnumerator++;

                if (CurrentCountEnumerator >= CurrentCountAdded || CurrentCountEnumerator >= array.Length)
                {
                    Reset();
                    return false;
                }

                return true;
            }

            public void Reset()
            {
                CurrentCountEnumerator = -1;
            }

            public void Add(T obj)
            {
                CurrentCountAdded++;

                if (array.Length < CurrentCountAdded)
                {
                    ExtendArray();
                }

                array[CurrentCountAdded - 1] = obj;
            }

            private void ExtendArray()
            {
                T[] arrayTMP = new T[array.Length + CountMin];

                for (int i = 0; i < array.Length; i++)
                {
                    arrayTMP[i] = array[i];
                }

                array = arrayTMP;
            }

            public void Dispose()
            {
                Dispose(false);
            }
        }
    }
}

