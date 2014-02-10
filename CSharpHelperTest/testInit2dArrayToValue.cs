using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpHelperCode;

namespace CSharpHelperTest
{
    [TestClass]
    public class testInit2dArrayToValue
    {
        [TestMethod]
        public void setArrayToIntValue() {
            int[,] result = Helper.init2dArrayToValue<int>(1,2,2);
            int[,] expected = { { 1, 1 }, { 1, 1 } };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void setArrayToBoolValue() {
            bool[,] result = Helper.init2dArrayToValue<bool>(true, 2, 2);
            bool[,] expected = { { true, true }, { true, true } };
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
