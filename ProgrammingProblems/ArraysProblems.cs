using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingProblems
{
    public class ArraysProblems
    {
        /*
         * Find the kth smallest element in the given array
         * 
         * Returns the n-th smallest element of list within left..right inclusive
         *  (i.e. left <= n <= right).
         *  The search space within the array is changing for each round - but the list
         *  is still the same size. Thus, n does not need to be updated with each round.
         * */

        public int QuickSelect(int[] arr, int k)
        {
            if(arr == null)
                throw new ArgumentException("array not defined.");
            if (k < 1 || k > arr.Length)
                throw new ArgumentException("k out of bounds.");

            return QuickSelect(arr, 0, arr.Length - 1, k-1);

        }

        private int QuickSelect(int[] arr, int S, int E, int k)
        {
            if (E == S)
                return arr[S];
            
            //find a Pivot index
            int pI = (S + E) / 2;

            //partition array [S, E] around the selected pivot point. That would give us a fixed location for arr[pI]
            int j = Partition(arr, S, E, pI);
            if (j == k)
                return arr[j];
            else if (j < k)
            {
                return QuickSelect(arr, j + 1, E, k);
            }
            else
                return QuickSelect(arr, S, j - 1, k);            
        }

        private int Partition(int[] arr, int S, int E, int pI)
        {
            //1. Record pivit element.
            int pivot = arr[pI];

            //2. swap pivotIndex with End
            Swap(arr, pI, E);

            int storageIndex = S;
            for(int i = S; i< E; i++)
            {
                if(arr[i] < pivot)
                {
                    Swap(arr, storageIndex, i);
                    storageIndex++;
                }
            }

            // now storageIndex points to the correct location of pivotElement
            Swap(arr, storageIndex, E);
            return storageIndex;
        }

        private void Swap(int[] arr, int a, int b)
        {
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }

        public void Rotate(int[] nums, int k)
        {
            k = k % nums.Length;
            int count = 0;
            for (int start = 0; count < nums.Length; start++)
            {
                int current = start;
                int prev = nums[start];
                do
                {
                    int next = (current + k) % nums.Length;
                    int temp = nums[next];
                    nums[next] = prev;
                    prev = temp;
                    current = next;
                    count++;
                } while (start != current);
            }
        }

        public void Rotate_Optimal(int[] nums, int k)
        {
            k = k % nums.Length;
            if (k == 0)
                return;

            Reverse(nums);
            ReverseSubArray(nums, 0, k-1);
            ReverseSubArray(nums, k, nums.Length - 1);
            
        }


        public void Reverse(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                throw new ArgumentException("Null or empty array");
            
            int start = 0;
            int end = arr.Length - 1;

            while(start < end)
            {
                Swap(arr, start++, end--);
            }
        }

        public void ReverseSubArray(int[] arr, int s, int e)
        {
            if (arr == null || arr.Length == 0)
                throw new ArgumentException("Null or empty array");

            if (s < 0 || s >= arr.Length)
                throw new ArgumentException("S is out of range");
            if (e < 0 || e >= arr.Length)
                throw new ArgumentException("e is out of range");

            
            while (s < e)
            {
                Swap(arr, s++, e--);
            }
        }

    }
}
