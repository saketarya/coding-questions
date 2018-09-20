using System;
using DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace TestDataStructures
{
    [TestClass]
    public class TestSingleLinkedList
    {
        [TestMethod]
        public void PrintNullList()
        {
            try
            {
                MySingleLinkedList.PrintList(MySingleLinkedList.CreateList(4));
            }
            catch (NullReferenceException ex)
            {
                Assert.IsTrue(ex.Message.Equals("List is not initialized", StringComparison.InvariantCultureIgnoreCase), "failed test");
            }
        }

        [TestMethod]
        public void TestCreateList()
        {
            // For different Types - int, bool, string, object
            var ilist = SingleLinkedList<int>.CreateList(10);
            Assert.IsTrue(ilist.Head == ilist.Tail, "Head is not equal tail");

            var slist = SingleLinkedList<string>.CreateList("the");
            Assert.IsTrue(slist.Head == slist.Tail, "Head is not equal tail");

            var olist = SingleLinkedList<Student>.CreateList(new Student { Id = 1, Name ="John" });
            Assert.IsTrue(olist.Head == olist.Tail, "Head is not equal tail");
            Assert.IsTrue(olist.Head.Data.Id == 1, "Head is not poiting to the first node");


            // Create with null data
            var nlist = SingleLinkedList<Student>.CreateList(null);
            Assert.IsFalse(nlist.IsEmpty, "List should not be empty");
            Assert.IsTrue(nlist.Head.Data == null, "Head data should be null");
        }

        [TestMethod]
        public void TestInsertFirst()
        {
            var ilist = SingleLinkedList<int>.CreateList(10);
            ilist.InsertFirst(5);

            ilist.Print();

            Assert.IsTrue(ilist.Head.Data == 5, "5 should be head");
            Assert.IsTrue(ilist.Tail.Data == 10, "10 should be tail");

            // list with null Data object
            var nlist = SingleLinkedList<Student>.CreateList(null);
            nlist.InsertFirst(new Student { Id = 1, Name = "Bewda" });
            nlist.Print();
            Assert.IsTrue(nlist.Head.Data.Id==1, "Head id should be 1");
            Assert.IsTrue(nlist.Tail.Data == null, "Tail data should be null");

            

        }

        [TestMethod]
        public void TestInsertAfter()
        {
            var ilist = SingleLinkedList<int>.CreateList(1);
            ilist.InsertLast(4);
            ilist.Print();

            ilist.InsertAfter(4, 6);
            ilist.Print();

            ilist.InsertAfter(4, 5);
            ilist.Print();

            ilist.InsertAfter(1, 2);
            ilist.Print();

            ilist.InsertAfter(2, 3);
            ilist.Print();
            try
            {
                ilist.InsertAfter(0, -1);
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message == "Failed to find node to insert after.");
            }

            try
            {
                var lst = SingleLinkedList<string>.CreateList("the");
                var node = lst.DeleteFirst();
                Assert.IsTrue(node.Data == "the", "Deleted '{0}'. Expected = '{1}'", node.Data, "the");
                lst.InsertAfter("quick", "brown");
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message == "List is empty", "some other error encountered");
            }
        }

        [TestMethod]
        public void TestInsertBefore()
        {
            var ilist = SingleLinkedList<int>.CreateList(3);
            ilist.InsertLast(5);
            ilist.Print();

            ilist.InsertBefore(3, 1);
            ilist.Print();

            ilist.InsertBefore(5, 4);
            ilist.Print();

            ilist.InsertBefore(3, 2);
            ilist.Print();
            try
            {
                ilist.InsertBefore(0, -1);
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message == "Failed to find node to insert before.");
            }

            try
            {
                var lst = SingleLinkedList<string>.CreateList("the");
                var node = lst.DeleteFirst();
                Assert.IsTrue(node.Data == "the", "Deleted '{0}'. Expected = '{1}'", node.Data, "the");
                lst.InsertBefore("brown", "quick");
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message == "List is empty", "some other error encountered");
            }
        }

        [TestMethod]
        public void TestInsert()
        {
        }

        [TestMethod]
        public void TestDelete()
        {
            // Delete empty
            var lst = SingleLinkedList<string>.CreateList("the");
            lst.Print();
            lst.Delete("the");
            lst.Print();
            try
            {                
                lst.Delete("the");
            }
            catch(ArgumentException ex)
            {
                Assert.IsTrue(ex.Message == "List is empty", "some other error encountered");
            }

            if (lst.IsEmpty)
            {
                lst = SingleLinkedList<string>.CreateList("the");
            }
            else
            {
                lst.InsertLast("the");
            }

            lst.InsertLast("quick");
            lst.InsertLast("brown");
            lst.InsertLast("fox");
            lst.InsertLast("jumped");
            lst.InsertLast("over");
            lst.InsertLast("the");
            lst.InsertLast("lazy");
            lst.InsertLast("dog");
            lst.Print();

            // delete head 
            var node = lst.Delete("the");            
            lst.Print();
            Assert.IsTrue(
                node != null 
                && node.Data.Equals("the") 
                && node.Next.Data.Equals("quick"),
                "Wrong node deleted");

            // delete last 
            node = lst.Delete("dog");
            lst.Print();
            Assert.IsTrue(
                node != null
                && node.Data.Equals("dog")
                && node.Next == null,
                "Wrong node deleted");

            // delete a specific node in mid
            node = lst.Delete("jumped");
            lst.Print();
            Assert.IsTrue(
                node != null
                && node.Data.Equals("jumped")
                && node.Next.Data.Equals("over"),
                "Wrong node deleted");

            //delete non-existing node
            node = lst.Delete("cat");
            lst.Print();
            Assert.IsTrue(node == null, "Wrong node deleted");
        }

        [TestMethod]
        public void TestDeleteFirst()
        {
            var lst = SingleLinkedList<string>.CreateList("the");            
            lst.InsertLast("quick");
            lst.InsertLast("brown");
            lst.InsertLast("fox");
            lst.InsertLast("jumped");
            lst.InsertLast("over");
            lst.InsertLast("the");
            lst.InsertLast("lazy");
            lst.InsertLast("dog");
            lst.Print();

            while(lst.Head != null)
            {
                lst.DeleteFirst();
                lst.Print();
            }

            Assert.IsTrue(lst.IsEmpty, "List should be empty now");
            try
            {
                var node = lst.DeleteFirst();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Equals("List is empty"), "Error in delete first for empty list");
            }
        }

        [TestMethod]
        public void TestDeleteLast()
        {
            var lst = SingleLinkedList<string>.CreateList("the");
            lst.InsertLast("quick");
            lst.InsertLast("brown");
            lst.InsertLast("fox");
            lst.InsertLast("jumped");
            lst.InsertLast("over");
            lst.InsertLast("the");
            lst.InsertLast("lazy");
            lst.InsertLast("dog");
            lst.Print();

            while (lst.Head != null)
            {
                lst.DeleteLast();
                lst.Print();
            }

            Assert.IsTrue(lst.IsEmpty, "List should be empty now");
            try
            {
                var node = lst.DeleteLast();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Equals("List is empty."), "Error in delete first for empty list");
            }
        }

    }
}
