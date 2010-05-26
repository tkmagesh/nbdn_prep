using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public static class Sort<ItemToSort>
    {
        public static IComparer<ItemToSort> by<PropertyType>(Func<ItemToSort, PropertyType> accessor,
                                                             params PropertyType[] values)
        {
            return new PropertyComparer<ItemToSort, PropertyType>(accessor,
                                                                  new FixedComparer<PropertyType>(values));
        }

        public static IComparer<ItemToSort> by<PropertyType>(Func<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return new PropertyComparer<ItemToSort, PropertyType>(accessor,
                                                                  new ComparableComparer<PropertyType>());
        }

        public static IComparer<ItemToSort> by_descending<PropertyType>(Func<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return by(accessor).reverse();
        }
    }
}