using System;

namespace TravelingSalesmanProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of vertices in the graph");
            var countVertex = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Enter the minimum distance between vertices");
            var minWeight = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Enter the maximum distance between vertices");
            var maxWeight = int.Parse(Console.ReadLine()!);
            var graph = new Graph(countVertex, minWeight, maxWeight);
            Console.WriteLine("The graph distance matrix:");
            graph.PrintGraph();
            Console.WriteLine("Generate permutations");
            var perm = new Permutations(countVertex);
            var permutationsList = perm.GetPermutationsList();
            Console.WriteLine("Finding the minimum path");
            var searcher = new Searcher(permutationsList, graph);
            Console.WriteLine("Minimal way: " + searcher.SearchShortWay());
        }
    }
}