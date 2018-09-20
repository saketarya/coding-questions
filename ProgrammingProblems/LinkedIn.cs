using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingProblems
{
    public class LinkedIn
    {
        public static void IteratNDimensionalJaggedArray()
        {
            var arr = new int[][][][]{
                    new int[][][]{
                        new int[][]{ 
                            new int[]{ 1,2}, new int[]{3,4,5 }
                        },
                        new int[][]{ new int[]{ 6 }, new int[]{7,8 } },
                        new int[][]{ new int[]{ 9,10} }
                    },
                    new int[][][]{
                        new int[][]{
                            new int[]{ 11,12}, new int[]{13,14,15 }
                        },
                        new int[][]{ new int[]{ 16 }, new int[]{17,18 } },
                        new int[][]{ new int[]{ 19,20,21} }
                    }
                };


            Iterate(arr);
        }

        private static void Iterate(object arr)
        {
            if (arr == null)
                return;

            if (arr.GetType().IsArray)
            {
                var x = arr as Array; 
                foreach(var info in x)
                {
                    Iterate(info);
                }
            }
            else
            {
                Console.Write("{0},", arr);
            }
        }
    }
}
