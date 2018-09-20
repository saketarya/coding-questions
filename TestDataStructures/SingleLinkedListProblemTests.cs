using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSProblems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStructures;

namespace SingleLinkedListProblems.Tests
{
    [TestClass()]
    public class SingleLinkedListProblemTests
    {
        [TestMethod()]
        public void ReArrageListBigListTest()
        {
            var list = SingleLinkedList<string>.CreateList("a1");
            list.InsertLast("a2");
            list.InsertLast("a3");
            list.InsertLast("a4");
            list.InsertLast("b1");
            list.InsertLast("b2");
            list.InsertLast("b3");
            list.InsertLast("b4");

            list.Print();

            LinkedListProblems.ReArrageList(list);

            list.Print();

        }

        [TestMethod()]
        public void ReArrageListTwoNodeTest()
        {
            var list = SingleLinkedList<string>.CreateList("a1");
            list.InsertLast("b1");

            list.Print();

            LinkedListProblems.ReArrageList(list);

            list.Print();

        }

        [TestMethod()]
        public void ReArrageListNullTest()
        {
            var list = SingleLinkedList<string>.CreateList("a1");
            list.DeleteFirst();

            list.Print();

            LinkedListProblems.ReArrageList(list);

            list.Print();

        }

        [TestMethod()]
        public void ReArrageListOddLenghtTest()
        {
            var list = SingleLinkedList<string>.CreateList("a1");
            list.InsertLast("a2");
            list.InsertLast("a3");
            list.InsertLast("a4");
            list.InsertLast("b1");
            list.InsertLast("b2");
            list.InsertLast("b3");

            list.Print();

            try
            {
                LinkedListProblems.ReArrageList(list);
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Equals("list length should be even."), "Odd length list should throw error");
            }

            list.InsertLast("b4");
            list.InsertLast("b5");
            try
            {
                LinkedListProblems.ReArrageList(list);
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Equals("list length should be even."), "Odd length list should throw error");
            }

