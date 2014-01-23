using System;
using System.Collections.Generic;

namespace CSharpHelperCode
{
    static public class Helper {
        /// <summary>
        /// Takes T value, int width, and int height then returns T[,]
        /// </summary>
        /// <typeparam name="T">The type of the array to return</typeparam>
        /// <param name="value">A value of type T to fill array</param>
        /// <returns>Returns an array T[width,height] filled with value</returns>
        static public T[,] init2dArrayToValue<T>(T value, int width, int height) {
            var output = new T[width, height];
            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    output[x, y] = value;
                }
            }
            return output;
        }
    }

    public class PriorityQueue<T> where T : IComparable<T> {
        private List<T> _data;

        public PriorityQueue() {
            this._data = new List<T>();
        }

        public void Enqueue(T item) {
            _data.Add(item);
            int CurrentItem = _data.Count - 1;
            while (CurrentItem > 0) {
                int PreviousItem = (CurrentItem - 1) / 2;
                if (_data[CurrentItem].CompareTo(_data[PreviousItem]) >= 0) {
                    break;
                }
                T tmp = _data[CurrentItem]; _data[CurrentItem] = _data[PreviousItem]; _data[PreviousItem] = tmp;
                CurrentItem = PreviousItem;
            }
        }

        public T Dequeue() {
            if (_data.Count == 0) {
                throw new IndexOutOfRangeException("The PriorityQueu is empty");
            }
            int LastItem = _data.Count - 1;
            T FrontItem = _data[0];
            _data[0] = _data[LastItem];
            _data.RemoveAt(LastItem);

            --LastItem;
            int PreviousItem = 0;
            while (true) {
                int CurrentItem = PreviousItem * 2 + 1;
                if (CurrentItem > LastItem) break;
                int CurrentRightItem = CurrentItem + 1;
                if (CurrentRightItem <= LastItem && _data[CurrentRightItem].CompareTo(_data[CurrentItem]) < 0) {
                    CurrentItem = CurrentRightItem;
                }
                if (_data[PreviousItem].CompareTo(_data[CurrentItem]) <= 0) {
                    break;
                }
                T tmp = _data[PreviousItem];
                _data[PreviousItem] = _data[CurrentItem];
                _data[CurrentItem] = tmp;
                PreviousItem = CurrentItem;
            }
            return FrontItem;
        }

        public int Count() {
            return _data.Count;
        }
    }
}