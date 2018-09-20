using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProgrammingProblems
{
    public class Node
    {
        public int Value { get; private set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int v)
        {
            this.Value = v;
        }
    }


    public class Trees
    {
        /**   
    Print a binary tree in zig-zag fashion i.e. 
    level order traversal but alternate left to right and right to left

        1
     2    3
    4 5  6 7
            **/

        public static void Run()
        {
            Node two = new Node(2){Left = new Node(4), Right=new Node(5)};
            Node three = new Node(3){Left = new Node(6), Right=new Node(7)};

            Node root = new Node(1) { Left = two, Right = three};

            Trees trees = new Trees();
            trees.PrintNodesZigZag(root);

        }

        public void PrintNodesZigZag(Node root)
        {
            if (root == null)
                return;

            if (root.Left == null && root.Right == null)
            {
                Console.WriteLine(root.Value);
                return;

            }

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            queue.Enqueue(null);
            Print(queue, 0);

        }

        private void Print(Queue<Node> queue, int level)
        {
            List<int> localBuffer = new List<int>();
            Node tempNode = null;
            while (queue.Count > 0)
            {
                // dequeue node
                tempNode = queue.Dequeue();

                // if current node is NullToken => print buffer based on current level
                if (tempNode == null)
                {
                    //var output = localbuffer.ToString();
                    if (level % 2 != 0)
                        localBuffer.Reverse(); // 2,3,4

                    Console.WriteLine(string.Join(" ", localBuffer)); // "2 3 4"
                    localBuffer.Clear();

                    // increment level
                    level++;

                    if (queue.Count > 0)
                        queue.Enqueue(null);
                }

                // store nodes in buffer based in current level
                else
                {
                    localBuffer.Add(tempNode.Value);
                    if (tempNode.Left != null)
                        queue.Enqueue(tempNode.Left);
                    if (tempNode.Right != null)
                        queue.Enqueue(tempNode.Right);
                }
            }
        }

    }
}
