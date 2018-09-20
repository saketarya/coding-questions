using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingProblems
{
    public class Eugene
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
            if(arr == null || arr.Length == 0)
                throw new ArgumentException("arr");

            uint runningSum = arr[0];
            for (int i = 0, j = 0; i < arr.Length && j < arr.Length;)
            {
                if(runningSum == target)
                    return true;
                
                if(runningSum > target)
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

        public static bool EfficientSumSubarray(uint[] arr, uint target)
        {
            if (arr == null || arr.Length == 0)
                return false;

            uint sum = 0;
            int e = 0;            
            for(int s=0;s<arr.Length;s++)
            {
                while(sum < target && e < arr.Length)
                {
                    sum += arr[e++];
                }

                if (sum < target) // => you finished all items in array yet sum could not reach target
                    return false;

                else if (sum == target)
                    return true;
                else // => sum > target
                    sum -= arr[s];
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

            int[] cumulativeSum = new int[arr.Length+1];
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

                lookup.Add(milestone);
            }

            return false;
        }

        /**
        Given an array of integers and a number k, write a function that returns true if given array can be divided into pairs such that sum of every pair is divisible by k.

        Examples:

        Input: arr[] = {9, 7, 5, 3}, k = 6
        Output: True
        We can divide array into (9, 3) and (7, 5).
        Sum of both of these pairs is a multiple of 6.

        Input: arr[] = {92, 75, 65, 48, 45, 35}, k = 10
        Output: True
        We can divide array into (92, 48), (75, 65) and 
        (45, 35). Sum of all these pairs is a multiple of 10.

        Input: arr[] = {91, 74, 66, 48}, k = 10
        Output: False

        **/
        public static bool HasCorrectPairs()
        {
            return true;
        }


        /**
        Given a string S (say bdaebcwagtadb) and a list of characters T (say abc), find 
            1. All the subsequence of appearce of all chars in T - ORDER NOT IMPORANT (e.g aebc, bcwa etc)
            2. the sub-sequence S1 in S where all chars in T appear the closest to each other. - ORDER NOT IMPORANT
        **/
        public static string ShortestSubsequenceInSCoveringT(string S, string T)
        {
            var sourceEmpty = string.IsNullOrEmpty(S);
            var targetEmpty = string.IsNullOrEmpty(T);
            if (sourceEmpty || targetEmpty)
                return null;

            //Edge1: T can have duplicates e.g abac

            //1. Create a map of chars in T such that [K,V] = [char, frequency in T] e.g. {{a,2}, {b,1}, {c,1}}
            //2. Maintain a count RemainingCount which matches the total frequency (2+1+1) of 
            //2. iterate thru chars in S from start=0 to start=S.Lenght-T
            //  - if S[i] is in map.Keys, reduce the count of map[S[i]]. 
            //  - if map.CharToExhaustCount <= 0 =>> Print subsequence
            S = S.ToLower();
            T = T.ToLower();
            var map = new Map(T);
            int i = 0, j = 0;
            string minSub = null;

            if (map.RemainingCount == 0)
                throw new ApplicationException("Map created but lookup null...Not a valid case.");
            var startIdxUpperBound = S.Length - T.Length;
            do
            {
                // find next i such that S[i] exist in map
                while (i <= startIdxUpperBound && !map.Contains(S[i]))
                    i++;

                if (i > startIdxUpperBound)
                    return minSub;

                //map.Visited(S[i]);
                // Get subsequence start at i ending at j exhausting all chars in T       
                j = GetSubsequenceEndIndex(S, i, j, map);
                if (j == S.Length)
                    return minSub;

                Console.WriteLine(S.Substring(i, j - i + 1));
                // Check, compare and record(if needed) the  min Subsequence
                if (minSub == null || j - i + 1 < minSub.Length)
                    minSub = S.Substring(i, j - i + 1);

                // Remove S[i] from Map
                map.Remove(S[i]);
                i++;
            } while (j < S.Length);



            return null;
        }

        private static int GetSubsequenceEndIndex(string s, int i, int j, Map map)
        {
            if (map.RemainingCount <= 0)
                return j;

            // check if this is the first iteration
            if (j <= i)
                j = i;
            else
                j = j + 1;

            while (map.RemainingCount > 0 && j < s.Length)
            {                
                map.Visited(s[j]);
                if (map.RemainingCount == 0)
                    break;
                j++;
            }

            return j;
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

    public class Map
    {
        private Dictionary<char, int> _lookup = new Dictionary<char, int>();
        //private int _remainingCount = 0;

        public Map(string T)
        {
            if(!string.IsNullOrEmpty(T))
            {
                foreach(var c in T)
                {
                    this.Add(c);
                }
            }
        }

        public int RemainingCount {
            get
            {
                return (this._lookup.Values.Where(v => { return v > 0; })).Count();
            }
        }
        

        private void Add(char c)
        {
            if(!_lookup.Keys.Contains(c))
            {
                _lookup.Add(c,0);
            }

            _lookup[c]++;
            //RemainingCount++;
        }

        public void Visited(char c)
        {
            if (_lookup.ContainsKey(c))
            {
                _lookup[c]--;
                //RemainingCount--;
            }
        }

        public void Remove(char c)
        {
            if (_lookup.ContainsKey(c))
            {
                _lookup[c]++;
                //RemainingCount++;
            }
        }

        public bool Contains(char c)
        {
            return this._lookup.ContainsKey(c);
        }
    }
}
