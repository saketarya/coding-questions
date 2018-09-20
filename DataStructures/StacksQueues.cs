using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures
{
    public class StacksQueues
    {
        public void TowerOfHanoi()
        {
            Stack<int> A = new Stack<int>();
            Stack<int> B = new Stack<int>();
            Stack<int> C = new Stack<int>();

            A.Push(3);
            A.Push(2);
            A.Push(1);

            Move(3, A, B, C);

            
        }

        public void Move(int n, Stack<int> from, Stack<int> use, Stack<int> to)
        {
            if(n>0)
            {
                Move(n - 1, from, to, use);
                to.Push(from.Pop());
                Move(n - 1, use, from, to);
            }
        }

        public void SortingStackUsingAnotherStack()
        {
            Stack<int> source = new Stack<int>(10);
            
            Random r = new Random(1);
            for(int i =0; i<10; i++)
            {
                source.Push(r.Next(20));
            }

            // print original
            PrintStack(source);

            // sort the stack
            source = SortStack(source);

            // print sorted
            PrintStack(source);
        }

        private Stack<int> SortStack(Stack<int> source)
        {
            if (source.Count == 0)
            {
                return source;
            }

            Stack<int> buffer = new Stack<int>();
            int temp = 0;
            while (source.Count > 0)
            {
                // check and copy to buffer
                temp = source.Pop();
                // find the place for temp such that the one below it has higher value
                while (buffer.Count > 0 && buffer.Peek() < temp)
                {
                    source.Push(buffer.Pop());
                }

                buffer.Push(temp);
            }

            return buffer;
        }

        private void PrintStack(Stack<int> source)
        {
            if (source.Count == 0)
            {
                Console.WriteLine("Empty stack");
                return;
            }

            StringBuilder sb = new StringBuilder();
            while (source.Count > 0)
            {
                sb.Append(source.Pop());
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
