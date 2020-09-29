using Search;
using Search.Interfaces;
using System;
using System.Collections.Generic;

namespace WaterJars
{
    class Program
    {
        static void Main(string[] args)
        {
            WaterJars initial = new WaterJars(WaterJarsStates.EMPTY, WaterJarsStates.L1);

            List<ActionStateInterface> finals = new List<ActionStateInterface>()
            {
               new WaterJars(WaterJarsStates.EMPTY, WaterJarsStates.L2),
                    new WaterJars(WaterJarsStates.L1, WaterJarsStates.L2),
                    new WaterJars(WaterJarsStates.L2, WaterJarsStates.L2),
                    new WaterJars(WaterJarsStates.L3, WaterJarsStates.L2)
            };

            UninformedSearch problem = new UninformedSearch(initial, finals);

            List<CandidateState> result = problem.search();

            foreach (CandidateState state in result)
                Console.WriteLine(state.ToString());

            Console.ReadLine(); 

        }
    }
}
