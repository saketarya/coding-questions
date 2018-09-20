using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eugene
{
    public class ArrayProblems
    {
        /**
         * Given an array of positive integers (excluding zero) and a target number. 
         * Detect whether there is a set of consecutive elements in the array that add up to the target.
            Example: a = {1, 3, 5, 7, 9}
            target = 8

            output = true ({3, 5})

            or target = 15
            output = true : {3, 5, 7}

            but if target = 6, output would be false. since 1 and 5 are not next to each other.
    
         * */
        public static bool HasContiguousPartnersForGivenSum(uint[] arr, uint target)
        {
            if (arr == null || arr.Length == 0)
                throw new ArgumentException("arr");

            uint runningSum = arr[0];
            for (int i = 0, j = 0; i < arr.Length && j < arr.Length;)
            {
                if (runningSum == target)
                    return true;

                if (runningSum > target)
                {
                    if (i == j)
                    {
                        j = ++i;
                        runningSum = arr[i];
                    }
                    else
                    {
                        runningSum -= arr[i++];
                    }
                }
                else // runningSum < target
                {
                    runningSum += arr[++j];
                }
            }

            return false;
        }

        /**
         * Above problem Follow-up: what if the numbers are not necessarily positive?
         * */
        public static bool HasContiguousPartnersForGivenSum(int[] arr, int target)
        {
            //e.g. [2,1,1,4,-1,-2,3]
            // target T = 0
            // Hint: Create a cumulative sum array C starting with the first value = 0
            //      Now, iterate through C maintaining a HashSet H
            //          var v = C[i] - T    
            //          if(v exists in H => you have moved ahead on the road and are at a point which is 
            //              T far from Xth element (X being the position of v in lookup)
            //          else insert v in H

            int[] cumulativeSum = new int[arr.Length + 1];
            for (int i = 0; i < arr.Length; i++)
            {
                cumulativeSum[i + 1] = cumulativeSum[i] + arr[i];
            }

            HashSet<int> lookup = new HashSet<int>();
            foreach (var milestone in cumulativeSum)
            {
                var savepoint = milestone - target;
                if (lookup.Contains(savepoint))
                    return true;

                lookup.Add(savepoint);
            }

            return false;
        }


        public byte[] MultiplyTwoLargeNumbers_UsingFastFourierTransform(int a, int b)
        {
            //A[] = get digits from 'a' and store those in byte array (first element hoding digit at unit's place, second at 10's place ...so on)
            //B[] = same way, get digits from 'b'
            // Pad the smaller array with zeros to meet the length of larger one

            // Multiply corresponding elements from A and B (starting from index 0 moving right). 
            // C[i] = A[i] * B[i]
            int temp = a <= b ? a : b; //smaller one
            if (temp != a) // i.e a > b => swap a and b
            {
                // temp is b
                b = a;
                a = temp;
            }

            int[] A = GetReverseDigitsArray(a);
            int[] B = GetReverseDigitsArray(b);
            int[] pResult = new int[A.Length + B.Length];

            int k = 0;
            for (int i = 0; i < A.Length; i++)
            {
                var l = k;
                for (int j = 0; j < B.Length; j++)
                {
                    pResult[l] += (B[j] * A[i]);
                    l++;
                }

                k++;
            }

            int len = pResult.Length - 1;
            while (pResult[len] == 0)
            {
                len--;
            }

            // for Matrix[M][N] where M = pResult.Length and N = B.Length*2
            int[][] matrix = new int[len + 1][];  //B.Length*2
            for (int resultIndex = 0; resultIndex < len + 1; resultIndex++)
            {
                matrix[resultIndex] = GetReverseDigitsArray(pResult[resultIndex], resultIndex, len + 1);
            }

            List<byte> final = new List<byte>();
            byte carry = 0;
            // For every colum -> for every row
            for (int m = 0; m < matrix.GetUpperBound(1); m++)
            {
                var val = 0;
                for (int l = 0; l < matrix.GetUpperBound(0); l++)
                {
                    val += matrix[l][m] + carry;
                }

                carry = (byte)(val / 10);
                final.Add((byte)(val % 10));
            }

            if (carry > 0)
                final.Add(carry);

            final.Reverse();
            return final.ToArray();
        }

        private int[] GetReverseDigitsArray(int b, int padFirstNum = 0, int adjustMaxLength = 0)
        {
            List<int> digits = new List<int>();
            if (padFirstNum > 0)
            {
                digits.AddRange(new int[padFirstNum]);
            }

            while (b > 0)
            {
                digits.Add(b % 10);
                b = b / 10;
            }

            if (adjustMaxLength > digits.Count)
            {
                digits.AddRange(new int[adjustMaxLength - digits.Count]);
            }

            return digits.ToArray();
        }

    }


}
