using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingProblems
{
    public class Factorial
    {
        public static byte[] FindFactorial(int n)
        {
            if (n < 0)
                throw new ArgumentException("Invalid number.");
            
            var result = new List<byte>();
            if (n < 2)
            {
                result.Add(1);
                return result.ToArray();
            }

            // store the give number n in byte array - one index for one digit - In Reverse order
            // so 103 is saved like 3->0->1
            Init(result, n);
            
            for (int i = n-1; i > 0; i--)
            {
                MultiplyResultWithNumber(result, i);
            }

            result.Reverse();

            return (result.ToArray());
        }

        private static void Init(List<byte> result, int n)
        {
            while (n > 0)
            {
                result.Add((byte)( n%10));
                n /= 10;
            }
        }

        // Store digits in reverse order. Reverse the digits when caller is sending the final result
        private static void MultiplyResultWithNumber(List<byte> result, int i)
        {
            byte carry = 0;
            for (int d = 0; d < result.Count; d++)
            {
                var digit = result[d];
                int temp = (digit*i)+carry;
                result[d] = (byte) (temp%10);
                carry = (byte)(temp/10);
            }

            if (carry > 0)
                result.Add(carry);
        }
    }
}
