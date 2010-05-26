using System;

namespace nothinbutdotnetprep.utility.sorting
{
    public static class Sort<ItemToSort>
    {
        public static ComparerBuilder<ItemToSort> by<PropertyType>(Func<ItemToSort, PropertyType> accessor,
                                                                   params PropertyType[] values)
        {
            return new ComparerBuilder<ItemToSort>(new PropertyComparer<ItemToSort, PropertyType>(accessor,
                                                                                                  new FixedComparer
                                                                                                      <PropertyType>(
                                                                                                      values)));
        }

        public static ComparerBuilder<ItemToSort> by<PropertyType>(Func<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return new ComparerBuilder<ItemToSort>(new PropertyComparer<ItemToSort, PropertyType>(accessor,
                                                                                                  new ComparableComparer
                                                                                                      <PropertyType>()));
        }

        public static ComparerBuilder<ItemToSort> by_descending<PropertyType>(Func<ItemToSort, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return new ComparerBuilder<ItemToSort>(new PropertyComparer<ItemToSort, PropertyType>(accessor,
                                                                                                  new ComparableComparer
                                                                                                      <PropertyType>()).
                                                       reverse());
        }
    }
}