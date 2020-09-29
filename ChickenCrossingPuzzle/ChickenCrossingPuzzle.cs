using Search.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChickenCrossingPuzzle
{
    public class ChickenCrossingPuzzle : ActionStateInterface, ICloneable
    {
        private string FarmerState = string.Empty;
        private string FoxState = string.Empty;
        private string ChickenState = string.Empty;
        private string CornState = string.Empty;

        public ChickenCrossingPuzzle(string pFarmerState, string pFoxState, string pChickenState, string pCornState)
        {
            this.FarmerState = pFarmerState;
            this.FoxState = pFoxState;
            this.ChickenState = pChickenState;
            this.CornState = pCornState;
        }

       

        public ActionStateInterface doAction(string pAction)
        {
            ChickenCrossingPuzzle state = (ChickenCrossingPuzzle)this.Clone();

            switch (pAction)
            {
                case ChickenCrossingPuzzleActions.GOALONE:
                    state.FarmerState = ChickenCrossingPuzzleStates.RIGHT;
                    break;
                case ChickenCrossingPuzzleActions.GOWITHFOX:
                    state.FarmerState = ChickenCrossingPuzzleStates.RIGHT;
                    state.FoxState = ChickenCrossingPuzzleStates.RIGHT;
                    break;
                case ChickenCrossingPuzzleActions.GOWITHCHICKEN:
                    state.FarmerState = ChickenCrossingPuzzleStates.RIGHT;
                    state.ChickenState = ChickenCrossingPuzzleStates.RIGHT;
                    break;
                case ChickenCrossingPuzzleActions.GOWITHCORN:
                    state.FarmerState = ChickenCrossingPuzzleStates.RIGHT;
                    state.CornState = ChickenCrossingPuzzleStates.RIGHT;
                    break;
                case ChickenCrossingPuzzleActions.COMEBACKALONE:
                    state.FarmerState = ChickenCrossingPuzzleStates.LEFT;
                    break;
                case ChickenCrossingPuzzleActions.COMEBACKWITHFOX:
                    state.FarmerState = ChickenCrossingPuzzleStates.LEFT;
                    state.FoxState = ChickenCrossingPuzzleStates.LEFT;
                    break;
                case ChickenCrossingPuzzleActions.COMEBACKWITHCHICKEN:
                    state.FarmerState = ChickenCrossingPuzzleStates.LEFT;
                    state.ChickenState = ChickenCrossingPuzzleStates.LEFT;
                    break;
                case ChickenCrossingPuzzleActions.COMEBACKWITHCORN:
                    state.FarmerState = ChickenCrossingPuzzleStates.LEFT;
                    state.CornState = ChickenCrossingPuzzleStates.LEFT;
                    break;
            }

            return state;
        }

        public List<string> getAction()
        {
            List<string> list = new List<string>();

            if (this.FarmerState == ChickenCrossingPuzzleStates.LEFT)
            {
                if ((this.FoxState != this.ChickenState) && (this.ChickenState != this.CornState))
                    list.Add(ChickenCrossingPuzzleActions.GOALONE);

                if ((this.FoxState == ChickenCrossingPuzzleStates.LEFT) && (this.ChickenState != this.CornState))
                    list.Add(ChickenCrossingPuzzleActions.GOWITHFOX);

                if (this.ChickenState == ChickenCrossingPuzzleStates.LEFT)
                    list.Add(ChickenCrossingPuzzleActions.GOWITHCHICKEN);

                if ((this.CornState == ChickenCrossingPuzzleStates.LEFT) && (this.FoxState != this.ChickenState))
                    list.Add(ChickenCrossingPuzzleActions.GOWITHCORN);
            }
            else
            {
                if ((this.FoxState != this.ChickenState) && (this.ChickenState != this.CornState))
                    list.Add(ChickenCrossingPuzzleActions.COMEBACKALONE);

                if ((this.FoxState == ChickenCrossingPuzzleStates.RIGHT) && (this.ChickenState != this.CornState))
                    list.Add(ChickenCrossingPuzzleActions.COMEBACKWITHFOX);

                if (this.ChickenState == ChickenCrossingPuzzleStates.RIGHT)
                    list.Add(ChickenCrossingPuzzleActions.COMEBACKWITHCHICKEN);

                if ((this.CornState == ChickenCrossingPuzzleStates.RIGHT) && (this.FoxState != this.ChickenState))
                    list.Add(ChickenCrossingPuzzleActions.COMEBACKWITHCORN);
            }

            return list;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;
            if (obj.GetType() == this.GetType())
            {
                ChickenCrossingPuzzle o = (ChickenCrossingPuzzle)obj;

                return o.FarmerState == this.FarmerState &&
                       o.FoxState == this.FoxState &&
                       o.ChickenState == this.ChickenState &&
                       o.CornState == this.CornState;
            }
            else
                return false;

        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            return $"[farmer={this.FarmerState}, fox={this.FoxState}, chicken={this.ChickenState}, corn={this.CornState}]";
        }
    }
}
