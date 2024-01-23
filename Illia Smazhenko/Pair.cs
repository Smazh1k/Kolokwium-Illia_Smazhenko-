using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Zadanie 4
namespace Illia_Smazhenko
{
    public class Pair<T,S> : IComparable<Pair<T, S>> where T : IComparable<T> where S : IComparable<S>
    {
        public T First { get; set; }
        public S Second { get; set; }

        public Pair(T first, S second)
        {
            First = first;
            Second = second;
        }

        public int CompareTo(Pair<T, S> other)
        {
            int firstComparison = First.CompareTo(other.First);
            if (firstComparison == 0)
            {
                return Second.CompareTo(other.Second);
            }

            return firstComparison;
        }
        public static void SortPairs(List<Pair<T, S>> pairs)
        {
            pairs.Sort();
        }
    }
}
