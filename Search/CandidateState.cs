using Search.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Search
{
    public class CandidateState
    {
        private ActionStateInterface _actionsState;
        private string _action;
        private CandidateState _parentActionState;
        private List<CandidateState> _ChildrenStates = new List<CandidateState>();
        public ActionStateInterface ActionState
        {
            get { return this._actionsState; }
        }
        public CandidateState ParentCandidateState
        {
            get { return this._parentActionState; }
        }
        public CandidateState(ActionStateInterface pActionState, CandidateState pParentCandidateStatus = null, string pCurrentAction = null)
        {
            this._actionsState = pActionState;
            this._action = pCurrentAction;
            this._parentActionState = pParentCandidateStatus;
        }

        public List<CandidateState> getSuccessors()
        {
            List<string> list = this._actionsState.getAction();
            List<CandidateState> successors = new List<CandidateState>();

            foreach (string action in list)
            {
                ActionStateInterface state = this._actionsState.doAction(action);
                CandidateState successor = new CandidateState(state, this, action);
                this._ChildrenStates.Add(successor);
                successors.Add(successor);
            }
            return successors;
        }

        public override string ToString()
        {
            if (this._action != null)
                return $"{this._action} > { this._actionsState.ToString()}";
            else
                return $"start > { this._actionsState.ToString()}";
        }
    }
}