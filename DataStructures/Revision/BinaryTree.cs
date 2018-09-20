
namespace DataStructures.Revision
{
    using System;

    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public Node<T> Parent { get; set; }

        public Node(T data)
        {
            this.Data = data;
        }
    }

    public class BinaryTree<T> where T : IComparable<T>
    {
        public Node<T> Root { get; private set; }

        public BinaryTree(Node<T> n)
        {
            this.Root = n;
        }

        public virtual bool Insert(T data)
        {
            var newNode = new Node<T>(data);
            return Insert(newNode, this.Root);
        }

        public virtual bool Insert(Node<T> newNode, Node<T> root)
        {
            if (root == null)
            {
                root = newNode;
                return true;
            }

            //if node.left is null => insert to node.Left
            //else if node.right is null => insert to node right
            //else get hight of node.Left and node.Right => if left has less or equal  nodes. go to left or go to right
            var N = this.Root;
            while (N.Left != null && N.Right != null)
            {
                var L = GetHeight(N.Left);
                var R = GetHeight(N.Right);
                N = L <= R ? N.Left : N.Right;
            }

            if (N.Left == null)
            {
                N.Left = newNode;
                newNode.Parent = N;
            }
            else if (N.Right == null)
            {
                N.Right = newNode;
                newNode.Parent = N;
            }

            return true;
        }

        public virtual Node<T> Delete(T value)
        {
            var N = Search(value, this.Root);
            if (N != null)
            {
                var P = N.Parent;
                // case 1. N has no child => N.Parent.Left or right set to null
                if (N.Left == null && N.Right == null)
                {
                    if (P.Left == N)
                        P.Left = null;
                    else
                        P.Right = null;
                }
                // case 2. N has one child
                else if (N.Left == null || N.Right == null)
                {
                    var next = (N.Left == null) ? N.Right : N.Left;
                    Transplant(N, next);
                }
                else
                {
                    // case 3. N has both child
                }
            }

            return N;
        }

        private void Transplant(Node<T> n, Node<T> next)
        {
            if (n.Parent.Left == n)
                n.Parent.Left = next;
            else
                n.Parent.Right = next;

            next.Parent = n.Parent;

            //Insert()
        }

        public virtual Node<T> Search(T value, Node<T> root)
        {
            return null;
        }

        public int GetHeight(Node<T> node)
        {
            if(node == null)
            {
                return 0;
            }

            return 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
        }
    }

    public class BinarySearchTree<M> : BinaryTree<M> where M : IComparable<M>
    {
        public BinarySearchTree(M rootData):base(new Node<M>(rootData))
        { }

        public void Insert(ref Node<M> root, Node<M> newNode)
        {
            newNode.Parent = null;
            if (root == null)
            {
                root = newNode;
                return;
            }

            if(newNode.Data.CompareTo(root.Data) < 0)
            {
                Insert(root.Left, newNode);
                if (newNode.Parent == null)
                    newNode.Parent = root;
            }
            else
            {
                Insert(root.Left, newNode);
                if (newNode.Parent == null)
                    newNode.Parent = root;
            }
        }

        public override Node<M> Search(M value, Node<M> root)
        {
            return base.Search(value, root);
        }
    }

    public class BinaryTreeUtil
    {
        public bool HasRootToLeafPathWithGivenSum(Node<int> root, int sum)
        {
            if (root == null)
                return false;

            if (root.IsLeaf() && root.Data == sum)
                return true;
            else
                return HasRootToLeafPathWithGivenSum(root.Left, sum - root.Data) ||
                    HasRootToLeafPathWithGivenSum(root.Right, sum - root.Data);
        }

        public bool PrintRootToLeafPathWithGivenSum(Node<int> root, int sum, MyGenLinkedList<int> output)
        {
            if (root == null)
                return false;

            if (output == null)
                output = new MyGenLinkedList<int>(root.Data);
            else
                output.InsertLast(root.Data);

            if (root.IsLeaf() && root.Data == sum)
            {
                output.PrintList();
                output.DeleteLast();
                return true;
            }
            else
            {
                var l = PrintRootToLeafPathWithGivenSum(root.Left, sum - root.Data, output);
                var r = PrintRootToLeafPathWithGivenSum(root.Right, sum - root.Data, output);
                output.DeleteLast();

                return l || r;
            }
        }
        
    }

    public static class MyExtensions
    {
        public static bool IsLeaf(this Node<int> node)
        {
            return node.Left == null && node.Right == null;
        }
    }

}
