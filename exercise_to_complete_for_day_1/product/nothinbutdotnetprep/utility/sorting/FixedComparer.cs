using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public class FixedComparer<ItemToSort,PropertyType> :IComparer<ItemToSort>
    {
        Func<ItemToSort, PropertyType> accessor;
        IList<PropertyType> values;

        public FixedComparer(Func<ItemToSort, PropertyType> accessor, IEnumerable<PropertyType> values)
        {
            this.accessor = accessor;
            this.values = new List<PropertyType>(values);
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            values.IndexOf(accessor(x)).CompareTo(values.IndexOf(accessor(y)));
        }
    }
}