using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public interface ComparerBuilder<T> : IComparer<T>
    {
        ComparerBuilder<T> then_by<PropertyType>(Func<T, PropertyType> accessor, params PropertyType[] values);

        ComparerBuilder<T> then_by<PropertyType>(Func<T, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>;

        ComparerBuilder<T> then_by_descending<PropertyType>(Func<T, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>;
    }

    public class DefaultComparerBuilder<T> : IComparer<T>, ComparerBuilder<T>
    {
        IComparer<T> initial_comparer;

        public DefaultComparerBuilder(IComparer<T> initial_comparer)
        {
            this.initial_comparer = initial_comparer;
        }

        public ComparerBuilder<T> then_by<PropertyType>(Func<T, PropertyType> accessor, params PropertyType[] values)

        {
            return then_using(new PropertyComparer<T, PropertyType>(accessor,
                                                                    new FixedComparer<PropertyType>(values)));
        }

        public ComparerBuilder<T> then_by<PropertyType>(Func<T, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return then_using(new PropertyComparer<T, PropertyType>(accessor,
                                                                    new ComparableComparer<PropertyType>()));
        }

        public ComparerBuilder<T> then_by_descending<PropertyType>(Func<T, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return then_using(new PropertyComparer<T, PropertyType>(accessor,
                                                                    new ComparableComparer<PropertyType>().reverse()));
        }

        DefaultComparerBuilder<T> then_using(IComparer<T> next)
        {
            return new DefaultComparerBuilder<T>(new CombinedComparer<T>(initial_comparer, next));
        }

        public int Compare(T x, T y)
        {
            return initial_comparer.Compare(x, y);
        }
    }
}