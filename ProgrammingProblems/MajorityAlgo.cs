using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingProblems
{
    public class MajorityAlgo
    {
        // http://www.geeksforgeeks.org/majority-element/
        /**
         * Majority Element: A majority element in an array A[] of size n is an element that appears more than n/2 times 
         * (and hence there is at most one such element).
           
       Write a function which takes an array and emits the majority element (if it exists), otherwise prints NONE as follows:

       I/P : 3 3 4 2 4 4 2 4 4
       O/P : 4 

       I/P : 3 3 4 2 4 4 2 4
       O/P : NONE
         * **/
        // MooresVotingAlgo
        public static int? FindMajorityElement(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return null;

            var N = arr.Length;

            // STEP 1: Find a candidate element having Majority (if exists such element)
            var candidateMajorityElementIndex = 0;
            var count = 1;

            for (int i = 1; i < N;i++)
            {
                if (arr[i] == arr[candidateMajorityElementIndex])
                    count++;
                else
                    count--;

                if (count == 0)
                {
                    candidateMajorityElementIndex = i;
                    count = 1;
                }
            }

            if (count == 0)
            {
                // No majority element exists
                return null;
            }

            // STEP 2: confirm the frequency of the candidate majority element is > N/2.
            var candidateMajorityElement = arr[candidateMajorityElementIndex];
            count = 0;
            for (int i = 0; i < N; i++ )
            {
                if (arr[i] == candidateMajorityElement)
                    count++;
            }

            if (count > N / 2)
                return candidateMajorityElement;
            else
                return null;
        }



        /**
         * Given an array of 2n elements of which n elements are same and the remaining n elements are all different. 
         * Write a program to find out the value which is present n times in the array. 
         * There is no restriction on the elements in the array. They are random (In particular they not sequential).
        
From <https://www.careercup.com/question?id=9167198> 


Solution:
Note that there is only one integer that is repeating and occurs M times.
Rest others are all distinct.

It's like you have 2M places to fill with:
	- M same color balls - Say BLUE
	- M all different color balls 
		○ all Non Blue  
		○ no two balls with same color

Any random placement (other than following two cases) would have at least one pair of adjacent Blue balls.
e.g.  Red Blue Green Blue Blue Purple
So, in one pass we can compare adjacent pairs. If we find an adjacent pair, we know what color is repeating.

So for given array A = [1,2,1,1,4,6]
For(int i=0; i<length -1; i++)
	If( A[i] == A[i+1] )
		Return A[i];

=> O(n) Runtime, no space

Only in following arrangements, we will find no adjacent blue pairs
e.g. for M = 3
CASE 1: Red Blue Green Blue purple Blue 
CASE 2:  Blue Green Blue purple Blue Red
CASE 3:  Blue Red Green Blue ( for M = 2)

In #1 and #2. we can see that for a max span of 4, we can find the repeating element.

So, if we failed to find a repeating element in above steps =>
If( A[0] == A[2])    // case 2
   || A[0] == A[3] ) // case 3
	 Return A[0];
Else if ( A[1] == A[3] ) // case 1


There is a corner case when M = 1
CASE 4: Red Blue
CASE 5: Blue Red 

In #4 and #5, the input will be invalid as there are no repeating colors.
=> M should always be > 1

         * **/
        public static int? FindMajorityElement_2NElements(int[] arr)
        {
            if (arr == null || arr.Length == 0)
                return null;

            var N = arr.Length;
            if (N == 1 || N%2 != 0)
                return null;

            if(N == 2)
            {
                return (arr[0] == arr[1] ? null : (int?)arr[0]);
            }

            for (int i = 0; i < N-1; i++)
            {
                if (arr[i] == arr[i + 1])
                    return arr[i];
            }  
         
            if(N == 2)
            {
                // If 2M == 2 => M =1 => No repeating element since you reached here.
                return null;
            }

            if (arr[0] == arr[2] || arr[0] == arr[3])
                return arr[0];
            else if (arr[1] == arr[3])
                return arr[1];

            return null;
        }
    }
}
