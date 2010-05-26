using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public static class Sort<ItemToSort>
    {
        public static IComparer<ItemToSort> by<PropertyType>(Func<ItemToSort, PropertyType> accessor,
                                                             params PropertyType[] values)
        {
            throw new NotImplementedException();
        }

        public static IComparer<ItemToSort> by<PropertyType>(Func<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return new ComparableComparer<ItemToSort, PropertyType>(accessor);
        }

        public static IComparer<ItemToSort> by_descending<PropertyType>(Func<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return by(accessor).reverse();
        }
    }
}