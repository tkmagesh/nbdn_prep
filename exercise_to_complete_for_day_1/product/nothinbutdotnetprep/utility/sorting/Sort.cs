using System;

namespace nothinbutdotnetprep.utility.sorting
{
    public static class Sort<ItemToSort>
    {
        public static DefaultComparerBuilder<ItemToSort> by<PropertyType>(Func<ItemToSort, PropertyType> accessor,
                                                                   params PropertyType[] values)
        {
            return new DefaultComparerBuilder<ItemToSort>(new PropertyComparer<ItemToSort, PropertyType>(accessor,
                                                                                                  new FixedComparer
                                                                                                      <PropertyType>(
                                                                                                      values)));
        }

        public static DefaultComparerBuilder<ItemToSort> by<PropertyType>(Func<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return new DefaultComparerBuilder<ItemToSort>(new PropertyComparer<ItemToSort, PropertyType>(accessor,
                                                                                                  new ComparableComparer
                                                                                                      <PropertyType>()));
        }

        public static DefaultComparerBuilder<ItemToSort> by_descending<PropertyType>(Func<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return new DefaultComparerBuilder<ItemToSort>(new PropertyComparer<ItemToSort, PropertyType>(accessor,
                                                                                                  new ComparableComparer
                                                                                                      <PropertyType>()).
                                                       reverse());
        }
    }

    public static class MyEnumerableExtensions
    {
        public static IEnumerable<ItemToSort> sort_by<ItemToSort, PropertyType> (this IEnumerable<ItemToSort> items, Func<ItemToSort, PropertyType> accessor,
            params PropertyType[] values)
        {
            return items.sort_using(Sort<ItemToSort>.by(accessor, values));
            //return Sort<ItemToSort>.by(accessor, values);
        }

        public static IEnumerable<ItemToSort> sort_by<ItemToSort, PropertyType>(this IEnumerable<ItemToSort> items, Func<ItemToSort, PropertyType> accessor)
           where PropertyType : IComparable<PropertyType>
        {
            return items.sort_using(Sort<ItemToSort>.by(accessor));

        }

        public static IEnumerable<ItemToSort> sort_by_descending<ItemToSort, PropertyType>(this IEnumerable<ItemToSort> items, Func<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return items.sort_using(Sort<ItemToSort>.by_descending(accessor));
        }
    }
}