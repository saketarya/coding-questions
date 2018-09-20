using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures
{
    class MajorityAlgo
    {
        // http://www.geeksforgeeks.org/majority-element/
        /**
         * Majority Element: A majority element in an array A[] of size n is an element that appears more than n/2 times (and hence there is at most one such element).
           
       Write a function which takes an array and emits the majority element (if it exists), otherwise prints NONE as follows:

       I/P : 3 3 4 2 4 4 2 4 4
       O/P : 4 

       I/P : 3 3 4 2 4 4 2 4
       O/P : NONE
         * **/

        public static int? MooresVotingAlgo(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return null;

            var N = arr.Length;

            // STEP 1: Find a candidate element having Majority (if exists such element)
            var candidateMajorityElementIndex = 0;
            var count = 1;

            for (int i = 1; i < N;i++)
            {
                if (arr[i] == arr[candidateMajorityElementIndex])
                    count++;
                else
                    count--;

                if (count == 0)
                {
                    candidateMajorityElementIndex = i;
                    count = 1;
                }
            }

            if (count == 0)
            {
                // No majority element exists
                return null;
            }

            // STEP 2: confirm the frequency of the candidate majority element is > N/2.
            var candidateMajorityElement = arr[candidateMajorityElementIndex];
            count = 0;
            for (int i = 0; i < N; i++ )
            {
                if (arr[i] == candidateMajorityElement)
                    count++;
            }

            if (count > N / 2)
                return candidateMajorityElement;
            else
                return null;
        }


    }
}
