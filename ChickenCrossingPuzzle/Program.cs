using Search;
using Search.Interfaces;
using System;
using System.Collections.Generic;

namespace ChickenCrossingPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            ChickenCrossingPuzzle initial = new ChickenCrossingPuzzle(ChickenCrossingPuzzleStates.LEFT, ChickenCrossingPuzzleStates.LEFT, ChickenCrossingPuzzleStates.LEFT, ChickenCrossingPuzzleStates.LEFT);

            List<ActionStateInterface> finals = new List<ActionStateInterface>() {
                new ChickenCrossingPuzzle(ChickenCrossingPuzzleStates.RIGHT, ChickenCrossingPuzzleStates.RIGHT, ChickenCrossingPuzzleStates.RIGHT, ChickenCrossingPuzzleStates.RIGHT)
            };

            UninformedSearch problem = new UninformedSearch(initial, finals);

            List<CandidateState> result = problem.search();

            foreach (CandidateState state in result)
                Console.WriteLine(state.ToString());

            Console.ReadLine();
        }
    }
}
