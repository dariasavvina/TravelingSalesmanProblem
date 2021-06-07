using System;
using System.Collections.Generic;

namespace TravelingSalesmanProblem
{
    public class Graph
    {
        public int[,] WeightMap { get; }
        
        public Graph(int countVertex, int minWeight, int maxWeight)
        {
            WeightMap = GenerateGraph(countVertex, minWeight, maxWeight);
        }

        private int[,] GenerateGraph(int countVertex, int minWeight, int maxWeight)
        {
            var random = new Random();
            var result = new int[countVertex,countVertex];
            for (var i = 0; i < countVertex; i++)
            {
                for (var j = 0; j < countVertex; j++)
                {
                    if (i != j)
                    {
                        if (result[j, i] != 0)
                        {
                            result[i, j] = result[j, i];
                        }
                        else
                        {
                            result[i, j] = random.Next(minWeight, maxWeight);
                        }
                    }
                }
            }

            return result;
        }

        public void PrintGraph()
        {
            var length = WeightMap.GetLength(0);
            for (var i = 0; i < length; i++)
            {
                for (var j = 0; j < length; j++)
                {
                    Console.Write(WeightMap[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        
    }
}