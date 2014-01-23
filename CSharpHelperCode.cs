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

    public class PriorityQueue<T> where T : IComparable<T> { //Copied from http://visualstudiomagazine.com/articles/2012/11/01/priority-queues-with-c.aspx
        private List<T> data;

        public PriorityQueue() {
            this.data = new List<T>();
        }

        public void Enqueue(T item) {
            data.Add(item);
            int ci = data.Count - 1;
            while (ci > 0) {
                int pi = (ci - 1) / 2;
                if (data[ci].CompareTo(data[pi]) >= 0) {
                    break;
                }
                T tmp = data[ci]; data[ci] = data[pi]; data[pi] = tmp;
                ci = pi;
            }
        }

        public T Dequeue() {
            // Assumes pq isn't empty
            int li = data.Count - 1;
            T frontItem = data[0];
            data[0] = data[li];
            data.RemoveAt(li);

            --li;
            int pi = 0;
            while (true) {
                int ci = pi * 2 + 1;
                if (ci > li) break;
                int rc = ci + 1;
                if (rc <= li && data[rc].CompareTo(data[ci]) < 0) {
                    ci = rc;
                }
                if (data[pi].CompareTo(data[ci]) <= 0) {
                    break;
                }
                T tmp = data[pi];
                data[pi] = data[ci];
                data[ci] = tmp;
                pi = ci;
            }
            return frontItem;
        }
    }
}