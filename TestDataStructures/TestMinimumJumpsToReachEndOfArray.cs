using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgrammingProblems;

namespace TestDataStructures
{
    [TestClass]
    public class TestMinimumJumpsToReachEndOfArray
    {
        [TestMethod]
        public void TestRecursive()
        {
            var jumps = MinimumJumpReachEnd.Recursive(new int[] { 2,3,1,0,1,3,0,8,1});
            Assert.IsTrue(jumps == 4, "Minimum hops should be 4");
        }

        [TestMethod]
        public void Test_NSquare_LeftToRight()
        {
            var jumps = MinimumJumpReachEnd.Nsquare_LeftToRight(new int[] { 2, 3, 1, 0, 1, 3, 0, 8, 1 });
            Assert.IsTrue(jumps == 4, "Minimum hops should be 4");
        }

        [TestMethod]
        public void Test_NSquare_RightToLeft()
        {
            var jumps = MinimumJumpReachEnd.Nsquare_RightToLeft(new int[] { 2, 3, 1, 0, 1, 3, 1, 8, 1 });
            Assert.IsTrue(jumps == 4, "Minimum hops should be 4");
        }
    }
}
