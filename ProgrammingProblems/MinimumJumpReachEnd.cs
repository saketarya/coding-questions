using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingProblems
{
    public class MinimumJumpReachEnd
    {
        /**http://www.geeksforgeeks.org/minimum-number-of-jumps-to-reach-end-of-a-given-array/
         * Given an array of integers where each element represents the max number of steps that can be made forward from that element. Write a function to return the minimum number of jumps to reach the end of the array (starting from the first element). If an element is 0, then cannot move through that element.

Example:

Input: arr[] = {1, 3, 5, 8, 9, 2, 6, 7, 6, 8, 9}
Output: 3 (1-> 3 -> 8 ->9)
First element is 1, so can only go to 3. Second element is 3, so can make at most 3 steps eg to 5 or 8 or 9.
         * */

        public static int Recursive(int[] A)
        {
            if (A == null || A.Length == 0)
                return -1;
            if (A.Length == 1)
                return 0;

            var jumps = FindMinJumpsRecursive(A, 0);

            return jumps == int.MaxValue ? -1 : jumps;
        }

        private static int FindMinJumpsRecursive(int[] A, int i)
        {
            checked
            {
                if (A[i] == 0)
                    return int.MaxValue;
                else if (A[i] + i >= A.Length-1)
                    return 1;
                else
                {
                    var min = int.MaxValue-1;
                    for (int j = 1; j <= A[i]; j++)
                    {
                        min = Math.Min(min, FindMinJumpsRecursive(A, i + j));
                    }

                    return min + 1;
                }
            }
        }

        public static int Nsquare_LeftToRight(int[] A)
        {
            if (A == null || A.Length == 0)
                return -1;
            
            var Length = A.Length;
            if (Length == 1)
                return 0;

            var Jumps = new int[Length];
            for (int i = 1; i < Length; i++)
                Jumps[i] = int.MaxValue;

            for(int i = 1; i < Length; i++)
            {
                for(int j = 0; j<i; j++)
                {
                    if (j + A[j] >= i)
                    {
                        Jumps[i] = Math.Min(Jumps[i], Jumps[j]+1);
                    }
                }
            }

            return Jumps[Length - 1];
        }

        public static int Nsquare_RightToLeft(int[] A)
        {
            if (A == null || A.Length == 0)
                return -1;

            var Length = A.Length;
            if (Length == 1)
                return 0;

            // How many jumps to reach end from i
            var Jumps = new int[Length];
            var End = Length - 1;            
            for (int i = Length - 2; i >= 0; i-- )
            {
                if (A[i] == 0)
                    Jumps[i] = int.MaxValue;
                else if (A[i] + i >= End)
                    Jumps[i] = 1;
                else
                {
                    int min = int.MaxValue-1;
                    // Find min jump between [i+1, Min(i+A[i], End)]
                    for (int j = i + 1; j <= Math.Min(i + A[i], End); j++)
                    {
                        min = Math.Min(min, Jumps[j]);
                    }

                    Jumps[i] = min + 1;
                }
            }

            return Jumps[0];
        }
    }
}
