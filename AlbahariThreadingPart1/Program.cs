using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlbahariThreadingPart1
{
    class Program
    {
        static void Main(string[] args)
        {
            //BackgroundForegroundThreads(args);
            //BackgroundForegroundTasks(args);
            //AbandonTaskWithExceptionKillsMainThread();
            RunTaskCheckStatus();
        }

        private static void BackgroundForegroundThreads(string[] args)
        {
            Thread worker = new Thread(() =>
            {
                Console.WriteLine("Type something");
                Console.ReadLine();
            });

            if (args.Length > 0)
                worker.IsBackground = true;
            else
                Console.WriteLine("No Args. Should wait even when the Main thread exits.");
            worker.Start();
        }

        private static void BackgroundForegroundTasks(string[] args)
        {
            Task t;
            if (args.Length > 0)
            {
                t = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Type something");
                    Console.ReadLine();
                });
            }
            else
            {
                Console.WriteLine("No Args. Should wait even when the Main thread exits.");
                t = Task.Run(() =>
                {
                    Console.WriteLine("Type something");
                    Console.ReadLine();
                });
            }
            
            // Wait() will ensure that the thread t (background or foreground, exits gracefully on completion.
            t.Wait();
        }

        private static void AbandonTaskWithExceptionKillsMainThread()
        {
            RunTaskWithException();
            Thread.Sleep(10);
            Console.WriteLine("How did you reach here? Task with exception should have killed you!");
        }

        private static void RunTaskWithException()
        {
            Task.Run(() => {
                Thread.Sleep(100);
                throw new ArgumentException("Test exception");
            }).Wait();

        }

        private static void RunTaskCheckStatus()
        {
            Task t = new Task(() => {
                Thread.Sleep(50);
                Console.WriteLine("Test 1");
                Thread.Sleep(50);
                Console.WriteLine("Test 2");
                Thread.Sleep(50);
                Console.WriteLine("Test 3");
                Thread.Sleep(50);
                Console.WriteLine("Test 4");
                Thread.Sleep(50);
                Console.WriteLine("Test 5");
            });

            Task probe = Task.Factory.StartNew(() =>
            {
                //Thread.Sleep(10);
                while (true)
                {
                    Thread.Sleep(1);
                    Console.WriteLine(t.Status);
                }
            });

            //probe.Start();
            t.Start();
            t.Wait();
        }
    }
}
