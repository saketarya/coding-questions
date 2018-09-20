using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
namespace TestDataStructures
{
    [TestClass]
    public class TestTrees
    {
        [TestMethod]
        public void TestBSTInsertion()
        {
            BST binaryTree = new BST();
            binaryTree.CreateTree(10);

            // Root should be 10
            Assert.AreEqual<int>(10, binaryTree.Root.Value);
            // Insert 10;            
            binaryTree.InsertNode(10);

            // Insert 20;
            binaryTree.InsertNode(20);
            // Insert 5;
            binaryTree.InsertNode(5);

            // Search
            TreeNode<int> searched = binaryTree.Search(10);
            Assert.AreEqual<TreeNode<int>>(searched, binaryTree.Root);

            binaryTree = new BST();
            for (int i = 1; i < 11; i++)
            {
                binaryTree.InsertNode(i);
            }

            Console.WriteLine(binaryTree.Root.Value);
        }

        [TestMethod]
        public void TestBSTDeletion()
        {
            BST binaryTree = new BST();
            binaryTree.CreateTree(4);
            int[] arr = new int[] { 2, 5, 1, 3, 7, 6, 9};

            foreach (int i in arr)
            {
                binaryTree.InsertNode(i);
            }

            
            //Dictionary<int, Stack<int>> d = new Dictionary<int,Stack<int>>();
            //Hashtable ht = new Hashtable();
            //ht.co

            binaryTree.PrintTree();

            binaryTree.DeleteNode(4);

            binaryTree.DeleteNode(1);
            binaryTree.DeleteNode(5);
            binaryTree.DeleteNode(7);
        }
    }
}
