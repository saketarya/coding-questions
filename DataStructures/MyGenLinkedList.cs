using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures
{
    public interface IGenLinkedList<T> where T : IComparable<T>
    {
        //void CreateList();
        void InsertFirst(T data);
        void InsertLast(T data);
        void InsertAfter(T datatoInsertAfter, T data);
        T DeleteFirst();
        T DeleteLast();
        T DeleteWithValue(T data);
    }

    public class MyGenLinkedList<T> : IGenLinkedList<T>  where T : IComparable<T>
    {
        public class ListNode<U> where U : T, IComparable<U>
        {
            public ListNode<U> Next { get; set; }
            public U data { get; set; }
            //public ListNode(U val)
            //{
            //    this.data = val;
            //}            
        }

        private ListNode<T> head;
        private ListNode<T> tail;

        public MyGenLinkedList(T val)
        {
            this.head = new ListNode<T>();
            this.head.data = val;
            this.tail = this.head;
        }

        public void InsertFirst(T data)
        {
            ListNode<T> temp = new ListNode<T>();
            temp.data = data;
            temp.Next = this.head;
            this.head = temp;

            if (this.tail == null)
            {
                this.tail = temp;
            }
        }

        public void InsertLast(T data)
        {
            if (this.tail == null)
            {
                InsertFirst(data);
            }
            else
            {
                ListNode<T> temp = new ListNode<T>();
                temp.data = data;
                this.tail.Next = temp;
                this.tail = temp;
            }
        }

        public void InsertAfter(T datatoInsertAfter, T data)
        {
            ListNode<T> current = this.head;
            while (current != null && current.data.CompareTo(datatoInsertAfter) != 0)
            {
                current = current.Next;
            }

            if (current == null) // dataToInsertAfter not found
            {
                throw new ArgumentException("datatoInsertAfter not found in the list. Insert failed.");
            }

            ListNode<T> temp = new ListNode<T>();
            temp.data = data;
            temp.Next = current.Next;
            current.Next = temp;

            if (temp.Next == null)
            {
                this.tail = current.Next;
            }
        }

        public T DeleteFirst()
        {
            if (this.head == null)
            {
                throw new Exception("Nothing to delete");
            }

            ListNode<T> temp = this.head;
            this.head = this.head.Next;
            if (this.head == null)
            {
                this.tail = null;
            }

            return temp.data;
        }

        public T DeleteLast()
        {
            if (this.head == null)
            {
                throw new Exception("list is empty");
            }

            ListNode<T> temp = this.head;
            while (temp.Next != null && temp.Next.Next != null)
            {
                temp = temp.Next;
            }

            if (temp.Next == null) // first not to delete
            {
                return DeleteFirst();
            }
            else //if (temp.Next.Next == null) // delete temp.Next
            {
                ListNode<T> last = temp.Next;
                temp.Next = null;
                this.tail = temp;
                return last.data;                
            }
        }

        public T DeleteWithValue(T val)
        {
            if (this.head == null)
            {
                throw new Exception("list is empty");
            }

            ListNode<T> temp = this.head;
            if (temp.data.CompareTo(val) == 0) //first node to delete
            {
                return DeleteFirst();
            }

            while (temp.Next != null && temp.Next.data.CompareTo(val) != 0)
            {
                temp = temp.Next;
            }

            if (temp.Next == null) 
            {
                throw new Exception("node not found");
            }
            else
            {
                ListNode<T> del = temp.Next;
                temp.Next = temp.Next.Next;
                if (temp.Next == null)
                {
                    this.tail = temp;
                }

                return del.data;
            }
        }

        public void ReverseList()
        {
            if(this.head == null || this.head == this.tail)
            {
                // list is either empty on has only one node.
                return;
            }

            ListNode<T> N = null;
            ListNode<T> H1 = null;
            ListNode<T> temp = this.head;
            while(true)
            {
                N = temp.Next;
                temp.Next = H1;
                if (N == null)
                    break;

                H1 = temp;
                temp = N;
            }

            this.tail = this.head;
            this.head = temp;
        }

        public void PrintList()
        {
            ListNode<T> temp = this.head;
            Console.WriteLine();
            while (temp != null)
            {
                Console.Write("{0}, ", temp.data.ToString());
                temp = temp.Next;
            }

            if (this.head != null)
            {
                Console.Write("   Head={0}, Tail={1}", this.head.data.ToString(), this.tail.data.ToString());
            }
        }

        internal T FindNthToLast(int pos)
        {
            // list null            
            if (this.head == null)
            {
                throw new NullReferenceException("List is empty");                
            }

            if (pos <= 0)
            {
                throw new ArgumentException(string.Format("invalid position sought. N = {0}", pos));
            }
            // Run pointer P till count=pos
            ListNode<T> p = this.head;
            int counter = 1; 
            while(p!= null && counter < pos)
            {
                p = p.Next;
                counter++;
            }

            //Is P= null ? if so, you have crossed the list boundary ...throw OutfRange exception
            if (p == null)
            {
                throw new IndexOutOfRangeException("given index out of range.");
            }
            
            // Run pointer C from head...till you find P.Next == Null
            ListNode<T> C = this.head;
            while (p.Next != null)
            {
                C = C.Next;
                p = p.Next;
            }

            return C.data;
        }

        internal void DeleteNth(int pos)
        {
            if (pos < 1)
            {
                throw new ArgumentException("pos");
            }
            ListNode<T> nodeToDelete = this.head;
            int counter = 1;
            while (nodeToDelete != null && counter < pos)
            {
                nodeToDelete = nodeToDelete.Next;
                counter++;
            }

            if (nodeToDelete == null)
            {
                throw new IndexOutOfRangeException("pos ourside bounds");
            }

            this.DeleteNodeWithRef(ref nodeToDelete);
        }

        internal void DeleteNthUpdated(int pos)
        {
            if (pos < 1)
            {
                throw new ArgumentException("pos");
            }

            if (pos == 1)
            {
                DeleteFirst();
            }
            else
            {
                int counter = 2;
                ListNode<T> temp = this.head;

                while (temp.Next != null && counter < pos)
                {
                    temp = temp.Next;
                    counter++;
                }

                if (temp == null)
                {
                    throw new IndexOutOfRangeException("pos ourside bounds");
                }
                else
                {
                    temp.Next = temp.Next.Next;
                    if (temp.Next == null)
                    {
                        this.tail = temp;
                    }
                }
            }
        }

        internal void CreateCycle(int pos)
        {
            ListNode<T> temp = this.head;
            if (temp == null)
            {
                throw new Exception("Empty list");
            }
            if (pos < 0)
            {
                throw new ArgumentException("invalid position");
            }

            if (pos > 1)
            {
                // get ref to node at position P
                int counter = 1;
                while (temp!= null && counter < pos)
                {
                    temp = temp.Next;
                    counter++;
                }

                if (temp == null)
                {
                    throw new ArgumentException("Position exceeds the list length");
                }
            }

            ListNode<T> cycleAt = temp;
            // go to last node.
            while (temp.Next != null)
            {
                temp = temp.Next;
            }

            // set lastNode.Next = P
            temp.Next = cycleAt;

            // No tail now - do not update the tail - ... we will use this pointer to validate once we break the cycle.           

        }

        internal void CheckAndBreakCycle()
        {
            ListNode<T> fast = this.head;
            ListNode<T> slow = this.head;

            // check if empty list

            // if only one node in list
            if (fast.Next == null)
            {
                // no cycle.
                Console.WriteLine("No cycle");
                return;
            }

            do
            {
                fast = fast.Next.Next;
                slow = slow.Next;
            } while (fast != null && fast.Next != null && fast != slow);

            if (fast == null || fast.Next == null)
            {
                //No cycle.
                Console.WriteLine("No cycle");
            }
            else
            {
                // slow and fast met
                slow = this.head;                
                while (slow != fast)
                {
                    slow = slow.Next;
                    fast = fast.Next;
                }

                // You got the meeting point. at S
                // now run fast to get Fast.Next = slow. then set Fast.Next = null
                while (fast.Next != slow)
                {
                    fast = fast.Next;
                }
                fast.Next = null;

                // check if fast == this.tail.
                if (fast == this.tail)
                {
                    Console.WriteLine("Spot on");
                }
            }
        }

        private void DeleteNodeWithRef(ref ListNode<T> nodeToDelete)
        {
            if (nodeToDelete == null)
            {
                throw new ArgumentNullException("nodeToDelete");
            }

            nodeToDelete.data = nodeToDelete.Next.data;
            nodeToDelete.Next = nodeToDelete.Next.Next;
        }
    }
}
