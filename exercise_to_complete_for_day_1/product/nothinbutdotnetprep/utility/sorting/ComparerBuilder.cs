using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    //see how creative you can get with generics
    public interface ComparerBuilder<T> : IComparer<T>
    {
        ComparerBuilder<T> then_by<PropertyType>(Func<T, PropertyType> accessor, params PropertyType[] values);

        ComparerBuilder<T> then_by<PropertyType>(Func<T, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>;

        ComparerBuilder<T> then_by_descending<PropertyType>(Func<T, PropertyType> accessor)
            where PropertyType : IComparable<PropertyType>;
    }
}