using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace DataStructures
{
    public class Arithmatics
    {
        public long GetFibonacci_Ittv(uint n)
        {
            if (n < 1)
                throw new ArgumentException("no elements");

            if (n == 1)
            {
                return 0;
            }
            else if (n == 2)
            {
                return 1;
            }

            uint count = 2;
            long x = 0, a = 0, b = 1;
            while (count < n)
            {
                x = a + b;
                a = b;
                b = x;
                count++;
            }

            return x;
        }

        public long GetFibonacci_Ittv2(uint n)
        {
            if (n < 1)
            {
                throw new ArgumentException("Invalid index provided.");
            }

            uint count = 1;
            long X = 0, Y = 0, Z = 1;
            while (count < n)
            {
                X = Y;
                Y = Z;
                Z = X + Y;
                count++;
            }

            return Z;
        }

        public long GetFibonacci_Rcrsv(uint n)
        {
            if (n == 0)
                throw new ArgumentException("no elements");

            if (n == 1)
            {
                return 0;
            }
            else if (n == 2)
            {
                return 1;
            }

            return GetFibonacci_Rcrsv(n - 1) + GetFibonacci_Rcrsv(n - 2);
        }

        /// <summary>
        /// Given coins of some denominations (say 4, 5, 7), find the least number of coins to user so to get a number N.
        /// E.g. N = 100
        /// Coins = 4, 5, 7
        /// Solution = 7*13 + 5 + 4 => 15 coins
        /// </summary>
        /// <returns>Minimum Number of coins </returns>


        public static int StartGetLeastCoinsForANumber(int[] coinsColl, int N)
        {
            // sort coins in descending order
            // create a dictionary where coin denomination is key and number od coins (solution) is value
            // first call of recursive function passing empty dictionary, coins collection, and coinIdx 0
            // if dict.Keys.Count == 0 => No solution
            // else, sum of all values.

            
            
            MyComparer comp = new MyComparer();
            Array.Sort<int>(coinsColl, comp);

            Dictionary<int, int> dict = new Dictionary<int, int>();

            GetLeastCoinsForANumber(N, coinsColl, dict, 0);
            return dict.Values.Sum();
        }

        private static bool GetLeastCoinsForANumber(int N, int[] coins, Dictionary<int, int> sol, int coinIdx)
        {
            // if coinIdx in range, return false
            if (0 > coinIdx && coinIdx >= coins.Length)
            {
                return false;
            }

            if (N == 0)
            {
                return false;
            }

            int D = coins[coinIdx];
            int k = N/D;
            for(int i=k;i>=0;i--)
            {
              int leftover = N - D*i;
              if(leftover == 0)
              {
                  sol[D] = k;
                  return true;
              }
              
              for(int j=coinIdx+1;j<coins.Length;j++)
              {
                  bool hasSol = GetLeastCoinsForANumber(leftover, coins, sol, j);
                  if(hasSol)
                  {   sol[D] = i; return true; }
              }
            }

            return false;
        }

        //private static bool GetLeastCoinsForANumber(int N, int[] coins, Dictionary<int, int> sol, int coinIdx)
        //{
        //    // if coinIdx in range, return false
        //    if (0 > coinIdx && coinIdx >= coins.Length)
        //    {
        //        return false;
        //    }
        //    // if N = 0, return false

        //    int D = coins[coinIdx];
        //    int k = N / D;
        //    for (int i = k; i > 0; i--)
        //    {
        //        int leftover = N - D * i;
        //        if (leftover == 0)
        //        {
        //            sol[D] = k;
        //            return true;
        //        }

        //        for (int j = coinIdx + 1; j < coins.Length; j++)
        //        {
        //            bool hasSol = GetLeastCoinsForANumber(leftover, coins, sol, j);
        //            if (hasSol)
        //            { sol[D] = i; return true; }
        //        }
        //    }

        //    return false;
        //}

        private class MyComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                if (y == x)
                {
                    return 0;
                }
                else if (y > x)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }
    
    }
}
