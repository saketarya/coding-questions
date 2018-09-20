using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;
using ProgrammingProblems;

namespace TestDataStructures
{
    [TestClass]
    public class TestAritmatic
    {
        [TestMethod]
        public void TestFourierTransformNultiplication()
        {
            var arithmatic = new Eugene();
            var result = arithmatic.MultiplyTwoLargeNumbers_UsingFastFourierTransform(987, 98);
            Console.WriteLine(string.Join("", result));
        }
    }
}
