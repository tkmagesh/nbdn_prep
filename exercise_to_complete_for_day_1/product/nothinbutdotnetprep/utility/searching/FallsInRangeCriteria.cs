using System;
using nothinbutdotnetprep.utility.ranges;

namespace nothinbutdotnetprep.utility.searching
{
    public class FallsInRangeCriteria<T> : Criteria<T> where T : IComparable<T>
    {
        Range<T> range;

        public FallsInRangeCriteria(Range<T> range)
        {
            this.range = range;
        }

        public bool is_satisfied_by(T item)
        {
            return range.contains(item);
        }
    }
}