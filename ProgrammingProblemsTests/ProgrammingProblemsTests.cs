using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgrammingProblems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingProblems.Tests
{
    [TestClass()]
    public class ProgrammingProblemsTests
    {
        [TestMethod()]
        public void PrintMatrixInSpiralTest()
        {
            // arrange
            int[,] M = new int[,] {
                { 1,2,3,4,5},
                { 6,7,8,9,10},
                { 11,12,13,14,15},
                { 16,17,18,19,20}
            };

            // act
            MatrixProblems mp = new MatrixProblems();
            mp.PrintMatrixInSpiral(M);

            // assert
        }
    }
}