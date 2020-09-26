using Search.Enums;
using Search.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Search.Extensions;

namespace Search
{
    public class UninformedSearch
    {
        private ActionStateInterface _initialState;
        private List<ActionStateInterface> _finalState;
        public UninformedSearch(ActionStateInterface pInitialState, List<ActionStateInterface> pFinalState)
        {
            this._initialState = pInitialState;
            this._finalState = pFinalState;
        }

        public List<CandidateState> search(SortAlgorithmType pSortAlgorithmType = SortAlgorithmType.BSF)
        {
            List<ActionStateInterface> visited = new List<ActionStateInterface>();
            CandidateState candidate = new CandidateState(this._initialState);
            List<CandidateState> pending = new List<CandidateState>() { candidate };
            int i = 0;

            while (pending.Any())
            {
                candidate = pSortAlgorithmType == SortAlgorithmType.DSF ? pending.Pop() : pending.Shift();
                i++;

                if (i % 1000 == 0)
                    Console.WriteLine(i);
                
                if (this._finalState.Any(state => state.Equals(candidate.ActionState)))
                {
                    List<CandidateState> result = new List<CandidateState>();

                    while (candidate != null)
                    {
                        result.Add(candidate);
                        candidate = candidate.ParentCandidateState;
                    }

                    result.Reverse();
                    return result;
                }
                else
                {
                    visited.Add(candidate.ActionState);

                    List<CandidateState> successors = candidate.getSuccessors();

                    foreach (CandidateState successor in successors)
                        if (!visited.Any(state => state.Equals(successor.ActionState)))
                            pending.Add(successor);
                }
            }

            return null;
        }
    }
}
