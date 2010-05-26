using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public static class ComparerExtensions
    {
        public static IComparer<T> reverse<T>(this IComparer<T> comparer)
        {
            return new ReverseComparer<T>(comparer);
        }
    }
}