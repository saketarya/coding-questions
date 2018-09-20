using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures
{
    public class Node<T>
    {
        private T key;
        internal Node<T> left;
        internal Node<T> right;
        internal Node<T> parent;

        internal T Key
        {
            get
            {
                return this.key;
            }
        }

        public Node(T key)
        {
            this.key = key;
        }
    }

    class BST<P> where P: IComparable<P>
    {
        private Node<P> root;

        public BST(P data)
        {
            root = new Node<P>(data);
        }

        public BST(P[] arr)
        {
            root = PrepareBSTFromArray(arr);
        }

        public Node<P> Search(P data)
        {
            return null;
        }

        public bool Insert(P data)
        {
            Node<P> newNode = new Node<P>(data);
            Node<P> tempNode = this.root;
            Node<P> tempParent = null;
            while (tempNode != null)
            {
                tempParent = tempNode;
                if (data.CompareTo(tempNode.Key) == 0)
                {
                    return false;
                }
                else if (data.CompareTo(tempNode.Key) < 0)
                {
                    tempNode = tempNode.left;
                }
                else
                {
                    tempNode = tempNode.right;
                }
            }

            newNode.parent = tempParent;
            if (tempParent == null)
            {
                this.root = new Node<P>(data);
            }
            else if (data.CompareTo(tempParent.Key) <= 0)
            {
                tempParent.left = newNode;
            }
            else
            {
                tempParent.right = newNode;
            }

            return true;
        }

        public bool Delete(P data)
        {
            return true;
        }

        public void PrintInOrder()
        {
            Node<P> tNode = this.root;
            StringBuilder sb = new StringBuilder();
            Node<P> prevNode = tNode;
            while (tNode != null )
            {
                if (tNode.left != null && tNode.left != prevNode)
                {
                    tNode = tNode.left;
                }
                else if(tNode.right !=null)
                {
                    sb.AppendFormat("{0},", tNode.Key);
                    tNode = tNode.right;
                }
                else
                {
                    sb.AppendFormat("{0},", tNode.Key);                    
                    tNode = SearchUpTillNodeParentsLeftIsNode(tNode, out prevNode);                    
                }
            }

            Console.WriteLine(sb.ToString());
        }

        private Node<P> PrepareBSTFromArray(P[] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("arr");
            }

            Array.Sort(arr);
            return MakeBSTFromSortedArray(arr, 0, arr.Length - 1);
        }

        private Node<P> MakeBSTFromSortedArray(P[] arr, int stIdx, int endIdx)
        {
            if (stIdx > endIdx || stIdx < 0 || endIdx > arr.Length - 1)
            {
                return null;
            }

            int midIdx = (stIdx + endIdx) / 2;
            Node<P> N = new Node<P>(arr[midIdx]);
            N.left = MakeBSTFromSortedArray(arr, stIdx, midIdx - 1);
            if (N.left != null)
            {
                N.left.parent = N;
            }

            N.right = MakeBSTFromSortedArray(arr, midIdx + 1, endIdx);
            if (N.right != null)
            {
                N.right.parent = N;
            }

            return N;
        }

        private Node<P> SearchUpTillNodeParentsLeftIsNode(Node<P> tNode, out Node<P> prevNode)
        {
            Node<P> parent = null;
            while (tNode != null)
            {
                parent = tNode.parent;
                
                if (parent == null || parent.left == tNode)
                {
                    break;
                }
                else
                {
                    tNode = tNode.parent;
                }
            }

            prevNode = tNode;
            return parent;
        }

        public void PrintPreOrder(Node<P> root)
        {
        }

        public void PrintPostOrder(Node<P> root)
        {
        }

        public Node<P> FindMinimum(Node<P> root)
        {
            return null;
        }

        public Node<P> FindMaximum(Node<P> root)
        {
            return null;
        }

        public Node<P> GetSuccessor(P data)
        {
            return null;
        }

        public Node<P> GetPredecessor(P data)
        {
            return null;
        }


    }
}
