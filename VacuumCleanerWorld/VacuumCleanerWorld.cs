using Search.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace VacuumCleanerWorld
{
    public class VacuumCleanerWorld : ActionStateInterface, ICloneable
    {
        private string VacuumPosition = string.Empty;
        private string Room1State = string.Empty;
        private string Room2State = string.Empty;
        private string Room3State = string.Empty;

        public VacuumCleanerWorld(string pVacuumPosition, string pRoom1State, string pRoom2State, string pRoom3State)
        {
            VacuumPosition = pVacuumPosition;
            Room1State = pRoom1State;
            Room2State = pRoom2State;
            Room3State = pRoom3State;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public ActionStateInterface doAction(string pAction)
        {
            VacuumCleanerWorld state = (VacuumCleanerWorld)this.Clone();

            switch (pAction)
            {
                case VacuumCleanerWorldActions.GOTOROOM1:
                    state.VacuumPosition = VacuumCleanerWorldPositions.ROOM1;
                    break;
                case VacuumCleanerWorldActions.GOTOROOM2:
                    state.VacuumPosition = VacuumCleanerWorldPositions.ROOM2;
                    break;
                case VacuumCleanerWorldActions.GOTOROOM3:
                    state.VacuumPosition = VacuumCleanerWorldPositions.ROOM3;
                    break;
                case VacuumCleanerWorldActions.CLEAR:
                    {
                        if (this.VacuumPosition == VacuumCleanerWorldPositions.ROOM1)
                            state.Room1State = VacuumCleanerWorldStates.CLEAN;
                        else if (this.VacuumPosition == VacuumCleanerWorldPositions.ROOM2)
                            state.Room2State = VacuumCleanerWorldStates.CLEAN;
                        else
                            state.Room3State = VacuumCleanerWorldStates.CLEAN;
                    }
                    break;
            }

            return state;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;
            if (obj.GetType() == this.GetType())
            {
                VacuumCleanerWorld o = (VacuumCleanerWorld)obj;
                return o.VacuumPosition == this.VacuumPosition &&
                o.Room1State == this.Room1State &&
                o.Room2State == this.Room2State &&
                o.Room3State == this.Room3State;
            }
            else
                return false;
        
        }

        public List<string> getAction()
        {
            List<string> list = new List<string>();

            switch (this.VacuumPosition)
            {
                case VacuumCleanerWorldPositions.ROOM1:
                    {
                        if (this.Room1State == VacuumCleanerWorldStates.DIRTY)
                            list.Add(VacuumCleanerWorldActions.CLEAR);
                        list.Add(VacuumCleanerWorldActions.GOTOROOM2);
                    }
                    break;
                case VacuumCleanerWorldPositions.ROOM2:
                    {
                        if (this.Room2State == VacuumCleanerWorldStates.DIRTY)
                            list.Add(VacuumCleanerWorldActions.CLEAR);
                        list.Add(VacuumCleanerWorldActions.GOTOROOM1);
                        list.Add(VacuumCleanerWorldActions.GOTOROOM3);
                    }
                    break;
                case VacuumCleanerWorldPositions.ROOM3:
                    {
                        if (this.Room3State == VacuumCleanerWorldStates.DIRTY)
                            list.Add(VacuumCleanerWorldActions.CLEAR);
                        list.Add(VacuumCleanerWorldActions.GOTOROOM2);
                    }
                    break;
            }

            return list;
        }

        public override string ToString()
        {
            return $"[{this.VacuumPosition}, {this.Room1State}, {this.Room2State}, {this.Room3State}]";
        }
    }
}
