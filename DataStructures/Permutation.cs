using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures
{
    public static class PhoneNumberChars
    {   
        private static Dictionary<byte, string> numToChar = new Dictionary<byte, string>();

        static PhoneNumberChars()
        {
            InitializeNumToChars();
        }

        private static void InitializeNumToChars()
        {
            numToChar.Add(0, "0");
            numToChar.Add(1, "1");
            numToChar.Add(2, "ABC");
            numToChar.Add(3, "DEF");
            numToChar.Add(4, "GHI");
            numToChar.Add(5, "JKL");
            numToChar.Add(6, "MNO");
            numToChar.Add(7, "PRS");
            numToChar.Add(8, "TUV");
            numToChar.Add(9, "WXY");
        }

        public static char GetChar(byte num, byte pos)
        {
            if (num > 1)
            {
                string x = numToChar[num];
                if (x.Length < pos)
                {
                    throw new OverflowException("invalid position seek.");
                }
                else if (pos == 0)
                {
                    throw new ArgumentException("Invalid position.");
                }

                return x[pos-1];
            }
            else
            {
                return numToChar[num][0];
            }
            //else if(num < 0)
            //{
            //    throw new ArgumentException("Invalid digit in phone");
            //}
        }
    }

    class Permutation
    {
        private void swap(ref char a, ref char b)
        {
            if (a == b) return;
            a ^= b;
            b ^= a;
            a ^= b;
        }

        public void setper(char[] list)
        {
            int x = list.Length - 1;
            go(list, 0, x);
        }

        private void go(char[] list, int k, int m)
        {
            int i;
            if (k == m)
            {
                Console.Write(list);
                Console.WriteLine(" ");
            }
            else
                for (i = k; i <= m; i++)
                {
                    swap(ref list[k], ref list[i]);
                    go(list, k + 1, m);
                    swap(ref list[k], ref list[i]);
                }
        }



        public void SetCombi(string inStr)
        {
            char[] arr = inStr.ToCharArray();
            StringBuilder sb = new StringBuilder();
            DoCombi(arr, sb, inStr.Length, 0, 0);
        }

        private void DoCombi(char[] arr, StringBuilder sb, int length, int start, int level)
        {
            for (int i = start; i < length; i++)
            {
                sb.Append(arr[i]);
                Console.WriteLine(sb.ToString());
                if (i < length - 1)
                {
                    DoCombi(arr, sb, length, i + 1, level + 1);
                }

                sb.Length = sb.Length - 1;
            }
        }

        public void SetPermutation(string inStr)
        {
            char[] arr = inStr.ToCharArray();
            bool[] used = new bool[inStr.Length];
            StringBuilder sb = new StringBuilder();
            DoPerm(arr, used, sb, inStr.Length, 0);
        }

        private void DoPerm(char[] arr, bool[] used, StringBuilder sb, int len, int level)
        {
            //exit criteria
            if (level == len)
            {
                Console.WriteLine(sb.ToString());
                return;
            }

            for (int i = 0; i < len; i++)
            {
                if (used[i])
                { continue;  }

                sb.Append(arr[i]);
                used[i] = true;
                // find permutation for (n+1)
                DoPerm(arr, used, sb, len, level + 1);

                used[i] = false;
                sb.Length = sb.Length - 1;
            }
        }

        public void SetPhoneCharConfig(byte[] phoneNum)
        {
            int len = phoneNum.Count();
            StringBuilder sb = new StringBuilder();
            DoPhoneCombi(phoneNum, sb, len, 0);
        }

        private void DoPhoneCombi(byte[] arr, StringBuilder sb, int len, int level)
        {
            if (level == len)
            {
                Console.WriteLine(sb.ToString());
                return;
            }

            byte x = arr[level];
            int upCap = (x < 2) ? 1 : 3;            

            for (byte i = 1; i <= upCap; i++)
            {
                sb.Append(PhoneNumberChars.GetChar(x, i));
                DoPhoneCombi(arr, sb, len, level + 1);
                sb.Length -= 1;
            }
        }

        public static void SwapUs<T>(ref T a, ref T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }

    }
}
