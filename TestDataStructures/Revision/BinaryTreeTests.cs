using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStructures.Revision;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
namespace TestDataStructures.Revision
{
    [TestClass]
    public class BinaryTreeTests
    {
        public Node<int> root;

        [TestInitialize]
        public void Setup()
        {
            root = new Node<int>(314);
            root.Left = new Node<int>(6);
            root.Right = new Node<int>(6);

            root.Left.Left = new Node<int>(271);
            root.Left.Right = new Node<int>(561);
            root.Left.Left.Left = new Node<int>(28);
            root.Left.Left.Right = new Node<int>(0);
            root.Left.Right.Right = new Node<int>(3);
            root.Left.Right.Right.Left = new Node<int>(17);

            root.Right.Left = new Node<int>(2);
            root.Right.Left.Right = new Node<int>(1);
            root.Right.Left.Right.Left = new Node<int>(401);
            root.Right.Left.Right.Left.Right = new Node<int>(641);
            root.Right.Left.Right.Right = new Node<int>(268);

            root.Right.Right = new Node<int>(271);
            root.Right.Right.Right = new Node<int>(28);
        }

        [TestMethod]
        public void Test_HasRootToLeafPathWithGivenSum()
        {
            BinaryTreeUtil binaryTreeUtil = new BinaryTreeUtil();
            DataStructures.MyGenLinkedList<int> o = null;
            var hasPath = binaryTreeUtil.HasRootToLeafPathWithGivenSum(root, 591);

            Assert.IsTrue(hasPath, "314, 6, 271, 0");


        }
        [TestMethod]
        public void Test_PrintRootToLeafPathWithGivenSum()
        {
            BinaryTreeUtil binaryTreeUtil = new BinaryTreeUtil();
            DataStructures.MyGenLinkedList<int> o = null;
            var hasPath = binaryTreeUtil.PrintRootToLeafPathWithGivenSum(root, 591, o);

            Assert.IsTrue(hasPath, "314, 6, 271, 0");


        }

        [TestMethod]
        public void Test_PrintRootToLeafPathWithGivenSum_NoPath()
        {
            BinaryTreeUtil binaryTreeUtil = new BinaryTreeUtil();
            DataStructures.MyGenLinkedList<int> o = null;
            var hasPath = binaryTreeUtil.PrintRootToLeafPathWithGivenSum(root, 598, o);

            //Assert.IsTrue(hasPath, "314, 6, 271, 0");


        }

        //[TestMethod]
        //public void TestBSTDeletion()
        //{
        //    BST binaryTree = new BST();
        //    binaryTree.CreateTree(4);
        //    int[] arr = new int[] { 2, 5, 1, 3, 7, 6, 9};

        //    foreach (int i in arr)
        //    {
        //        binaryTree.InsertNode(i);
        //    }


        //    //Dictionary<int, Stack<int>> d = new Dictionary<int,Stack<int>>();
        //    //Hashtable ht = new Hashtable();
        //    //ht.co

        //    binaryTree.PrintTree();

        //    binaryTree.DeleteNode(4);

        //    binaryTree.DeleteNode(1);
        //    binaryTree.DeleteNode(5);
        //    binaryTree.DeleteNode(7);
        //}
    }
}
