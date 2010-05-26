using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public static class Sort<ItemToSort>
    {
        public static IComparer<ItemToSort> by<PropertyType>(Func<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return new AnonymousComparer<ItemToSort>((x, y) => accessor(x).CompareTo(accessor(y)));
        }

        public static IComparer<ItemToSort> by_descending<PropertyType>(Func<ItemToSort, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return by(accessor).reverse();
        }
    }
}