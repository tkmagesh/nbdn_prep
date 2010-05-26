using System;
using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetprep.utility.sorting;

namespace nothinbutdotnetprep.utility.extensions
{
    public class SortingEnumerable<T> : IEnumerable<T>
    {
        IEnumerable<T> items;
        ComparerBuilder<T> builder;

        public SortingEnumerable(IEnumerable<T> items, ComparerBuilder<T> builder)
        {
            this.items = items;
            this.builder = builder;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public SortingEnumerable<T> then_by<PropertyType>(Func<T, PropertyType> accessor, params PropertyType[] values)
        {
            return new SortingEnumerable<T>(items, builder.then_by(accessor,values));
        }

        public SortingEnumerable<T> then_by<PropertyType>(Func<T, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return new SortingEnumerable<T>(items, builder.then_by(accessor));

        }

        public SortingEnumerable<T> then_by_descending<PropertyType>(Func<T, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>
        {
            return new SortingEnumerable<T>(items, builder.then_by_descending(accessor));
        }

        public IEnumerator<T> GetEnumerator()
        {
            return items.sort_using(builder).GetEnumerator();
        }
    }
}