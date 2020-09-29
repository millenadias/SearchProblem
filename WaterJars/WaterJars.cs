using Search.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace WaterJars
{

    public class WaterJars : ActionStateInterface, ICloneable
    {
        private int Jar1State = 0;
        private int Jar2State = 0;

        public WaterJars(int pJar1State, int pJar2State)
        {
            this.Jar1State = pJar1State;
            this.Jar2State = pJar2State;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public ActionStateInterface doAction(string pAction)
        {
            WaterJars state = (WaterJars)this.Clone();

            switch (pAction)
            {
                case WaterJarsActions.EMPTY1:
                    state.Jar1State = WaterJarsStates.EMPTY;
                    break;
                case WaterJarsActions.EMPTY2:
                    state.Jar2State = WaterJarsStates.EMPTY;
                    break;
                case WaterJarsActions.FILL1:
                    state.Jar1State = WaterJarsStates.L3;
                    break;
                case WaterJarsActions.FILL2:
                    state.Jar2State = WaterJarsStates.L4;
                    break;
                case WaterJarsActions.TRANSFER1TO2:
                    int transfer = Math.Min(state.Jar1State, 4 - state.Jar2State);
                    Console.WriteLine($" action: {pAction}, transfer: {transfer}, jar1: {state.Jar1State}, jar2: {state.Jar2State} ");

                    state.Jar1State -= transfer;
                    state.Jar2State += transfer;
                    break;
                case WaterJarsActions.TRANSFER2TO1:
                    int transfer01 = Math.Min(state.Jar2State, 3 - state.Jar1State);
                    Console.WriteLine($" action: {pAction}, transfer: {transfer01}, jar1: {state.Jar1State}, jar2: {state.Jar2State} ");


                    state.Jar1State -= transfer01;
                    state.Jar2State += transfer01;
                    break;
            }

            return state;
        }

        public List<string> getAction()
        {
            List<string> list = new List<string>();

            if (this.Jar1State < 3)
                list.Add(WaterJarsActions.FILL1);

            if (this.Jar1State > 0)
            {
                list.Add(WaterJarsActions.EMPTY1);

                if (this.Jar2State < 4)
                    list.Add(WaterJarsActions.TRANSFER1TO2);
            }

            if (this.Jar2State < 4)
                list.Add(WaterJarsActions.FILL2);

            if (this.Jar2State > 0)
            {
                list.Add(WaterJarsActions.EMPTY2);

                if (this.Jar1State < 3)
                    list.Add(WaterJarsActions.TRANSFER2TO1);
            }

            return list;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;
            if (obj.GetType() == this.GetType())
            {
                WaterJars o = (WaterJars)obj;
                return o.Jar1State == this.Jar1State && o.Jar2State == this.Jar2State;
            }
            else
                return false;

        }

        public override string ToString()
        {
            return $"[{this.Jar1State}, {this.Jar2State}]";
        }
    }
}
