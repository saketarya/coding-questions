using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;
using System.Diagnostics;

namespace TestDataStructures
{
    [TestClass]
    public class TestFibonacci
    {
        public delegate long FibDel(uint n);
        [TestMethod]
        public void TestFibIttv()
        {
            Arithmatics arith = new Arithmatics();
            this.TestFib(arith.GetFibonacci_Ittv2);
            this.TestFib(arith.GetFibonacci_Ittv);
            this.TestFib(arith.GetFibonacci_Rcrsv);

            Stopwatch watch = new Stopwatch();
            watch.Start();
            long f = arith.GetFibonacci_Ittv(20);
            watch.Stop();
            Console.WriteLine("Ittv(50) takes {0} ms.", watch.ElapsedTicks);

            watch.Reset();
            watch.Start();
            f = arith.GetFibonacci_Rcrsv(20);
            watch.Stop();
            Console.WriteLine("Rcrsv(50) takes {0} ms.", watch.ElapsedTicks);

        }

        public void TestFib(FibDel del)
        {
           

            try
            {
                // test for 0
                Console.WriteLine(del(0));
            }
            catch (ArgumentException Ex)
            {
                Assert.AreEqual(Ex.Message, "no elements", true);
            }            

            // test for -ve -- can't its a UINT
            // test for 1
            Assert.AreEqual(del(1), 1);
            // test for 2
            Assert.AreEqual(del(2), 1);
            // test for > 2
            Assert.AreEqual(del(3), 2);
            Assert.AreEqual(del(4), 3);
            Assert.AreEqual(del(8), 21);
        }
        
    }
}
