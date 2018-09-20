using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures
{
    class BSTBroker
    {
        public static Node<int> PrepareBSTFromArray(int[] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("arr");
            }

            Array.Sort(arr);
            Node<int> root = MakeBSTFromSortedArray(arr, 0, arr.Length - 1);

            return root;

        }

        private static Node<int> MakeBSTFromSortedArray(int[] arr, int stIdx, int endIdx)
        {
            if (stIdx > endIdx || stIdx < 0 || endIdx > arr.Length-1)
            {
                return null;
            }

            int midIdx = (stIdx + endIdx) / 2;
            Node<int> N = new Node<int>(arr[midIdx]);
            N.left = MakeBSTFromSortedArray(arr, stIdx, midIdx - 1);
            if (N.left != null)
            {
                N.left.parent = N;
            }

            N.right = MakeBSTFromSortedArray(arr, midIdx + 1, endIdx);
            if (N.right != null)
            {
                N.right.parent = N;
            }

            return N;
        }
    }
}
