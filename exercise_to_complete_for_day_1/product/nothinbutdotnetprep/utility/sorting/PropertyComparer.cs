using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public class PropertyComparer<ItemToSort,PropertyType> : IComparer<ItemToSort>
    {
        IComparer<PropertyType> actual_comparer;
        Func<ItemToSort, PropertyType> accessor;

        public PropertyComparer(Func<ItemToSort, PropertyType> accessor, IComparer<PropertyType> actual_comparer)
        {
            this.actual_comparer = actual_comparer;
            this.accessor = accessor;
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            return actual_comparer.Compare(accessor(x), accessor(y));
        }
    }
}