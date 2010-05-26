using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public static class Sort<ItemToSort>
    {
        public static IComparer<ItemToSort> by<PropertyType>(Func<ItemToSort, PropertyType> accessor,
                                                             params PropertyType[] values)
        {

            return new ComparableComparerWithCustomSortOrder<ItemToSort, PropertyType>(accessor, values); 
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

    public static class MyExtensions
    {
        public static IComparer<ItemToSort> then_by<ItemToSort, PropertyType>(this IComparer<ItemToSort> firstComparer, Func<ItemToSort, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
           /* return new CombinedComparer<ItemToSort>(firstComparer,
                                                    new ComparableComparer<ItemToSort, PropertyType>(accessor));*/

            return new CombinedComparer<ItemToSort>(firstComparer, Sort<ItemToSort>.by(accessor));
        }
    }
}