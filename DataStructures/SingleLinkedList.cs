using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures
{
    public interface INode<T> where T : IComparable
    {
        T Data { get; set; }
        INode<T> Next { get; set; }
    }

    public class LLNode<T> : INode<T> where T : IComparable
    {
        public T Data { get; set; }
        public INode<T> Next { get; set; }

        public int CompareTo(T other)
        {
            return this.Data.CompareTo(other);
        }
    }


    public interface ILinkedList<T> where T : IComparable
    {
        INode<T> Head { get; set; }

        INode<T> Tail { get; set; }

        void InsertFirst(T data);

        void InsertAfter(T afterThis, T data);

        void InsertBefore(T beforeThis, T data);

        void InsertLast(T data);

        INode<T> Delete(T data);

        INode<T> DeleteFirst();

        INode<T> DeleteAfter(T afterThis);

        INode<T> DeleteBefore(T beforeThis);

        INode<T> DeleteLast();

        bool IsEmpty { get; }

        void Print();
    }

        

    public class SingleLinkedList<T> : ILinkedList<T> where T : IComparable
    {   
        public SingleLinkedList()
        {
        }

        private SingleLinkedList(T value)
        {
            this.Head = new LLNode<T> { Data = value };
            this.Tail = this.Head;
        }        

        public INode<T> Head { get; set; }
        public INode<T> Tail { get; set; }
        public bool IsEmpty {
            get
            {
                return this.Head == null;
            }
        }

        public static ILinkedList<T> CreateList(T value)
        {
            return new SingleLinkedList<T>(value);
        }

        

        public void InsertFirst(T data)
        {
            if (this.IsEmpty)
            {
                this.Head = new LLNode<T> { Data = data };
                this.Tail = this.Head;
            }
            else
            {
                var newNode = new LLNode<T> { Data = data, Next = this.Head };
                this.Head = newNode;
            }
        }

        public void InsertFirst(INode<T> node)
        {
            if (node != null)
            {
                node.Next = this.Head;
                this.Head = node;
                this.Tail = this.Tail == null ? node : this.Tail;
            }
        }

        public void InsertLast(INode<T> node)
        {
            if (node != null)
            {
                if (this.IsEmpty)
                    InsertFirst(node);
                else
                {
                    node.Next = null;
                    this.Tail.Next = node;
                    this.Tail = node;
                }
            }
        }

        public void InsertAfter(T afterThis, T data)
        {
            // Find Data 
            // if found
            // newNode.Next = Node.Next
            // Node.Next = newNode
            if (this.IsEmpty)
            {
                throw new ArgumentException("List is empty");
            }

            var node = this.Head;
            while(node != null && node.Data.CompareTo(afterThis) != 0)
            {
                node = node.Next;
            }

            if(node==null)
            {
                // Not found
                throw new ArgumentException("Failed to find node to insert after.");
            }
            else
            {
                var newNode = new LLNode<T> { Data = data };
                newNode.Next = node.Next;
                node.Next = newNode;
                this.Tail = newNode.Next == null ? newNode : this.Tail;
            }
        }

        public void InsertAfter(INode<T> afterNode, INode<T> node)
        {
            // Find Data 
            // if found
            // newNode.Next = Node.Next
            // Node.Next = newNode
            if (afterNode == null)
            {
                throw new ArgumentException("afterNode");
            }

            if (node == null)
                return;

            node.Next = afterNode.Next;
            afterNode.Next = node;
        }

        public void InsertBefore(T beforeThis, T data)
        {
            // Find Data - using Node.Next value
            // if found
            // newNode.Next = Node.Next
            // Node.Next = newNode
            if(this.IsEmpty)
            {
                throw new ArgumentException("List is empty");
            }

            var newNode = new LLNode<T> { Data = data };
            
            //if beforNode is the head node>
            if(this.Head.Data.CompareTo(beforeThis) == 0)
            {
                newNode.Next = this.Head;
                this.Head = newNode;
                return;
            }

            var runner = this.Head;
            // If before node is in the middle of List or even the last node
            while (runner.Next != null && runner.Next.Data.CompareTo(beforeThis) != 0)
            {
                runner = runner.Next;
            }

            if(runner.Next == null)
            {
                // Not found
                throw new ArgumentException("Failed to find node to insert before.");
            }


            newNode.Next = runner.Next;
            runner.Next = newNode;
        }

        public void InsertLast(T data)
        {
            if (this.IsEmpty)
            {
                this.Head = new LLNode<T> { Data = data };
                this.Tail = this.Head;
            }
            else
            {
                var newNode = new LLNode<T> { Data = data };
                this.Tail.Next = newNode;
                this.Tail = newNode;
            }
        }        

        public INode<T> Delete(T data)
        {
            if (this.IsEmpty)
                throw new ArgumentException("List is empty");

            INode<T> deleteNode = null;

            // Delete first node?
            if (this.Head.Data.CompareTo(data) == 0)
            {
                deleteNode = this.Head;
                this.Head = this.Head.Next;
                if (this.Head == null)
                    this.Tail = null;                
            }
            else
            {                
                // Find Data
                var runner = this.Head;
                while(runner.Next != null && runner.Next.Data.CompareTo(data)!=0)
                {
                    runner = runner.Next;
                }

                if(runner.Next != null)
                {
                    deleteNode = runner.Next;
                    runner.Next = runner.Next.Next;
                    if (this.Tail == deleteNode)
                        this.Tail = runner;
                }
            }

            return deleteNode;
        }

        public INode<T> Delete(INode<T> node)
        {
            if (this.IsEmpty)
                return null;

            INode<T> deleteNode = null;

            // Delete first node?
            if (this.Head == node)
            {
                deleteNode = this.Head;
                this.Head = this.Head.Next;
                if (this.Head == null)
                    this.Tail = null;
            }
            else
            {
                // Find Data
                var runner = this.Head;
                while (runner.Next != null)
                {
                    if(runner.Next == node)
                    {
                        deleteNode = runner.Next;
                        runner.Next = runner.Next.Next;
                        if(this.Tail == deleteNode)
                        {
                            this.Tail = runner;
                        }
                        return deleteNode;
                    }

                    runner = runner.Next;
                }
            }

            return deleteNode;
        }

        public INode<T> DeleteFirst()
        {
            if (this.IsEmpty)
                throw new ArgumentException("List is empty");

            INode<T> deleteNode = this.Head;
            this.Head = this.Head.Next;
            if (this.Head == null)
            {
                this.Tail = null;
            }

            return deleteNode;
        }

        public INode<T> DeleteAfter(T afterThis)
        {
            throw new NotImplementedException();
        }

        public INode<T> DeleteBefore(T beforeThis)
        {
            // Find Data - using Node.Next value
            // if found
            // newNode.Next = Node.Next
            // Node.Next = newNode
            throw new NotImplementedException();
        }

        public INode<T> DeleteLast()
        {
            if (this.IsEmpty)
                throw new ArgumentException("List is empty.");

            INode<T> deleteNode = null;
            var runner = this.Head;
            if(runner.Next == null) //had only one node. Delete head
            {
                this.Head = null;
                this.Tail = null;
                return deleteNode;
            }

            while(runner.Next.Next != null)
            {
                runner = runner.Next;
            }

            deleteNode = runner.Next;
            runner.Next = null;
            this.Tail = runner;

            return deleteNode;            
        }

        public void Print()
        {            
            if(this.IsEmpty)
            {
                Console.Error.WriteLine("Empty list");
                return;
            }

            var runner = this.Head;
            StringBuilder sb = new StringBuilder();
            while (runner != null)
            {
                sb.Append((runner.Data==null ? "NULL": runner.Data.ToString()));
                sb.Append(" ->");
                runner = runner.Next;
            }

            sb.Length -= 3;
            Console.WriteLine(sb.ToString());
            Console.WriteLine("[H,T]=[{0},{1}]", 
                (this.Head.Data == null ? "NULL" : this.Head.Data.ToString()),
                (this.Tail.Data == null ? "NULL" : this.Tail.Data.ToString()));
        }
    }
}
