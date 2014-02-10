using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpHelperCode;

namespace CSharpHelperTest
{
    [TestClass]
    public class testPriorityQueue
    {
        [TestMethod]
        public void addThenRemoveOneInt() {
            PriorityQueue<int> testQueue = new PriorityQueue<int>();
            testQueue.Enqueue(1);
            Assert.AreEqual(1, testQueue.Dequeue());
        }

        [TestMethod]
        public void addThenRemoveOneNegativeInt() {
            PriorityQueue<int> testQueue = new PriorityQueue<int>();
            testQueue.Enqueue(-1);
            Assert.AreEqual(-1, testQueue.Dequeue());
        }

        [TestMethod]
        public void addThenRemoveOutOfOrderInts() {
            PriorityQueue<int> testQueue = new PriorityQueue<int>();
            testQueue.Enqueue(2);
            testQueue.Enqueue(1);
            Assert.IsTrue(testQueue.Dequeue() < testQueue.Dequeue());
        }

        [TestMethod]
        public void addMultipleRemoveOneInt() {
            PriorityQueue<int> testQueue = new PriorityQueue<int>();
            testQueue.Enqueue(5);
            testQueue.Enqueue(10);
            testQueue.Enqueue(-2);
            testQueue.Enqueue(1);
            testQueue.Enqueue(2);
            testQueue.Enqueue(0);
            Assert.AreEqual(-2, testQueue.Dequeue());
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void noValuesSet() {
            PriorityQueue<int> testQueue = new PriorityQueue<int>();
            int i = testQueue.Dequeue();
        }
    }
}
