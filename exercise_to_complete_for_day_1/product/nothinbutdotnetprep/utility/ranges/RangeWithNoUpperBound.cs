using System;

namespace nothinbutdotnetprep.utility.ranges
{
    public class RangeWithNoUpperBound<T> : Range<T> where T : IComparable<T>
    {
        public bool contains(T item)
        {
            return false;
        }
    }
}