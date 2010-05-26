using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public static class ComparerExtensions
    {
        public static IComparer<ItemToSort> then_by<ItemToSort,PropertyType>(this IComparer<ItemToSort> comparer,
            Func<ItemToSort,PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return new CombinedComparer<ItemToSort>(comparer, Sort<ItemToSort>.by(accessor));
        }

        public static IComparer<T> reverse<T>(this IComparer<T> comparer)
        {
            return new ReverseComparer<T>(comparer); 
        }
    }
}