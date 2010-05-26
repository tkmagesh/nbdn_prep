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

    public static class MyExtensions
    {
        public static IComparer<ItemToSort> then_by<ItemToSort, PropertyType>(this IComparer<ItemToSort> firstComparer,
                                                                              Func<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            /* return new CombinedComparer<ItemToSort>(firstComparer,
                                                    new ComparableComparer<ItemToSort, PropertyType>(accessor));*/

            return new CombinedComparer<ItemToSort>(firstComparer, Sort<ItemToSort>.by(accessor));
        }
    }
}