using System;

namespace nothinbutdotnetprep.utility.searching
{
    public class InclusiveRange<T> : Range<T> where T : IComparable<T>
    {
        public InclusiveRange(T start, T end) : base(start, end)
        {}

        public override bool contains(T item)
        {
            return (item.CompareTo(start) >= 0 && item.CompareTo(end) <= 0);
        }
    }
}