            list.Print();

        }

        [TestMethod()]
        public void DeleteDuplicateWhereAllUniqueTest()
        {
            var list = SingleLinkedList<int>.CreateList(5);
            list.InsertLast(2);
            list.InsertLast(8);
            list.InsertLast(9);
            list.InsertLast(7);
            list.InsertLast(3);
            list.Print();

            LinkedListProblems.DeleteDuplicates(list);
            list.Print();
        }

        [TestMethod()]
        public void DeleteDuplicateWhereDuplicatesTest()
        {
            var list = SingleLinkedList<int>.CreateList(5);
            list.InsertLast(2);
            list.InsertLast(8);
            list.InsertLast(8);
            list.InsertLast(6);
            list.InsertLast(2);
            list.InsertLast(5);
            list.Print();

            LinkedListProblems.DeleteDuplicates(list);
            list.Print();
        }

        [TestMethod()]
        public void DeleteDuplicateNullTest()
        {
            var list = SingleLinkedList<int>.CreateList(5);
            list.Delete(5);

            LinkedListProblems.DeleteDuplicates(list);
            list.Print();

        }

        [TestMethod()]
        public void DeleteDuplicateSingleNodeTest()
        {
            var list = SingleLinkedList<int>.CreateList(5);

            LinkedListProblems.DeleteDuplicates(list);
            list.Print();
        }

        [TestMethod()]
        public void FindNthToLastTest()
        {
            var list = SingleLinkedList<int>.CreateList(5);
            list.InsertLast(2);
            list.InsertLast(8);
            list.InsertLast(9);
            list.InsertLast(6);
            list.InsertLast(3);
            list.InsertLast(7);
            list.Print();

            var node = LinkedListProblems.GetNthFromLast<int>(list, 3);
            Assert.IsTrue(node != null && node.Data == 6, string.Format("Found = {0}. Expected = 6", node.Data.ToString()));

            node = LinkedListProblems.GetNthFromLast<int>(list, 1);
            Assert.IsTrue(node != null && node == list.Tail, string.Format("Found = {0}. Expected = {1}", node.Data, list.Tail.Data));
            node = LinkedListProblems.GetNthFromLast<int>(list, 7);
            Assert.IsTrue(node != null && node == list.Head, string.Format("Found = {0}. Expected = {1}", node.Data, list.Head.Data));

            node = LinkedListProblems.GetNthFromLast<int>(list, 0);
            Assert.IsTrue(node == null , "0th to last is not a valid position.");

            try
            {
                node = LinkedListProblems.GetNthFromLast<int>(list, 10);
                Assert.IsTrue(false, "Should have thrown argument exception");               
            }
            catch(ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Equals("N too big."), string.Format("N={0} should be out of range.", 10));
            }
        }


        [TestMethod]
        public void TestDeleteARandomNode()
        {
            var list = new SingleLinkedList<int>();
            list.InsertLast(2);
            list.InsertLast(8);
            list.InsertLast(9);
            INode<int> node = new LLNode<int> { Data = 6 };
            list.InsertLast(node);
            list.InsertLast(3);
            list.InsertLast(7);
            list.Print();
                        
            LinkedListProblems.DeleteARandomNode(list, node);
            list.Print();

            Assert.IsTrue(node.Data == 3, "Delete failed.");

            node = new LLNode<int> { Data = 16 };
            list.InsertLast(node);
            try
            {
                LinkedListProblems.DeleteARandomNode(list, node);
            }
            catch(ApplicationException ex)
            {
                Assert.IsTrue(ex.Message.Equals("cannot delete the node as its null or the last node."));
            }

        }

        [TestMethod]
        public void TestPivotOverARandomNode()
        {
            var list = new SingleLinkedList<int>();
            list.InsertLast(2);
            list.InsertLast(8);
            list.InsertLast(9);
            list.InsertLast(6);
            list.InsertLast(3);
            list.InsertLast(7);
            list.Print();

            var newlist = LinkedListProblems.SplitMe(list, 6);
            newlist.Print();

            int[] result = new int[] { 2, 3, 6, 8, 9, 7 };
            var r = newlist.Head;
            for (int i = 0; i < result.Length; i++)
            {
                Assert.IsTrue(r.Data == result[i], "Order not correct. Position={0}, Expected={1}, Actual={2}", i, result[i], r.Data);
                r = r.Next;
            }

        }


        [TestMethod]
        public void TestPalindrom()
        {
            // 1->2->3->2->1
            var list = new SingleLinkedList<int>();
            list.InsertLast(1);
            list.InsertLast(2);
            list.InsertLast(3);
            list.InsertLast(2);
            list.InsertLast(1);
            list.Print();

            var isPalindrom = LinkedListProblems.IsPalindrome(list);
            Assert.IsTrue(isPalindrom, "List is a valid palindrom");

            // 1->2->3->3->2->1
            list = new SingleLinkedList<int>();
            list.InsertLast(1);
            list.InsertLast(2);
            list.InsertLast(3);
            list.InsertLast(3);
            list.InsertLast(2);
            list.InsertLast(1);
            list.Print();

            isPalindrom = LinkedListProblems.IsPalindrome(list);
            Assert.IsTrue(isPalindrom, "List is a valid palindrom");

            // 1
            list = new SingleLinkedList<int>();
            list.InsertLast(1);
            list.Print();

            isPalindrom = LinkedListProblems.IsPalindrome(list);
            Assert.IsTrue(isPalindrom, "List is a valid palindrom");

            // Empty list
            list = new SingleLinkedList<int>();
            isPalindrom = LinkedListProblems.IsPalindrome(list);
            Assert.IsFalse(isPalindrom, "Empty List is not a valid palindrom");

            // 1->2->3->4->2->1
            list = new SingleLinkedList<int>();
            list.InsertLast(1);
            list.InsertLast(2);
            list.InsertLast(3);
            list.InsertLast(4);
            list.InsertLast(2);
            list.InsertLast(1);
            list.Print();

            isPalindrom = LinkedListProblems.IsPalindrome(list);
            Assert.IsFalse(isPalindrom, "List is not a valid palindrom");

            // 1->2->3->2
            list = new SingleLinkedList<int>();
            list.InsertLast(1);
            list.InsertLast(2);
            list.InsertLast(3);
            list.InsertLast(2);
            list.Print();

            isPalindrom = LinkedListProblems.IsPalindrome(list);
            Assert.IsFalse(isPalindrom, "List is not a valid palindrom");

            // 1->2->3->4->1
            list = new SingleLinkedList<int>();
            list.InsertLast(1);
            list.InsertLast(2);
            list.InsertLast(3);
            list.InsertLast(4);
            list.InsertLast(1);
            list.Print();

            isPalindrom = LinkedListProblems.IsPalindrome(list);
            Assert.IsFalse(isPalindrom, "List is not a valid palindrom");

        }


    }
}