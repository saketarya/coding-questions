using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingProblems
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class OnlineJudge
    {
        /**
         * Given a singly linked list, group all odd nodes together followed by the even nodes. 
         * Please note here we are talking about the node number and not the value in the nodes.
         * You should try to do it in place. The program should run in O(1) space complexity and O(nodes) time complexity.
         * Example:
         * Given 1->2->3->4->5->NULL,
         * return 1->3->5->2->4->NULL.
         * **/
        public ListNode OddEvenList(ListNode head)
        {
            var N = head;
            if (N == null) return head;
            var l1 = N;
            var l2 = N.next;
            ListNode nextNodeToProcess = null;

            while(N != null)
            {
                nextNodeToProcess = N.next;
                if(N.next != null)
                {
                    N.next = N.next.next;
                }

                N = nextNodeToProcess;
            }

            N = l1;
            while (N.next != null)
                N = N.next;

            N.next = l2;

            return l1;
        }


        public ListNode ArrangeEvenOddNodesByValue(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            
            ListNode N = head;
            ListNode otherList = null;
            ListNode tail2 = otherList;
            ListNode tail1 = N;
            bool isCurrentEven = N.val % 2 == 0;
            var compare = (N.val % 2 == 0) ? new Func<int, bool>(x => x % 2 != 0) : new Func<int, bool>(x => x % 2 == 0);
            
            while(N!=null)
            {
                if(N.next != null && compare(N.next.val))
                {
                    var t = N.next;
                    N.next = N.next.next;
                    t.next = null;
                    if(tail2 == null)
                    {
                        otherList = t;
                    }
                    else
                    {
                        tail2.next = t;
                    }

                    tail2 = t;
                }
                else
                {
                    tail1 = N;
                    N = N.next;
                }
            }

            if(isCurrentEven)
            {
                tail1.next = otherList;
                return head;
            }
            else
            {
                tail2.next = head;
                return otherList;
            }
        }

    }
}
