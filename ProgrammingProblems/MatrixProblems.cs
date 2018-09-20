using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingProblems
{
    public class MatrixProblems
    {
        public void PrintMatrixInSpiral(int[,] matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException("matrix");

            int m = matrix.GetUpperBound(0)+1;
            int n = matrix.GetUpperBound(1)+1;

            int i = 0;
            int j =0;

            int R = n;
            int D = m;
            int L = -1;
            int U = -1;
            int[] result = new int[n*m];
            
            for (int x = 0; x < n*m;)
            {
                // move right
                while (j < R && x<n*m)
                {
                    //sb.Append(matrix[i, j]);
                    result[x++] = matrix[i, j];
                    j++;
                }
                j--;
                i++;
                U += 1;

                // Move down
                while (i < D && x < n * m)
                {
                    //sb.Append(matrix[i, j]);
                    result[x++] = matrix[i, j];
                    i++;
                }
                i--;
                j--;
                R -= 1;

                // Left
                while (j > L && x < n * m)
                {
                    //sb.Append(matrix[i, j]);
                    result[x++] = matrix[i, j];
                    j--;
                }
                j++;
                i--;
                D -= 1;

                // Up
                while (i > U && x < n * m)
                {
                    //sb.Append(matrix[i, j]);
                    result[x++] = matrix[i, j];
                    i--;
                }
                i++;
                j++;
                L += 1;
            }

            Console.WriteLine(string.Join(",", result));
        }
    }
}
