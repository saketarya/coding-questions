using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlbahariThreadingPart1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleLinkedListProblems.Tests
{
    [TestClass()]
    public class AlbahariThreadingPart1Tests
    {
        [TestMethod()]
        public void CalledFromMainThreadTest()
        {
            ThreadsShareInstanceVaraibles t = new ThreadsShareInstanceVaraibles();
            t.CallMeFromMainThread();
        }

        /// <summary>
        /// You can wait for another thread to end by using thread's Join method.
        /// </summary>
        [TestMethod()]
        public void ThreadJoinTest()
        {
            ThreadsShareInstanceVaraibles t = new ThreadsShareInstanceVaraibles();
            t.UsingThreadJoin();
        }

        [TestMethod()]
        public void NoThreadWaitCanDieInTheMiddle_SinceMainThreadExit()
        {
            ThreadsShareInstanceVaraibles t = new ThreadsShareInstanceVaraibles();
            t.WhatIfForgroundThreadEndsBeforeBackgroundThread();
        }

        [TestMethod()]
        public void Test_ShareDataBetweenThread()
        {
            ThreadsShareInstanceVaraibles t = new ThreadsShareInstanceVaraibles();
            t.WhatIfForgroundThreadEndsBeforeBackgroundThread();
        }

        [TestMethod()]
        public async Task Test_ModifySharedDataWhileThreadExecuting()
        {
            ThreadsShareInstanceVaraibles t = new ThreadsShareInstanceVaraibles();
            for (int i = -10; i < 0; i++)
                await t.WhatIfYouModifySharedDataWhileThreadExecuting();
            //List<Task> taskList = new List<Task>();
            //for (int i = -10; i < 0; i++)
            //{
            //    taskList.Add(Task.Factory.StartNew(() => Console.WriteLine(i)));
            //}

            //Task.WaitAll(taskList.ToArray());
        }
    }
}