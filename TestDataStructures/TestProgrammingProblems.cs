using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgrammingProblems;
using System.Text;

namespace TestDataStructures
{
    [TestClass]
    public class TestProgrammingProblems
    {
        [TestMethod]
        public void TestHasSubarrayOfSumAllPositiveNoZeros()
        {
            uint[] arr = new uint[] { 1, 3, 5, 7, 9 };
            bool result = Eugene.EfficientSumSubarray(arr, 8);
            Assert.IsTrue(result, "It has a sub-array [3,5] for sum 8");

            arr = new uint[] { 10, 3, 5, 7, 9 };
            result = Eugene.EfficientSumSubarray(arr, 8);
            Assert.IsTrue(result, "It has a sub-array [3,5] for sum 8");

            arr = new uint[] { 10, 30, 50, 7, 9 };
            result = Eugene.EfficientSumSubarray(arr, 7);
            Assert.IsTrue(result, "It has a sub-array [7] for sum 7");

            arr = new uint[] { 10, 30, 50, 7, 9, 1 };
            result = Eugene.EfficientSumSubarray(arr, 17);
            Assert.IsTrue(result, "It has a sub-array [7,9,1] for sum 17");

            arr = new uint[] { 10, 30, 50, 7, 9, 1 };
            result = Eugene.EfficientSumSubarray(arr, 8);
            Assert.IsFalse(result, "It has no sub-array for sum 8");

        }

        [TestMethod]
        public void TestHasSubarrayOfSumPositiveNegativeNoZeros()
        {
            int[] arr = new int[] { 2, 1, 1, 4, -1, -2, 3 };
            bool result = Eugene.HasContiguousPartnersForGivenSum(arr, 0);
            Assert.IsTrue(result, "It has a sub-array [-1,-2,3] for sum 0");

            arr = new int[] { 2, 1, 1, 4, -1, -2, 3 };
            result = Eugene.HasContiguousPartnersForGivenSum(arr, 7);
            Assert.IsTrue(result, "It has a sub-array [2,1,1,4,-1] for sum 7");

            arr = new int[] { 2, 1, 1, 4, -1, -2, 3 };
            result = Eugene.HasContiguousPartnersForGivenSum(arr, 9);
            Assert.IsFalse(result, "It has no sub-array for sum 9");

        }

        [TestMethod]
        public void TestMinSubsequence()
        {
            var sub = Eugene.ShortestSubsequenceInSCoveringT("bdaebcwagtadb", "abc");
            Assert.IsTrue(sub == "aebc");
        }


        [TestMethod]
        public void TestMultiDimentionalArray()
        {
            LinkedIn.IteratNDimensionalJaggedArray();
        }

        [TestMethod]
        public void TestOddEvenArray()
        {
            var list = PrepareList(new int[]{1,2,3,4,5});
            OnlineJudge oj = new OnlineJudge();
            var newlist = oj.OddEvenList(list);

            list = PrepareList(new int[] { 1, 3, 5, 2, 4 });
            Assert.IsTrue(AreListsEqual(list, newlist), "Should be 1->3->5->2->4");
        }

        [TestMethod]
        public void TestArrangeEvenOddByValue_startOdd()
        {
            var list = PrepareList(new int[] { 17,15,8,12,10,5,4,1,7,6});
            OnlineJudge oj = new OnlineJudge();
            var newlist = oj.ArrangeEvenOddNodesByValue(list);

            list = PrepareList(new int[] { 8,12,10,4,6,17,15,5,1,7});
            Assert.IsTrue(AreListsEqual(list, newlist), "should be 8,12,10,4,6,17,15,5,1,7");
        }

        [TestMethod]
        public void TestArrangeEvenOddByValue_startEven()
        {
            var list = PrepareList(new int[] { 8, 17, 15, 2, 12, 10, 5, 4, 1, 7, 6 });
            OnlineJudge oj = new OnlineJudge();
            var newlist = oj.ArrangeEvenOddNodesByValue(list);

            list = PrepareList(new int[] { 8, 2, 12, 10, 4, 6, 17, 15, 5, 1, 7 });
            Assert.IsTrue(AreListsEqual(list, newlist), "should be 8, 2, 12, 10, 4, 6, 17, 15, 5, 1, 7");
        }

        [TestMethod]
        public void TestListEquals()
        {
            Assert.IsFalse(AreListsEqual(PrepareList(new int[] { 1, 2 }), PrepareList(new int[] { 1, 2, 3 })), "should not be equal");
            Assert.IsTrue(AreListsEqual(PrepareList(new int[]{1,2,3}), PrepareList(new int[]{1,2,3})), "should be equal");
            Assert.IsFalse(AreListsEqual(PrepareList(new int[] { 1, 2, 4 }), PrepareList(new int[] { 1, 2, 3 })), "should not be equal");
        }

        private bool AreListsEqual(ListNode A, ListNode B)
        {
            while (A != null || B != null)
            {
                if ((A == null) ^ (B == null)) return false;

                if (A.val != B.val) return false;

                A = A.next;
                B = B.next;
            }

            return true;
        }

        private ListNode PrepareList(int[] arr)
        {
            ListNode head = new ListNode(arr[0]);
            var N = head;
            for(int i = 1;i<arr.Length;i++)
            {
                N.next = new ListNode(arr[i]);
                N = N.next;
            }

            return head;
        }

        private void PrintList(ListNode N)
        {
            StringBuilder sb = new StringBuilder();
            while(N != null)
            {
                sb.Append(string.Format("{0} ->", N.val));
                N = N.next;
            }

            Console.WriteLine(sb.ToString());
        }

