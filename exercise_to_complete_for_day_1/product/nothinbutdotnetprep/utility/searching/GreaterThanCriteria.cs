using System;

namespace nothinbutdotnetprep.utility.searching
{
    public class GreaterThanCriteria<T> :Criteria<T> where T : IComparable<T>
    {
        T start;

        public GreaterThanCriteria(T start)
        {
            this.start = start;
        }

        public bool is_satisfied_by(T item)
        {
            return item.CompareTo(start) > 0;
        }
    }
}