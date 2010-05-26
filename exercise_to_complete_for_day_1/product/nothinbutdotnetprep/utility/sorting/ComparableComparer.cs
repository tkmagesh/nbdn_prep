using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public class ComparableComparer<ItemToCompare,PropertyType> : IComparer<ItemToCompare> where PropertyType: IComparable<PropertyType>
    {
        Func<ItemToCompare, PropertyType> accessor;

        public ComparableComparer(Func<ItemToCompare, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public int Compare(ItemToCompare x, ItemToCompare y)
        {
            return accessor(x).CompareTo(accessor(y));
        }
    }
}