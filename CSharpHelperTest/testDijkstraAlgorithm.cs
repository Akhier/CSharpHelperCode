using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpDijkstraAlgorithm;

namespace CSharpHelperTest
{
    [TestClass]
    public class testDijkstraAlgorithm
    {
        [TestMethod]
        public void checkINFINITY() {
            Assert.AreEqual(-1, Vector2D.INFINITY);
        }
        [TestMethod]
        public void checkVectorID() {
            Vector2D testVectorA = new Vector2D(1, 1, true);
            Vector2D testVectorB = new Vector2D(1, 1, true);
            Assert.AreEqual(testVectorA.VectorID, testVectorB.VectorID - 1);            
        }
        [TestMethod]
        public void checkVectorToString() {
            Vector2D testVector = new Vector2D(1, 1, true);
            Assert.AreEqual("Vector ID: 1 X: 1 Y: 1;", testVector.ToString());
        }
        [TestMethod]
        public void checkEdgeID() {
            Vector2D testVectorA = new Vector2D(1, 1, true);
            Vector2D testVectorB = new Vector2D(1, 2, true);
            Edge testEdgeA = new Edge(testVectorA, testVectorB, 1);
            Edge testEdgeB = new Edge(testVectorA, testVectorB, 1);
            Assert.AreEqual(testEdgeA.EdgeID, testEdgeB.EdgeID - 1);
        }
        [TestMethod]
        public void testGetOtherVector() {
            Vector2D testVectorA = new Vector2D(1, 1, true);
            Vector2D testVectorB = new Vector2D(1, 2, true);
            Edge testEdge = new Edge(testVectorA, testVectorB, 1);
            Assert.AreEqual(testVectorB, testEdge.getOtherVector(testVectorA));
        }
        [TestMethod]
        public void testGetOtherVectorNullReturn() {
            Vector2D testVectorA = new Vector2D(1, 1, true);
            Vector2D testVectorB = new Vector2D(1, 2, true);
            Vector2D testVectorC = new Vector2D(2, 1, false);
            Edge testEdge = new Edge(testVectorA, testVectorB, 1);
            Assert.AreEqual(null, testEdge.getOtherVector(testVectorC));
        }
        [TestMethod]
        public void checkEdgeToString() {
            Vector2D testVectorA = new Vector2D(1, 1, true);
            Vector2D testVectorB = new Vector2D(1, 2, true);
            Edge testEdge = new Edge(testVectorA, testVectorB, 3);
            Assert.AreEqual("Edge ID: 1 - Connected to vectors 1 and 2 at a cost of 3", testEdge.ToString());
        }
    }
}
