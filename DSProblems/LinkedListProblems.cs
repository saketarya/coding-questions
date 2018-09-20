using DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSProblems
{
    public class LinkedListProblems
    {
        public static void ReArrageList<T>(ILinkedList<T> list) where T : IComparable
        {
            /*
            *Given list a1->a2->a3->b1->b2->b3
            Produce a1->b1->a2->b2->a3->b3
            List length unknown.
            Given that the list length will always be even
            **/

            if(list.IsEmpty)
            {
                return;
            }

            // find the middle
            var slow = list.Head;
            var fast = list.Head;

            while(fast.Next != null && fast.Next.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            if (fast.Next == null)
                throw new ArgumentException("list length should be even.");

            // go to the middle ka previous node => B
            
            var A = list.Head;
            var B = slow.Next;

            //break the link
            slow.Next = null;

            while(B != null)
            {
                var N = B;
                B = B.Next;

                N.Next = A.Next;
                A.Next = N;
                A = N.Next;
            }
        }
        

        public static void DeleteDuplicates<T>(ILinkedList<T> list) where T : IComparable
        {
            if (list.IsEmpty)
                return;

            var x = list.Head;
            HashSet<T> lookup = new HashSet<T>();
            lookup.Add(x.Data);

            while(x!=null && x.Next !=null)
            {
                if(lookup.Contains(x.Next.Data))
                {
                    x.Next = x.Next.Next;
                }
                else
                {
                    lookup.Add(x.Next.Data);
                    x = x.Next;
                }
            }

            return;
        }

        public static INode<T> GetNthFromLast<T>(ILinkedList<T> list, int N) where T : IComparable
        {   
            if (list.IsEmpty || N < 1)
                return null;
            
            if(N==1)
            {
                return list.Tail;
            }

            INode<T> returnNode = null;
            int count = 1;
            var runner = list.Head;
            while(count < N)
            {
                if (runner == null)
                    throw new ArgumentException("N too big.");

                count++;
                runner = runner.Next;
            }

            returnNode = list.Head;
            while(runner.Next!=null)
            {
                returnNode = returnNode.Next;
                runner = runner.Next;
            }

            return returnNode;
        }

        public static void DeleteARandomNode<T>(ILinkedList<T> list, INode<T> node) where T : IComparable
        {
            if (node == null || node.Next == null)
                throw new ApplicationException("cannot delete the node as its null or the last node.");

            node.Data = node.Next.Data;
            node.Next = node.Next.Next;
        }

        public static ILinkedList<T> SplitMe<T>(ILinkedList<T> list, T pivotValue) where T : IComparable
        {
            if (list.IsEmpty)
                return list;

            var beforeList = new SingleLinkedList<T>();
            var afterList = new SingleLinkedList<T>();

            var runner = list.Head;
            INode<T> nextNode = null;
            while(runner!=null)
            {
                // You are going to place current node in either beforeList or afterlist. 
                // Once you do that, you will loose the pointer to next node in the original input list.
                // Keep a track of next node.
                nextNode = runner.Next;

                if(runner.Data.CompareTo(pivotValue) < 0) // data < pivotValue.
                {
                    // place in before list
                    beforeList.InsertLast(runner);
                }
                else if(runner.Data.CompareTo(pivotValue) == 0)
                {
                    // place that in head of after list
                    afterList.InsertFirst(runner);
                }
                else
                {
                    // place that in after list
                    afterList.InsertLast(runner);
                }

                runner = nextNode;
            }

            // merge the two lists into beforeList
            beforeList.Tail.Next = afterList.Head;
            beforeList.Tail = afterList.Tail;

            // return beforeList
            return beforeList;
        }

        public static bool IsPalindrome<T>(ILinkedList<T> list) where T :IComparable
        {
            if (list.IsEmpty)
                return false;

            if (list.Head.Next == null) // single element in list
                return true;

            // List has 2 or more nodes.
            // reach to the middle using fast runner.
            var slow = list.Head;
            var fast = list.Head;
            var S = new Stack<T>();

            while(fast!=null && fast.Next!=null)
            {
                S.Push(slow.Data);
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            if(fast!=null && fast.Next==null) //Odd sized list
            {
                // if its an odd sized list, slow pointer will be at the middle node 
                // e.g. in 1->2->3->2->1, slow.Data will be 3 at this stage.
                // For comparision with the stack values, move slow to the next Node.
                slow = slow.Next;
            }

            while(S.Count>0 && slow!=null)
            {
                if (S.Pop().CompareTo(slow.Data) != 0)
                    return false;

                slow = slow.Next;
            }

            if (S.Count > 0 || slow != null)
                throw new ApplicationException("Code Bug !!!");

            return true;
        }
    }
}
