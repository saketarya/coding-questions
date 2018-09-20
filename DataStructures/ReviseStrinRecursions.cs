using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures
{
    class ReviseStrinRecursions
    {
        public static void StartPermutation(string inStr)
        {
            // check if string null or Empty
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("****************************************");
            bool[] taken = new bool[inStr.Length];
            DoPermutation(inStr, sb, taken, 0); //level = 0
        }

        private static void DoPermutation(string inStr, StringBuilder sb, bool[] taken, uint level)
        {
            //base case
            if (level == inStr.Length)
            {
                Console.WriteLine(sb.ToString());
                return;
            }

            // else recurse
            for (int i = 0; i < inStr.Length; i++)
            {
                // if the char position already in use:
                if (taken[i])
                {
                    continue;
                }
                else
                {
                    sb.Append(inStr[i]);
                    taken[i] = true;

                    // recurse
                    DoPermutation(inStr, sb, taken, level + 1);
                    taken[i] = false;
                    sb.Length -= 1;

                }

            }
        }

        public static void StartCombinations(string inStr)
        {
            StringBuilder sb = new StringBuilder();
            DoCombination(inStr, sb, 0, 0); // inString, sb, startIndex, level
        }

        private static void DoCombination(string inStr, StringBuilder sb, int startIdx, uint level)
        {
            // for every letter from start till End
                // append to SB
                // Print sb 
                // if you still haven't reached the last char, recurse
                // remove last char from sb.
            for (int i = startIdx; i < inStr.Length; i++)
            {
                sb.Append(inStr[i]);
                Console.WriteLine(sb.ToString());
                if (i < (inStr.Length - 1))
                {
                    // there are more characters to process
                    DoCombination(inStr, sb, i + 1, level + 1);
                }

                sb.Length -= 1;

            }
                
        }


        public static void StartPhoneCharComibation_Rcrsv(byte[] phoneNumber)
        {
            StringBuilder sb = new StringBuilder();
            DoPhoneCombination(phoneNumber, sb,  0);
        }

        private static void DoPhoneCombination(byte[] phoneNumber, StringBuilder sb, int level)
        {
            if (level == phoneNumber.Length)
            {
                Console.WriteLine(sb.ToString());
                return;
            }

            byte X = phoneNumber[level];

            int upCap = (X < 2) ? 1 : 3;

            for (byte i = 1; i <= upCap; i++)
            {
                sb.Append(PhoneNumberChars.GetChar(X, i));
                DoPhoneCombination(phoneNumber, sb, level + 1);
                sb.Length -= 1;
            }
        }

        public static void StartPhoneCharComibation_Ittv(byte[] phoneNumber)
        {
            
        }

        public static void StartPrintParenthesisCombo(int numOfPairs)
        {
            //StringBuilder sb = new StringBuilder(numOfPairs*2);
            char[] sb = new char[numOfPairs * 2];

            DoParenCombi(numOfPairs, numOfPairs, sb, 0);
        }

        private static void DoParenCombi(int l, int r, char[] sb, int idx)
        {
            if (l < 0 || r < l)
                return;

            if (l == 0 && r == 0)
            {
                Console.WriteLine(new string(sb));
            }
            else
            {
                if (l > 0)
                {
                    //sb.Append('(');
                    sb[idx] = '(';
                    DoParenCombi(l - 1, r, sb, idx + 1);
                    //sb.Length -= 1;
                }
                if (r > l)
                {
                    //sb.Append(')');
                    sb[idx] = ')';
                    DoParenCombi(l, r-1, sb, idx + 1);
                    //sb.Length -= 1;
                }
            }
        }

        public static void FindAllPelindroms(string inStr)
        {
            // null or empty check

            

            if (inStr.Length < 3)
            {
                // string of length 2/
                return;
            }
            

            int mid, i, j = 0;
            mid = inStr.Length / 2;
            if (inStr.Length % 2 == 0)
            {
                // even length                
                j = mid;
                i = mid - 1;
            }
            else
            {
                // odd lenght. Mid divides the array equally
                i = mid - 1;
                j = mid + 1;
            }

            ScanPelindromes(inStr, 0, inStr.Length-1);

        }

        private static void ScanPelindromes(string inStr, int L, int R)
        {

            // check for base case
            if(R-L <= 1 || L < 0 || R >= inStr.Length)
            {
                return;
            }

            // Get Mid and get the lastIndex of left array.
            //Get first index of right array
            int mid, iIdx, jIdx = 0;
            mid = (L+R) / 2;
            if ((R-L+1) % 2 == 0)
            {
                // even length                
                jIdx = mid;
                iIdx = mid - 1;
            }
            else
            {
                // odd lenght. Mid divides the array equally
                iIdx = mid - 1;
                jIdx = mid + 1;
            }

            int leftEnd = iIdx;
            int rightStart = jIdx;
            

            
            while (inStr[iIdx] == inStr[jIdx] &&  iIdx >= 0 && jIdx < inStr.Length)
            {
                Console.WriteLine(inStr.Substring(iIdx, jIdx - iIdx));
                iIdx--;
                jIdx++;
            }

            ScanPelindromes(inStr, L, leftEnd);
            ScanPelindromes(inStr, rightStart, R);

        }

        public static void PrintPalindromes(string inStr)
        {
            // check for null/empty
            // if inStr.Lenght <= 3: 
            for (int i = 0; i < inStr.Length; i++)
            {
                for (int j = i + 2; j < inStr.Length; j++)
                {
                    if (IsPalindrom(inStr, i, j))
                    {
                        Console.WriteLine(inStr.Substring(i, j-i+1));
                    }
                }
            }
        }

        private static bool IsPalindrom(string inStr, int i, int j)
        {
            if (i >= j)
            {
                return false;
            }

            for (int start = i, end = j; start < end; start++, end--)
            {
                if (inStr[start] != inStr[end])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
