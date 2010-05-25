using System;
using System.Collections.Generic;
using nothinbutdotnetprep.utility.searching;

namespace nothinbutdotnetprep.utility.extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items, Criteria<T> criteria)
        {
            return items.all_items_matching(criteria.is_satisfied_by);
        }

        public static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items, IEnumerable<Criteria<T>> criterias)
        {
            foreach (var criteria in criterias)
            {
                foreach (var item in items)
                {
                    if (criteria.is_satisfied_by(item))
                        yield return item;
                }
            }
        }

        static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items, Predicate<T> criteria)
        {
            foreach (var item in items) if (criteria(item)) yield return item;
        }

        public static IEnumerable<T> one_at_a_time<T>(this IEnumerable<T> items)
        {
            foreach (var item in items) yield return item;
        }
    }
}