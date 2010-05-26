using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public class AnonymousComparer<ItemToCompare> : IComparer<ItemToCompare>
    {
        Func<ItemToCompare, ItemToCompare, int> compare;

        public AnonymousComparer(Func<ItemToCompare, ItemToCompare, int> compare)
        {
            this.compare = compare;
        }

        public int Compare(ItemToCompare x, ItemToCompare y)
        {
            return compare(x, y);
        }
    }
}