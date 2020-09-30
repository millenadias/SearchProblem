using Search;
using Search.Interfaces;
using System;
using System.Collections.Generic;

namespace SizeNPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int?[]> listInitial = new List<int?[]>()
            {
                new int?[] { 4, 2, 7 } ,
                new int?[] {null, 8, 6 },
                new int?[] { 3, 5, 1}
            };


            SizeNPuzzle initial = new SizeNPuzzle(listInitial);

            List<int?[]> listFinal = new List<int?[]>()
            {
                new int?[] { 1, 4, 7 } ,
                new int?[] {2, 5, 8 },
                new int?[] { 3, 6, null }
            };

            List<ActionStateInterface> finals = new List<ActionStateInterface>()
            {
                new SizeNPuzzle(listFinal)
            };

            UninformedSearch problem = new UninformedSearch(initial, finals);

            List<CandidateState> result = problem.search();

            foreach (CandidateState state in result)
                Console.WriteLine(state.ToString());

            Console.ReadLine();
        }
    }
}
