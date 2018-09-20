using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;
namespace TestDataStructures
{
    [TestClass]
    public class StackQueueTest
    {
        [TestMethod]
        public void TestSortStack()
        {
            StacksQueues sq = new StacksQueues();
            sq.SortingStackUsingAnotherStack();
        }


        [TestMethod]
        public void TestTowerOfHanoi()
        {
            Stack<int> A = new Stack<int>();
            Stack<int> B = new Stack<int>();
            Stack<int> C = new Stack<int>();

            A.Push(3);
            A.Push(2);
            A.Push(1);

            StacksQueues sq = new StacksQueues();
            sq.Move(3, A, B, C);

            Assert.IsTrue(C.Count == 3, "C should have all three discs");
            Assert.IsTrue(A.Count == 0, "A should be empty");
            Assert.IsTrue(B.Count == 0, "B should be empty");

            Assert.IsTrue(C.Pop() == 1, "C should have 1 on top");
            Assert.IsTrue(C.Pop() == 2, "C should have 2 on top");
            Assert.IsTrue(C.Pop() == 3, "C should have 3 on top");
        }
    }
}
