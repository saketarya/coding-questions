using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures
{
    public interface IGraph<T> where T:IComparable
    {
        void AddVertex(T data);
        void AddEdge(T start, T end);

        int VertexCount { get; }

        IEnumerable<T> Vertices { get; }

        void PrintDFS();
        void PrintBFS();
        void PrintTopologicalSortSequence(T start);
        void PrintAllTopologicalSortSequences();


    }

    public class Graph<U> : IGraph<U> where U : IComparable
    {
        private Dictionary<U, HashSet<U>> map;

        public Graph()
        {
            map = new Dictionary<U, HashSet<U>>();
        }

        public int VertexCount => this.map.Keys.Count;

        public IEnumerable<U> Vertices => this.map.Keys.ToList<U>();

        public void AddEdge(U start, U end)
        {
            this.AddVertex(start);
            this.AddVertex(end);

            this.map[start].Add(end);
        }

        public void AddVertex(U data)
        {
            if (!this.map.ContainsKey(data))
                this.map.Add(data, new HashSet<U>());
        }

        public void PrintDFS()
        {
            var allVertices = this.Vertices;
            var visited = new HashSet<U>();
            var output = new LinkedList<U>();
            foreach (var v in allVertices)
            {
                if(!visited.Contains(v))
                    DFS(v, visited, output);
            }

            var h = output.First;
            while(h != null)
            {
                Console.Write($"{h.Value}, ");
                h = h.Next;
            }
        }

        private void DFS(U v, HashSet<U> visited, LinkedList<U> output)
        {
            visited.Add(v);
            output.AddLast(v);

            foreach (var x in map[v])
            {
                if (!visited.Contains(x))
                    DFS(x, visited, output);
            }
        }

        public void PrintBFS()
        {
            var allVertices = this.Vertices;
            var visited = new HashSet<U>();
            var Q = new Queue<U>();
            var output = new LinkedList<U>();
            foreach (var v in allVertices)
            {
                if (!visited.Contains(v))
                {
                    visited.Add(v);
                    Q.Enqueue(v);
                    
                    BFS(visited, Q, output);
                }
            }

            var h = output.First;
            while (h != null)
            {
                Console.Write($"{h.Value}, ");
                h = h.Next;
            }
        }

        private void BFS(HashSet<U> visited, Queue<U> Q, LinkedList<U> output)
        {
            while(Q.Count > 0)
            {
                var v = Q.Dequeue();
                output.AddLast(v);
                foreach(var x in this.map[v])
                {
                    if(!visited.Contains(x))
                    {
                        visited.Add(x);
                        Q.Enqueue(x);
                    }
                }
            }
        }

        public void PrintTopologicalSortSequence(U start)
        {
            Stack<U> stack = new Stack<U>();
            HashSet<U> visited = new HashSet<U>();
            var allVertices = this.Vertices;
            //var sortedKVs = this.map.OrderByDescending((kv) => kv.Value.Count).ToList();
            if(allVertices.Contains(start))
                TopologicalSort(start, stack, visited);

            foreach (var v in allVertices)
            {
                TopologicalSort(v, stack, visited);
            }

            while(stack.Count > 0)
            {
                Console.Write($"{stack.Pop()}, ");
            }
        }

        private void TopologicalSort(U v, Stack<U> stack, HashSet<U> visited)
        {
            if (visited.Contains(v))
                return;
            /**
             * mark v to visited 
             * foreach neighbor x of v => if x is not visited, TopologicalSort(x)
             * once processed all neighbors of v, push v to stack
             * */
            visited.Add(v);
            foreach(var x in this.map[v])
            {
                if(!visited.Contains(x))
                    TopologicalSort(x, stack, visited);
            }
            stack.Push(v);
        }

        public void PrintAllTopologicalSortSequences()
        {
            var allVertices = this.Vertices;
            var permutationsOfVertices = GetAllPermutationsOfVertices();

            HashSet<string> lookup = new HashSet<string>();
            HashSet<U> visited = new HashSet<U>();
            Stack<U> stack = new Stack<U>();

            foreach (var order in permutationsOfVertices)
            {
                visited.Clear();

                foreach (var v in order)
                {
                    TopologicalSort(v, stack, visited);
                }

                var sortedSequence = new U[allVertices.Count()];
                int index = 0;
                while (stack.Count > 0)
                {
                    sortedSequence[index++] = stack.Pop();
                }

                var seq = string.Join(",", sortedSequence);
                if (!lookup.Contains(seq))
                    lookup.Add(seq);
            }

            foreach(var s in lookup)
            {
                Console.WriteLine(string.Join(",", s));
            }
        }

        public List<U[]> GetAllPermutationsOfVertices()
        {
            var allVertices = this.Vertices.ToArray();
            List<U[]> results = new List<U[]>();
            LinkedList<U> sb = new LinkedList<U>();
            bool[] inUse = new bool[allVertices.Length];

            GetPermutations(allVertices, inUse, sb, results);

            return results;
        }

        private void GetPermutations(U[] allVertices, bool[] inUse, LinkedList<U> sb, List<U[]> results)
        {
            if(sb.Count == allVertices.Count())
            {
                var output = sb.ToArray();
                results.Add(output);
                return;
            }

            for(int i=0; i< allVertices.Count(); i++)
            {
                if (inUse[i])
                    continue;

                inUse[i] = true;
                sb.AddLast(allVertices[i]);

                GetPermutations(allVertices, inUse, sb, results);

                inUse[i] = false;
                sb.RemoveLast();
            }
        }

        //public void KahnsTopologicalSort()
        //{
        //    Dictionary<U, int> inIndex = new Dictionary<U, int>();
        //    // step1: find incoming index per vertex

        //    foreach(var adj in this.map.Values)
        //    {
        //        foreach(var h in adj) //adj is a HashSet
        //        {
        //            if(!inIndex.ContainsKey(h))
        //                inIndex
        //        }
        //    }
        //}
    }
}
