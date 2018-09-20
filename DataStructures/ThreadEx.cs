using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DataStructures
{
    public class IntBuffer
    {
        private int index;        
        private readonly int LEN;
        private int[] buffer;

        public IntBuffer(int len)
        {
            buffer = new int[len];
            LEN = len;
        }

        public void Add(int num)
        {
            lock (buffer)
            {
                if (index < LEN)
                {
                    buffer[index++] = num;
                    Console.WriteLine("Pushed = {0}, index = {1}", num, index);
                }
            }
        }

        public void Remove()
        {
            lock (buffer)
            {
                if (index > 0)
                {
                    Console.WriteLine("Popped = {0}, index = {1}", buffer[--index], index);
                    //index = index == 0 ? index : index-1;
                }
            }
        }
    }

    public class Producer
    {
        private IntBuffer intBuffer;

        public Producer(IntBuffer buffer)
        {
            this.intBuffer = buffer;
        }

        public void Run()
        {
            Random r = new Random(0);
            while (true)
            {
                this.intBuffer.Add(r.Next(0,3));
            }
        }
    }

    public class Consumer
    {
        private IntBuffer intBuffer;

        public Consumer(IntBuffer buffer)
        {
            this.intBuffer = buffer;
        }

        public void Run()
        {            
            while (true)
            {
                this.intBuffer.Remove();
            }
        }
    }
}
