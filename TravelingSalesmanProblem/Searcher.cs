using System.Collections.Generic;

namespace TravelingSalesmanProblem
{
    public class Searcher
    {
        private List<int[]> SequenceList { get; set; }
        
        private Graph Graph { get; set; }

        public List<int> Ways { get; }

        public Searcher(List<int[]> sequenceList, Graph graph)
        {
            SequenceList = sequenceList;
            Graph = graph;
            Ways = new List<int>();
        }

        public int SearchShortWay()
        {
            var map = Graph.WeightMap;
            var minWay = int.MaxValue;
            foreach (var list in SequenceList)
            {
                var lengthWay = 0;
                for (var i = 0; i < list.Length; i++)
                {
                    if (i == list.Length - 1)
                    {
                        lengthWay += map[list[i] - 1, list[0] - 1];
                    }
                    else
                    {
                        lengthWay += map[list[i] - 1, list[i + 1] - 1];
                    }
                }
                Ways.Add(lengthWay);

                if (minWay > lengthWay)
                {
                    minWay = lengthWay;
                }

                lengthWay = 0;
            }

            return minWay;
        }
    }
}