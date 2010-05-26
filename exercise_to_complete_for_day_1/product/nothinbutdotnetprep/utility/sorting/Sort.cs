using System;
using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetprep.utility.searching;

namespace nothinbutdotnetprep.utility.sorting
{
    public static class Sort<T>
    {
        public static IComparer<T> by<PropertyType>(Func<T, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            //return new ComparableCriteriaFactory<T, PropertyType>(accessor);
            return new ComparableCriteriaFactory<T, PropertyType>(accessor).by(access)
        }
    }

}