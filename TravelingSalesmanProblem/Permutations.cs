using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelingSalesmanProblem
{
    public class Permutations
    {
        private List<int []> _permutationsList;
        private int[] initialSequence;
        
        private void AddToList(int[] sequence, bool repeat = false)
        {
            var newSeq = new int[sequence.Length];
            for (var i = 0; i < sequence.Length; i++)
            {
                newSeq[i] = sequence[i];
            }
            if (repeat || !_permutationsList.Contains(newSeq))
            {
                _permutationsList.Add(newSeq);
            }
 
        }
        
        private void RecPermutation(int[] sequence, int length, bool repeat = false)
        {
            for (var i = 0; i < length; i++)
            {
                var temp = sequence[length - 1];
                for (var j = length - 1; j > 0; j--)
                {
                    sequence[j] = sequence[j - 1];
                }
                sequence[0] = temp;
                if (i < length - 1) AddToList(sequence, repeat);
                if (length > 0) RecPermutation(sequence, length - 1, repeat);
            }
        }
 
        public Permutations()
        {
            initialSequence = Array.Empty<int>();
        }
        
        public Permutations(int countVertex)
        {
            initialSequence = GenerateInitialSequence(countVertex);
        }

        private int[] GenerateInitialSequence(int countVertex)
        {
            var result = new int[countVertex];
            for (var i = 0; i < result.Length; i++)
            {
                result[i] = i + 1;
            }

            return result;
        }

        public List<int[]> GetPermutationsList(bool repeat = false)
        {
            _permutationsList = new List<int[]> { initialSequence };
            RecPermutation(initialSequence, initialSequence.Length, repeat);
            return _permutationsList;
        }

        public List<int[]> GetPermutationsSortList(bool repeat = false)
        {
            GetPermutationsList(repeat).Sort();
            return _permutationsList;
        }
 
    }
}