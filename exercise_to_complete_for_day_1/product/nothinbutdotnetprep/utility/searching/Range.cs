using System;

namespace nothinbutdotnetprep.utility.searching
{
    public abstract class Range<T> where T:IComparable<T>
    {
        
        protected T start;
        protected T end;

        public Range(T start, T end)
        {
            this.start = start;
            this.end = end;
        }

        public abstract bool contains(T item);
        
    }
}