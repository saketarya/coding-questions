using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WhiteKitaab;

namespace TestWhiteKitaab
{
    [TestClass]
    public class TestRecursion
    {
        [TestMethod]
        public void TestNStepLadderProblem()
        {            
            Assert.IsTrue(Recursion.FindStepsToReachTop(-1) == 0, "Step count should be 0");
            Assert.IsTrue(Recursion.FindStepsToReachTop(0) == 0, "Step count should be 0");
            Assert.IsTrue(Recursion.FindStepsToReachTop(1) == 1, "Step count should be 0");
            Assert.IsTrue(Recursion.FindStepsToReachTop(2) == 2, "Step count should be 0");
            Assert.IsTrue(Recursion.FindStepsToReachTop(3) == 4, "Step count should be 0");
            Assert.IsTrue(Recursion.FindStepsToReachTop(4) == 8, "Step count should be 0");
            Assert.IsTrue(Recursion.FindStepsToReachTop(5) == 15, "Step count should be 0");
        }

        [TestMethod]
        public void TestFindPossiblePathsToReachACellInGrid()
        {
            var paths = Recursion.FindAllPathsToAGridCellFromTopLeftCorner(3, 3, 3, 3);
            Assert.IsNotNull(paths);
            Assert.AreEqual(paths.Count, 6);
            paths.ForEach(p => {
                Console.WriteLine(p);
            });

            paths = Recursion.FindAllPathsToAGridCellFromTopLeftCorner(4, 4, 4, 4);
            Assert.IsNotNull(paths);
            paths.ForEach(p =>
            {
                Console.WriteLine(p);
            });
        }

        [TestMethod]
        public void TestFindPossiblePathsToReachACellInGrid_WithSomeBlockedCells()
        {
            var paths = Recursion.FindAllPathsToAGridCellFromTopLeftCornerWithBlockedCells(3, 3);
            Assert.IsNotNull(paths);
            //Assert.AreEqual(paths.Count, 6);
            paths.ForEach(p =>
            {
                Console.WriteLine(p);
            });

            paths = Recursion.FindAllPathsToAGridCellFromTopLeftCornerWithBlockedCells(4, 4);
            Assert.IsNotNull(paths);
            paths.ForEach(p =>
            {
                Console.WriteLine(p);
            });
        }
    }
}
