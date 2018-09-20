using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures
{
    public class StringMan
    {
        public static string FindLongestPelindromeON(string instr)
        {
            // preprocess string. Insert ^ at start. Insert # between chars. Insert $ at end.
            // create an array of int with same length as of the string.
            // Start from i = 1.... till i < Len -1
            // C = 0 //CENTER of longest pelindrom found so far
            // R = 0 //RIGHT edge of longest pelindrom found so far
            // For each i, find P[i].
            // If RIGHT edge stands at a greater idx than i (R > i), P[i] = P[i_mirror] (where i_mirror = C -(i-C) => 2C-i)
            // Else, expand in both directions from i until T[i-P[i]-1] == T[i+P[i]+1] 
            //      => increment length of pelindrom centered at i. =>   P[i]++
            // Update R if you found another pelindrom with its RIGHT edge across the RIGHT edge of previous pelindrom.
            // if (i + P[i]) > R
            //      R = i + P[i]
            //      C = i

            // from the P array. find the CENTER and MAX_LEN of pelindrom  => O(N)
            // in original string the start of pelindrom would be at idx (CENTER - MAX_LEN - 1)/2 and length would be P[i]

            // preprocess string. Insert ^ at start. Insert # between chars. Insert $ at end.
            StringBuilder sb = new StringBuilder("^#");
            foreach(char c in instr)
            {
                sb.AppendFormat("{0}#", c);
            }

            sb.Append("$");
            string T = sb.ToString();

            // create an array of int with same length as of the string.
            int[] P = new int[T.Length];

            // C = 0 //CENTER of longest pelindrom found so far
            // R = 0 //RIGHT edge of longest pelindrom found so far
            int C = 0;
            int R = 0;
            int i_mirror = 0;
            // Start from i = 1.... till i < Len -1
            for (int i = 1; i < T.Length - 1; i++)
            {
                // For each i, find P[i].
                // If RIGHT edge stands at a greater idx than i (R > i), P[i] = P[i_mirror] (where i_mirror = C -(i-C) => 2C-i)
                // Else start with P[i] = 0 and expand pelin check in both directions from i => P[i] = 0
                i_mirror = 2 * C - i;
                P[i] = (R > i) ? P[i_mirror] : 0;

                // expand in both directions from i until T[i-P[i]-1] == T[i+P[i]+1] 
                //      => increment length of pelindrom centered at i. =>   P[i]++
                while (T[i - P[i] - 1] == T[i + P[i] + 1])
                {
                    P[i]++;
                }
                                
                // Update R if you found another pelindrom with its RIGHT edge across the RIGHT edge of previous pelindrom.
                // if (i + P[i]) > R
                //      R = i + P[i]
                //      C = i
                if ((i + P[i]) > R)
                {
                    R = i + P[i];
                    C = i;
                }
            }
            
            // from the P array. find the CENTER and MAX_LEN of pelindrom  => O(N)
            int CENTER = 0;
            int MAX_LEN = 0;
            for (int idx = 0; idx < P.Length; idx++)
            {
                if (P[idx] > MAX_LEN)
                {
                    MAX_LEN = P[idx];
                    CENTER = idx;
                }
            }


            // in original string the start of pelindrom would be at idx (CENTER - MAX_LEN - 1)/2 and length would be P[i]
            return instr.Substring((CENTER - MAX_LEN - 1)/2, MAX_LEN);
        }

        public static string FindLongestPelindromeON2(string instr)
        {
            int n = instr.Length;
            string longest = instr.Substring(0, 1);
            string temp;
            for (int i = 0; i < n - 1; i++)
            {
                // find longest pelindrome using ith char as center
                temp = ScanforPelindromeInBothDir(instr, i, i);
                if (temp.Length > longest.Length)
                {
                    longest = temp;
                }

                // find longest pelindrome using center between ith and (i+1) char 
                temp = ScanforPelindromeInBothDir(instr, i, i + 1);
                if (temp.Length > longest.Length)
                {
                    longest = temp;
                }
            }

            return longest;
        }

        private static string ScanforPelindromeInBothDir(string instr, int leftIdx, int rightIdx)
        {
            int left = leftIdx;
            int right = rightIdx;
            while (left >= 0 && right <= instr.Length-1 && instr[left] == instr[right])
            {
                left--;
                right++;
            }

            return instr.Substring(left+1, right - left -1);
        }

        public static string FindFirstUniqueChar(string input)
        {
            // char type has a size of 16 bits (2 bytes). 
            /* With the UTF-16 encoding that Java uses internally for strings, only about 
            the first 216 Unicode characters or code points (the Basic Multilingual Plane or BMP) can be represented
            in a single char; the remaining code points require two chars (4 bytes).
            Such code points are called to form surrogate pairs.
            **/
            // Surrogate pairs are handled as two different characters when you break the string down, 
            //  so they won't be printed as one value
            if (string.IsNullOrEmpty(input))
                return null;

            Dictionary<int, CharExistenceStats> lookup = new Dictionary<int, CharExistenceStats>();
            for (int i = 0; i < input.Length;)
            {
                var c = (int)input[i];
                i += char.IsSurrogatePair(input, i) ? 2 : 1;
                if (lookup.Keys.Contains(c))
                {
                    var data = lookup[c];
                    data.SeenMultipleTimes = true;
                }
                else
                {
                    lookup.Add(c, new CharExistenceStats());
                }
            }

            for (int i = 0; i < input.Length;)
            {
                var c = (int)input[i];
                i += char.IsSurrogatePair(input, i) ? 2 : 1;
                if (lookup.Keys.Contains(c) && !lookup[c].SeenMultipleTimes)
                    return char.ConvertFromUtf32(c);
            }

            return null;

        }

        private class CharExistenceStats
        {
            public bool SeenMultipleTimes { get; set; }
        }

        public static string ReverseString(string input)
        {
            if(string.IsNullOrEmpty(input))
                return input;

            var arr = input.ToCharArray();

            // First reverse the whole string
            ReverseInPlace(arr, 0, arr.Length-1);

            // Now reverse each word
            int wStart = 0;
            for(int i=0;i<arr.Length;)
            {
                if(char.IsWhiteSpace(arr[i]))
                {
                    ReverseInPlace(arr, wStart, i-1);                    
                    wStart = i+1;
                }

                i++;
            }

            if(wStart < arr.Length)
            {
                ReverseInPlace(arr, wStart, arr.Length - 1);
            }

            return new string(arr);
        }

        public static void ReverseInPlace(char[] arr, int start, int end)
        {
            for (int i = start, j = end; i < j; i++, j--)
            {
                Swap(arr, i, j);
            }
        }

        public static bool IsIsomorphic(string s, string t)
        {
            if (string.IsNullOrEmpty(s) && string.IsNullOrEmpty(t))
                return true;

            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t))
                return false;
            var length = s.Length;
            if (length != t.Length)
                return false;

            Dictionary<char, char> map = new Dictionary<char, char>();
            for(int i=0; i< length; i++)
            {
                char a = s[i];
                char b = t[i];
                if (!map.ContainsKey(a))
                {
                    var k = getKeyForValue(map, b);
                    if (k != default(char) && k != a)
                        return false;

                    map[a] = b;
                }
                else if (map[a] != b)
                    return false;
            }

            return true;
            
        }

        private static char getKeyForValue(Dictionary<char, char> map, char b)
        {
            var kv =  map.Where(k => { return k.Value == b; }).FirstOrDefault();
            return kv.Equals(default(KeyValuePair<char,char>)) ? default(char) : kv.Key;
        }        

        private static void Swap(char[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
