using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;

namespace DataStructures
{
    public class TreeNode<T> 
    {
        public TreeNode<T> Left;
        public TreeNode<T> Right;
        public T Value { get; set; }

        public TreeNode(T val)
        {
            this.Value = val;
        }
    }

    public class BST
    {
        // Root node
        public TreeNode<int> Root;

        public void CreateTree(int val)
        {
            Root = null;
            //this.InsertNode_Rcrsv(ref Root, new TreeNode<int>(val));
            this.InsertNode_Ittv(ref Root, new TreeNode<int>(val));
        }

        public void InsertNode(int val)
        {
            TreeNode<int> newNode = new TreeNode<int>(val);
            this.InsertNode_Rcrsv(ref Root, newNode);
            //this.InsertNode_Ittv(ref Root, newNode);
        }

        public TreeNode<int> Search(int val)
        {            
            return this.Search(Root, val);
        }

        private TreeNode<int> Search(TreeNode<int> tree, int val)
        {
            if (tree == null)
                return null;

            if (val < tree.Value)
            {
                return Search(tree.Left, val);
            }
            else if (val > tree.Value)
            {
                return Search(tree.Right, val);
            }
            else
                return tree;
        }

        // Insert Node recersively.. returns root node
        private void InsertNode_Rcrsv(ref TreeNode<int> tree, TreeNode<int> newNode)
        {            
            if (tree == null)
            {
                tree = newNode;
                return;
            }

            // do not allow dupes

            if (tree.Value == newNode.Value)
            {
                return;
            }
            // other wise find the position for new node
            else if (newNode.Value < tree.Value)
            {
                InsertNode_Rcrsv(ref tree.Left, newNode);
            }
            else
            {
                InsertNode_Rcrsv(ref tree.Right, newNode);
            }
        }

        // Insert Node recersively.. returns root node
        private void InsertNode_Ittv(ref TreeNode<int> tree, TreeNode<int> newNode)
        {

            if (tree == null)
            {
                tree = newNode;
                return;
            }

            TreeNode<int> tempNode = tree;
            while (tempNode != null)
            {
                if (tempNode.Value == newNode.Value) // equal
                {
                    break;
                }
                else if (newNode.Value < tempNode.Value) // left
                {
                    if (tempNode.Left == null)
                    {
                        tempNode.Left = newNode;
                        break;
                    }

                    tempNode = tempNode.Left;
                }
                else //right
                {
                    if (tempNode.Right == null)
                    {
                        tempNode.Right = newNode;
                        break;
                    }

                    tempNode = tempNode.Right;
                }
            }
        }

        // Delete Node
        public void DeleteNode(int val)
        {
            if (Root == null)
            {
                // empty tree
                return;
            }

            // is it the root node you are trying to delete ?
            if (Root.Value == val)
            {
                // create an auxillary node, add root as Aux.Left and make Aux as Root.
                TreeNode<int> aux = new TreeNode<int>(0);
                aux.Left = Root;
                Root = aux;
                bool removed = Remove(aux.Left, val, aux);

                // now make the older root the real Root again.
                Root = aux.Left;
            }
            else
            {
                bool removed = Remove(Root, val, null);
            }
        }

        public void PrintInorder()
        {
            StringBuilder sb = new StringBuilder();
            this.PrintTreePostOrder(Root, sb);
            Console.WriteLine("post Order: {0}", sb.ToString());

            sb.Clear();
            this.PrintTreeInOrder(Root, sb);
            Console.WriteLine("In Order: {0}", sb.ToString());

            sb.Clear();
            this.PrintTreePreOrder(Root, sb);
            Console.WriteLine("Pre Order: {0}", sb.ToString());
        }

        private void PrintTreePostOrder(TreeNode<int> node, StringBuilder sb)
        {
            if (node == null)
                return;

            PrintTreePostOrder(node.Left, sb);
            PrintTreePostOrder(node.Right, sb);
            sb.Append(string.Format("{0}, ", node.Value));
            //Console.WriteLine(sb.ToString());
        }

        private void PrintTreeInOrder(TreeNode<int> node, StringBuilder sb)
        {
            if (node == null)
                return;

            PrintTreeInOrder(node.Left, sb);
            sb.Append(string.Format("{0}, ", node.Value));
            PrintTreeInOrder(node.Right, sb);
            
            //Console.WriteLine(sb.ToString());
        }

        private void PrintTreePreOrder(TreeNode<int> node, StringBuilder sb)
        {
            if (node == null)
                return;

            sb.Append(string.Format("{0}, ", node.Value));
            PrintTreePreOrder(node.Left, sb);            
            PrintTreePreOrder(node.Right, sb);

            //Console.WriteLine(sb.ToString());
        }


        public void PrintTree()
        {
            if (Root == null)
                throw new NullReferenceException("Empty tree");
            StringBuilder sb = new StringBuilder();
            this.Print(Root, sb);
        }

        private void Print(TreeNode<int> node, StringBuilder sb)
        {
            sb.Append(node.Value);
            if (node.Left == null && node.Right == null)
            {
                Console.WriteLine(sb.ToString());
                sb.Length = sb.Length - 1;
                return;
            }

            
            if (node.Left != null)
            {
                Print(node.Left, sb);                
            }

            if (node.Right != null)
            {
                Print(node.Right, sb);                
            }

        }