        [TestMethod]
        public void TestMajoiryAlgo()
        {
            int? m = MajorityAlgo.FindMajorityElement(new int[] { 3, 3, 4, 2, 4, 4, 2, 4, 4});
            Assert.AreEqual(4, m, "Majority element should be 4");

            m = MajorityAlgo.FindMajorityElement(new int[] { 3, 3, 4, 2, 4, 4, 2, 4,  });
            Assert.AreEqual(null, m, "Majority element should be null");

            m = MajorityAlgo.FindMajorityElement(new int[] { 3, 4, 3, 2, 3, 2 });
            Assert.AreEqual(null, m, "Majority element should be null");

            m = MajorityAlgo.FindMajorityElement(new int[] { 3, 4, 3, 2, 3, 2, 2 });
            Assert.AreEqual(null, m, "Majority element should be null");

            m = MajorityAlgo.FindMajorityElement(new int[] { 3, 4, 3, 2, 3, 2, 3 });
            Assert.AreEqual(3, m, "Majority element should be 3");

            m = MajorityAlgo.FindMajorityElement(new int[] {});
            Assert.AreEqual(null, m, "Majority element should be null");

            m = MajorityAlgo.FindMajorityElement(null);
            Assert.AreEqual(null, m, "Majority element should be null");

            m = MajorityAlgo.FindMajorityElement(new int[] { 3 });
            Assert.AreEqual(3, m, "Majority element should be 3");

            m = MajorityAlgo.FindMajorityElement(new int[] { 3, 4 });
            Assert.AreEqual(null, m, "Majority element should be null");

            m = MajorityAlgo.FindMajorityElement(new int[] { 3, 4, 3 });
            Assert.AreEqual(3, m, "Majority element should be 3");

        }

        [TestMethod]
        public void TestMajoiryAlgo_2N()
        {
            var m = MajorityAlgo.FindMajorityElement_2NElements(null);
            Assert.AreEqual(null, m, "Majority element should be null");

            m = MajorityAlgo.FindMajorityElement_2NElements(new int[] { });
            Assert.AreEqual(null, m, "Majority element should be null");

            m = MajorityAlgo.FindMajorityElement_2NElements(new int[] { 1 });
            Assert.AreEqual(null, m, "Majority element should be null");

            m = MajorityAlgo.FindMajorityElement_2NElements(new int[] { 1, 2 });
            Assert.AreEqual(1, m, "Majority element should be 1");

            m = MajorityAlgo.FindMajorityElement_2NElements(new int[] { 1, 1 });
            Assert.AreEqual(null, m, "Majority element should be null");

            m = MajorityAlgo.FindMajorityElement_2NElements(new int[] { 1, 2, 1 });
            Assert.AreEqual(null, m, "Majority element should be null");

            m = MajorityAlgo.FindMajorityElement_2NElements(new int[] { 1, 2, 2, 3 });
            Assert.AreEqual(2, m, "Majority element should be 2");

            m = MajorityAlgo.FindMajorityElement_2NElements(new int[] { 1, 2, 3, 1 });
            Assert.AreEqual(1, m, "Majority element should be 1");

            m = MajorityAlgo.FindMajorityElement_2NElements(new int[] { 1, 2, 1, 3, 1, 4 });
            Assert.AreEqual(1, m, "Majority element should be 1");

            m = MajorityAlgo.FindMajorityElement_2NElements(new int[] { 1, 2, 1, 1, 4, 3 });
            Assert.AreEqual(1, m, "Majority element should be 1");

            m = MajorityAlgo.FindMajorityElement_2NElements(new int[] { 1, 2, 3, 1, 4, 1 });
            Assert.AreEqual(1, m, "Majority element should be 1");

            m = MajorityAlgo.FindMajorityElement_2NElements(new int[] { 1, 2, 3, 2, 4, 2 });
            Assert.AreEqual(2, m, "Majority element should be 2");
        }


        [TestMethod]
        public void TestTreePrintZigZag()
        {
            Trees.Run();
        }

        [TestMethod]
        public void TestQuickSelect()
        {
            ArraysProblems ap = new ArraysProblems();

            int[] arr = { 7, 3, 1, 4, 2, 9};
            var j = ap.QuickSelect(arr, 3);
            Assert.IsTrue(j == 3, "Third smallest is 3");
            Assert.IsTrue(ap.QuickSelect(arr, 5) == 7, "5th smallest is 7");
        }

        [TestMethod]
        public void TestArrayRotation()
        {
            int[] arr = { 1,2,3,4,5,6,7 };
            ArraysProblems ap = new ArraysProblems();
            ap.Rotate(arr, 3);


        }

        [TestMethod]
        public void TestArrayReverse()
        {
            ArraysProblems ap = new ArraysProblems();
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            ap.Reverse(arr);
            Assert.IsTrue(arr[0] == 7);
        }

        [TestMethod]
        public void TestArrayRotateOptimal()
        {
            ArraysProblems ap = new ArraysProblems();
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            ap.Rotate_Optimal(arr, 3);
            Assert.IsTrue(arr[0] == 5);

            arr = new int[]{ 1, 2, 3, 4, 5, 6, 7 };
            ap.Rotate_Optimal(arr, 4);
            Assert.IsTrue(arr[0] == 4);

            arr = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            ap.Rotate_Optimal(arr, 7);
            Assert.IsTrue(arr[0] == 1);

            arr = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            ap.Rotate_Optimal(arr, 8);
            Assert.IsTrue(arr[0] == 7);
        }

        [TestMethod]
        public void TestArrayReverseSubarray()
        {
            ArraysProblems ap = new ArraysProblems();
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            ap.ReverseSubArray(arr,0,4);
            Assert.IsTrue(arr[0] == 5);
        }
    }
}
