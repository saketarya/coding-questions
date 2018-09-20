using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures
{   
    public class MySingleLLNode //: BaseLLNode
    {   
        public MySingleLLNode Next {get; set;}
        public int Data { get; set; }
        public MySingleLLNode(int d)
        {
            this.Data = d;
        }
    }

    public class MyDblLLNode
    {
        public MyDblLLNode Prev { get; set; }
        public MyDblLLNode Next { get; set; }
    }

    public class MySingleLinkedList //: IMyLinkedList
    {

        public static MySingleLLNode CreateList(int data)
        {
            return new MySingleLLNode(data);
        }

        public static bool DeleteMe(ref MySingleLLNode list, int data)
        {
            MySingleLLNode head = list;

            // is the List empty?
            if (head == null)
                throw new NullReferenceException("List not initialized");

            // Is head.Data == data ? => DeleteFirst.
            if (head.Data == data)
            {
                list = list.Next;
                return true;
            }

            // if not, iterate until you get the node N where N.Next.Data == data OR N.Next == Null
            while (head.Next != null && head.Next.Data != data)
            {
                head = head.Next;
            }

            // N.Next == Null => No element found. return False.
            //if (head.Next == null)
            //    return false;
            if (head.Next != null && head.Next.Data == data)
            {
                head.Next = head.Next.Next;
                return true;
            }

            return false;
            // Otherwise => Found N. 
                // Set N.Next = N.Next.Next
        }

        public static MySingleLLNode AddFirst(MySingleLLNode list, int data)
        {
            MySingleLLNode node = new MySingleLLNode(data);
            node.Next = list;
            list = node;
            return list;
        }

        public static MySingleLLNode AddLast(MySingleLLNode list, int data)
        {
            MySingleLLNode node = new MySingleLLNode(data);
            MySingleLLNode head = list;
            while (head != null && head.Next != null)
            {
                head = head.Next;
            }

            if (head == null)
            {
                return node;
            }
            else
            {
                head.Next = node;
            }

            return list;
        }

        public static MySingleLLNode AddAscOrder(MySingleLLNode list, int data)
        {
            MySingleLLNode node = new MySingleLLNode(data);
            MySingleLLNode head = list;
            if (list == null)
            {
                return node;
            }
            else if(list.Data >= data)
            {
                return AddFirst(list, data);
            }
            
            // find the first element which is grater than Data
            while (head.Next != null && head.Next.Data < data)
            {
                head = head.Next;
            }

            node.Next = head.Next;
            head.Next = node;

            return list;
        }

        public static void PrintList(MySingleLLNode head)
        {
            if (head == null)
                throw new NullReferenceException("List is not initialized");

            StringBuilder sb = new StringBuilder();
            while (head != null)
            {
                sb.Append(head.Data );
                if (head.Next != null)
                    sb.Append(", ");
                head = head.Next;
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
