using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public class ComparerBuilder<T> : IComparer<T>
    {
        IComparer<T> initial_comparer;

        public ComparerBuilder(IComparer<T> initial_comparer)
        {
            this.initial_comparer = initial_comparer;
        }

        public ComparerBuilder<T> then_by_descending<PropertyType>(Func<T, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return then_using(new PropertyComparer<T, PropertyType>(accessor,
                                                                    new ComparableComparer<PropertyType>().reverse()));
        }

        public ComparerBuilder<T> then_by<PropertyType>(Func<T, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return then_using(new PropertyComparer<T, PropertyType>(accessor,
                                                                    new ComparableComparer<PropertyType>()));
        }

        ComparerBuilder<T> then_using(IComparer<T> next)
        {
            return new ComparerBuilder<T>(new CombinedComparer<T>(initial_comparer, next));
        }

        public int Compare(T x, T y)
        {
            return initial_comparer.Compare(x, y);
        }
    }
}