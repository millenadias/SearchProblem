using System;
using System.Collections.Generic;
using System.Text;

namespace Search.Extensions
{
    public static class ListExtension
    {
        public static T Pop<T>(this IList<T> pList)
        {
            lock (pList)
            {
                int index = pList.Count - 1;
                T value = pList[index];
                pList.RemoveAt(index);
                return value;
            }
        }

        public static T Shift<T>(this IList<T> pList)
        {
            lock (pList)
            {
                int index = 0;
                T value = pList[index];
                pList.RemoveAt(index);
                return value;
            }
        }
    }
}
