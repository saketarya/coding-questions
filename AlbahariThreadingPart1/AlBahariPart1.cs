using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlbahariThreadingPart1
{
    public class ThreadsShareInstanceVaraibles
    {
        static bool done;
        private readonly object locker = new object();
        int count = 0;

        public void CallMeFromMainThread()
        {
            // create an instance
            ThreadsShareInstanceVaraibles tt = new ThreadsShareInstanceVaraibles();
            Task t = new Task(tt.ThreadSafeGo);
            t.Start();
            tt.ThreadSafeGo();
        }

        public void UsingThreadJoin()
        {
            // create an instance
            ThreadsShareInstanceVaraibles tt = new ThreadsShareInstanceVaraibles();
            Task t = new Task(tt.ThreadUnsafeGo);
            t.Start();
            t.Wait(); // waits till t completes. That will have "done" set to true
            tt.ThreadUnsafeGo();
        }

        public void WhatIfForgroundThreadEndsBeforeBackgroundThread()
        {
            // create an instance
            ThreadsShareInstanceVaraibles tt = new ThreadsShareInstanceVaraibles();
            Task t = Task.Factory.StartNew(tt.ThreadUnsafeGo)
                .ContinueWith((x) => Console.WriteLine("hello!"));
            
            t.Wait(); // waits till t completes. That will have "done" set to true
            tt.ThreadUnsafeGo();
            
            Task t2 = Task.Factory.StartNew(() => {
                Thread.Sleep(10);
                Console.WriteLine("Tata !!");
            });

            //It may not print "Tata!!" is you do not wait for thread t2.
        }

        public async Task WhatIfYouModifySharedDataWhileThreadExecuting()
        {
            List<Task> taskList = new List<Task>();
            for (int i=0; i< 10; i++)
            {
                //// If you await each thread, values are printed correctly
                await Task.Factory.StartNew(() => Console.WriteLine(i));

                //// Using tasklist or trapping i into local var give inconsistent output 
                //int temp = i;
                //taskList.Add(Task.Factory.StartNew(() => Console.WriteLine(i)));
            }

            Task.WaitAll(taskList.ToArray());
            //It may not print "Tata!!" is you do not wait for thread t2.
        }

        public void PassDataBetweenThreads()
        {
            string result = null;
            var t = Task.Run(() => result = $"Task {Thread.CurrentThread.ManagedThreadId} completed.")
                .ContinueWith((x) => result += $"Task {Thread.CurrentThread.ManagedThreadId} completed.");

            t.Wait();
        }

        private void ThreadUnsafeGo()
        {
            if (!done)
            {
                Console.WriteLine($"Done = {++count}");
                //Thread.Sleep(1);
                done = true;
            }
        }

        private void ThreadSafeGo()
        {
            lock (locker)
            {
                if (!done)
                {
                    Console.WriteLine($"Done = {++count}");
                    //Thread.Sleep(1);
                    done = true;
                }
            }
        }
    }
}
