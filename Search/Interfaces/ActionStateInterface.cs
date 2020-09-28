using System;
using System.Collections.Generic;
using System.Text;

namespace Search.Interfaces
{
    public interface ActionStateInterface
    {

        public List<string> getAction();
        public ActionStateInterface doAction(string pAction);
        public string ToString();
        public bool Equals(object? obj);
    }
}
