using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public class FixedComparer<ItemToSort,PropertyType> :IComparer<ItemToSort>
    {
        public int Compare(ItemToSort x, ItemToSort y)
        {
            throw new NotImplementedException();
        }
    }
}