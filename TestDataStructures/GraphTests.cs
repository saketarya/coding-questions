using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;

namespace TestDataStructures
{
    [TestClass]
    public class GraphTests
    {
        public IGraph<char> graph;

        [TestInitialize]
        public void Setup()
        {
            graph = new Graph<char>();

            graph.AddVertex('A');
            graph.AddVertex('B');
            graph.AddVertex('C');
            graph.AddVertex('D');
            graph.AddVertex('E');
            graph.AddVertex('F');
            graph.AddVertex('G');
            graph.AddVertex('H');

            graph.AddEdge('A', 'C');
            graph.AddEdge('B', 'C');
            graph.AddEdge('B', 'D');
            graph.AddEdge('C', 'E');
            graph.AddEdge('E', 'H');
            graph.AddEdge('E', 'F');
            graph.AddEdge('D', 'F');
            graph.AddEdge('F', 'G');
           
        }

        [TestMethod]
        public void ShouldPrintDFS()
        {
            graph.PrintDFS();

            var g = new Graph<char>();

            g.AddVertex('A');
            g.AddVertex('B');
            g.AddVertex('C');
            g.AddVertex('D');
            
            g.AddEdge('A', 'B');
            g.AddEdge('A', 'C');
            g.AddEdge('B', 'D');
            g.AddEdge('C', 'D');

            g.PrintDFS();
        }

        [TestMethod]
        public void ShouldPrintBFS()
        {
            var g = new Graph<char>();

            g.AddVertex('A');
            g.AddVertex('B');
            g.AddVertex('C');
            g.AddVertex('D');
            g.AddVertex('E');
            g.AddVertex('F');
            g.AddVertex('G');

            g.AddEdge('A', 'B');
            g.AddEdge('A', 'C');
            g.AddEdge('B', 'E');
            g.AddEdge('C', 'D');
            g.AddEdge('A', 'D');
            g.AddEdge('C', 'E');
            g.AddEdge('E', 'F');

            g.PrintBFS();
        }

        [TestMethod]
        public void ShouldPrintTS()
        {
            var g = new Graph<char>();

            g.AddVertex('A');
            g.AddVertex('B');
            g.AddVertex('C');
            g.AddVertex('D');
            g.AddVertex('E');
            g.AddVertex('F');
            g.AddVertex('G');

            g.AddEdge('A', 'B');
            g.AddEdge('A', 'C');
            g.AddEdge('B', 'E');
            g.AddEdge('C', 'D');
            g.AddEdge('A', 'D');
            g.AddEdge('C', 'E');
            g.AddEdge('E', 'F');
            g.AddEdge('D', 'F');

            g.PrintTopologicalSortSequence('C');
        }

        [TestMethod]
        public void ShouldPrintAllTS()
        {
            var g = new Graph<char>();

            g.AddVertex('A');
            g.AddVertex('B');
            g.AddVertex('C');
            g.AddVertex('D');
            g.AddVertex('E');
            g.AddVertex('F');
            //g.AddVertex('G');

            g.AddEdge('A', 'B');
            g.AddEdge('A', 'C');
            g.AddEdge('A', 'D');
            g.AddEdge('B', 'E');
            g.AddEdge('C', 'D');
            g.AddEdge('C', 'E');
            g.AddEdge('E', 'F');
            g.AddEdge('D', 'F');

            g.PrintAllTopologicalSortSequences();
        }

        [TestMethod]
        public void ShouldPrintAllPermutations()
        {
            var g = new Graph<char>();

            g.AddVertex('A');
            g.AddVertex('B');
            g.AddVertex('C');
            g.AddVertex('D');

            var results = g.GetAllPermutationsOfVertices();
            foreach (var r in results)
                Console.WriteLine(new String(r));
        }
        
    }
}
