using Search;
using Search.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VacuumCleanerWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            VacuumCleanerWorld initial = new VacuumCleanerWorld(VacuumCleanerWorldPositions.ROOM1, VacuumCleanerWorldStates.DIRTY, VacuumCleanerWorldStates.DIRTY, VacuumCleanerWorldStates.DIRTY);

            List<ActionStateInterface> finals = new List<ActionStateInterface>()
            {
                new VacuumCleanerWorld(VacuumCleanerWorldPositions.ROOM1, VacuumCleanerWorldStates.CLEAN, VacuumCleanerWorldStates.CLEAN, VacuumCleanerWorldStates.CLEAN),
                new VacuumCleanerWorld(VacuumCleanerWorldPositions.ROOM2, VacuumCleanerWorldStates.CLEAN, VacuumCleanerWorldStates.CLEAN, VacuumCleanerWorldStates.CLEAN),
                new VacuumCleanerWorld(VacuumCleanerWorldPositions.ROOM3, VacuumCleanerWorldStates.CLEAN, VacuumCleanerWorldStates.CLEAN, VacuumCleanerWorldStates.CLEAN)
            };

            UninformedSearch problem = new UninformedSearch(initial, finals);

            List<CandidateState> result = problem.search();

            foreach (CandidateState state in result)
                Console.WriteLine(state.ToString());

            Console.ReadLine();
        }
    }
}
