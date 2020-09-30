using Search.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SizeNPuzzle
{
    public class SizeNPuzzle : ActionStateInterface, ICloneable
    {
        private List<int?[]> Matriz = new List<int?[]>();
        public SizeNPuzzle(List<int?[]> pMatriz)
        {
            foreach (var item in pMatriz)
                Matriz.Add(item);
        }

        public object Clone()
        {
            List<int?[]> lst = new List<int?[]>();
            foreach (var item in this.Matriz)
            {
                lst.Add((int?[])item.Clone());
            }
            return new SizeNPuzzle(lst);
        }

        public ActionStateInterface doAction(string pAction)
        {
            SizeNPuzzle state = (SizeNPuzzle)this.Clone();
            int i, j = 0;

            for (i = 0; i < this.Matriz.Count; i++)
            {
                j = Array.FindIndex(this.Matriz[i], value => value != null && value != 1);

                if (j != -1)
                    break;
            }

            if (pAction == SizeNPuzzleActions.MOVEDOWN)
            {
                state.Matriz[i][j] = this.Matriz[i + 1][j];
                state.Matriz[i + 1][j] = null;
            }
            else if (pAction == SizeNPuzzleActions.MOVEUP)
            {
                state.Matriz[i][j] = this.Matriz[i - 1][j];
                state.Matriz[i - 1][j] = null;
            }
            else if (pAction == SizeNPuzzleActions.MOVELEFT)
            {
                state.Matriz[i][j] = this.Matriz[i][j - 1];
                state.Matriz[i][j - 1] = null;
            }
            else if (pAction == SizeNPuzzleActions.MOVERIGHT)
            {
                state.Matriz[i][j] = this.Matriz[i][j + 1];
                state.Matriz[i][j + 1] = null;
            }

            return state;
        }

        public List<string> getAction()
        {
            List<string> list = new List<string>();

            int i, j = 0;

            for (i = 0; i < this.Matriz.Count; i++)
            {
                j = Array.FindIndex(this.Matriz[i], value => value != null && value != 1);

                if (j != -1)
                    break;
            }

            if (i + 1 < this.Matriz.Count)
                list.Add(SizeNPuzzleActions.MOVEDOWN);


            if (i - 1 >= 0)
                list.Add(SizeNPuzzleActions.MOVEUP);

            
            if (this.Matriz.Count > i && j + 1 < this.Matriz[i].Length)
                list.Add(SizeNPuzzleActions.MOVERIGHT);


            if (j - 1 >= 0)
                list.Add(SizeNPuzzleActions.MOVELEFT);


            return list;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;
            if (obj.GetType() == this.GetType())
            {
                SizeNPuzzle o = (SizeNPuzzle)obj;
                if (this.Matriz.Count != o.Matriz.Count)
                    return false;
                
                for (int i = 0; i < this.Matriz.Count; i++)
                {
                    if (this.Matriz[i].Length != o.Matriz[i].Length)
                        return false;
                    
                    for (int j = 0; j < this.Matriz[i].Length; j++)
                    {
                        if (this.Matriz[i][j] != o.Matriz[i][j])
                            return false;
                    }
                }

                return true;

            }
            else
                return false;

        }
    }
}
