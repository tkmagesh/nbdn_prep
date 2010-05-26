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
}