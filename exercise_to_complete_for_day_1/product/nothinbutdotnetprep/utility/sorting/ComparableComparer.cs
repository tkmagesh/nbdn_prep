using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public class ComparableComparer<PropertyType> : IComparer<PropertyType>
        where PropertyType : IComparable<PropertyType>
    {
        public int Compare(PropertyType x, PropertyType y)
        {
            return x.CompareTo(y);
        }
    }

    public class ComparableComparerWithCustomSortOrder<ItemToCompare, PropertyType> : IComparer<ItemToCompare>
    {
        Func<ItemToCompare, PropertyType> accessor;
        IEnumerable<PropertyType> values;
        Dictionary<PropertyType, int> sortOrder;

        public ComparableComparerWithCustomSortOrder(Func<ItemToCompare, PropertyType> accessor, PropertyType[] values)
        {
            this.accessor = accessor;
            this.values = values;

            sortOrder = new Dictionary<PropertyType, int>();
            for(int i=0; i < values.Length; i++)
                sortOrder.Add(values[i], i);

        }

        public int Compare(ItemToCompare x, ItemToCompare y)
        {
            return sortOrder[accessor(x)].CompareTo(sortOrder[accessor(y)]);
        }
    }
}