        private bool Remove(TreeNode<int> startNode, int val, TreeNode<int> parentNode)
        {
            bool result = false;
            // val < this.value
            if (val < startNode.Value)
            {
                if (startNode.Left != null)
                {
                    result = Remove(startNode.Left, val, startNode);
                }
                else
                {
                    return false;
                }
            }
            // val > this.value
            else if (val > startNode.Value)
            {
                result = Remove(startNode.Right, val, startNode);
            }
            // val == this.value
            else
            {
                // startNode both childs
                if (startNode.Left != null && startNode.Right != null)
                {
                    // find min of the right subtree of startNode.... assign it to startNode value
                    startNode.Value = MinVal(startNode.Right);

                    // now remove this value (startNode.Value) from Right subtree. (duplicate)
                    result = Remove(startNode.Right, startNode.Value, startNode);
                }
                // one childv - which one is it... Left or Right ?
                else if (parentNode.Left == startNode) // left
                {
                    parentNode.Left = (startNode.Left == null) ? startNode.Right : startNode.Left;
                    return true;
                }
                else if (parentNode.Right == startNode)
                {
                    parentNode.Right = (startNode.Left == null) ? startNode.Right : startNode.Left;
                    return true;
                }
                // no child

                return true;
            }

            return result;
        
        }

        /// <summary>
        /// left most value.
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        private int MinVal(TreeNode<int> start)
        {
            if (start.Left == null)
            {
                return start.Value;
            }

            return MinVal(start.Left);
        }

        public void PrintTree_PreOrder_Ittv(TreeNode<int> start)
        {
            if (start == null)
            {
                throw new ArgumentNullException("Root");
            }

            if (start.Left == null && start.Right == null)
            {
                Console.WriteLine(start.Value);
                return;
            }

            StringBuilder sb = new StringBuilder();
            //sb.Append(start.Value).Append(",");
            TreeNode<int> t = start;
            Stack<TreeNode<int>> buffer = new Stack<TreeNode<int>>();

            while (t != null)
            {
                sb.Append(t.Value).Append(",");
                if (t.Right != null)
                {
                    buffer.Push(t.Right);
                }

                if (t.Left != null)
                {
                    t = t.Left;
                }
                else if (buffer.Count > 0 && buffer.Peek() != null)
                {
                    t = buffer.Pop();
                }
                else
                {
                    t = null;
                }
            }

            Console.WriteLine(sb.ToString());
        }

        public void PrintTree_InOrder_Ittv(TreeNode<int> start)
        {
            TreeNode<int> lastleft = null;
            StringBuilder sb = new StringBuilder();
            TreeNode<int> N = start;
            Stack<TreeNode<int>> stack = new Stack<TreeNode<int>>();

            while (N != null)
            {
                if (N.Left != null && N.Left != lastleft)
                {
                    stack.Push(N);
                    N = N.Left;
                    lastleft = N;
                }
                else
                {
                    sb.Append(N.Value).Append(",");

                    // if lastLeft was = N.Left -> make LastLeft = N
                    //if (lastleft == N.Left)
                    //{
                    //    lastleft = N;
                    //}
                    
                    if (N.Right == null && stack.Count > 0)
                    {
                        N = stack.Pop();
                        lastleft = N.Left;
                    }
                    else
                    {
                        N = N.Right;
                    }                    
                }
            }

            Console.WriteLine(sb.ToString());
        }
        public void PrintTree_PostOrder_Ittv(TreeNode<int> start)
        {
            if (start == null)
            {
                throw new ArgumentNullException("Root");
            }

            TreeNode<int> t = start;
            TreeNode<int> prev = null;
            Stack<TreeNode<int>> S = new Stack<TreeNode<int>>();
            StringBuilder sb = new StringBuilder();
            while (t != null)
            {
                if ((t.Left == null && t.Right == null) || prev == t)
                {
                    sb.Append(t.Value).Append(",");
                    if (S.Count > 0)
                    {
                        TreeNode<int> X = S.Peek();
                        if (t == X.Left && X.Right != null)
                        {
                            t = X.Right;
                        }
                        else
                        {
                            prev = X;
                            t = S.Pop();
                        }
                    }
                    else
                    {
                        t = null;
                    }
                }
                else if (t.Left != null)
                {
                    S.Push(t);
                    t = t.Left;
                }
                else if (t.Right != null)
                {
                    S.Push(t);
                    t = t.Right;
                }
            }

            Console.WriteLine(sb.ToString());
        }

        public int Add(int a, int b)
        {
            return a + b;
        }
        // Search Node

        // DFS

        // BFS
    }

    //public Extensions TreeNodeExtension Extends TreeNode<T>
    //{
    //  // Property extensions coming in C# 8.0
    //  public bool Even => this%2 == 0;
    //  https://blog.ndepend.com/c-8-0-features-glimpse-future/
    //}

    public class BinaryTreeUtils
    {
        public List<int[]> PrintAllRootToLeafPathWithGivenSum(TreeNode<int> root, int targetSum)
        {
            var results = new List<int[]>();
            PrintAllRootToLeafPathWithSum(root, targetSum, new LinkedList<int>(), results);
            return results;
        }

        /// <summary>
        /// Prints all root to Leaf paths that have sum equal to a given Sum.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="targetSum"></param>
        /// <param name="path"></param>
        private void PrintAllRootToLeafPathWithSum(TreeNode<int> root, int targetSum, LinkedList<int> path, List<int[]> results)
        {
            if (root == null)
                return;

            path.AddLast(root.Value);
            var s = targetSum - root.Value;
            if(root.Left == null && root.Right == null)
            {
                if (s == 0)
                {
                    var output = path.ToArray();
                    results.Add(output);
                    Console.WriteLine(string.Join(",", path.ToArray()));
                }
            }
            else
            {
                PrintAllRootToLeafPathWithSum(root.Left, s, path, results);
                PrintAllRootToLeafPathWithSum(root.Right, s, path, results);
            }

            path.RemoveLast();
        }
    }
}
