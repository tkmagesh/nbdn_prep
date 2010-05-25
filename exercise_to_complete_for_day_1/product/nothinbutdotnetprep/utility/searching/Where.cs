using System;
using System.Collections.Generic;
using nothinbutdotnetprep.collections;
using nothinbutdotnetprep.utility.searching;

namespace nothinbutdotnetprep.utility.searching
{
    public delegate PropertyType PropertyAccessor<ItemToFilter, PropertyType>(ItemToFilter item);

    public class Where<ItemToFilter>
    {
        public static CriteriaFactory<ItemToFilter, PropertyType> has_a<PropertyType>(
             PropertyAccessor<ItemToFilter, PropertyType> accessor)
        {

            return new CriteriaFactory<ItemToFilter, PropertyType>(accessor);
        }

        public static ComparableCriteriaFactory<ItemToFilter, PropertyType> has_an<PropertyType>(PropertyAccessor<ItemToFilter, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return new ComparableCriteriaFactory<ItemToFilter,PropertyType>(accessor);
        }
    }

    public class ComparableCriteriaFactory<ItemToFilter, PropertyType> where PropertyType : IComparable<PropertyType>
    {
        readonly PropertyAccessor<ItemToFilter, PropertyType> accessor;

        public ComparableCriteriaFactory(PropertyAccessor<ItemToFilter, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public Criteria<ItemToFilter> greater_than(PropertyType property_value)
        {
            return new PredicateCriteria<ItemToFilter>(x => accessor(x).CompareTo(property_value) > 0);
            
        }

        public Criteria<ItemToFilter> between(PropertyType start, PropertyType end)
        {
            return new PredicateCriteria<ItemToFilter>(x => new InclusiveRange<PropertyType>(start, end).contains(accessor(x)));
        }
    }

    public class InclusiveRange<T> : Range<T> where T : IComparable<T>
    {
       public InclusiveRange(T start, T end) : base(start, end)
       {}

       public override bool contains(T item)
       {
           return (item.CompareTo(start) >= 0 && item.CompareTo(end) <= 0);
       }
    }

    public abstract class Range<T> where T:IComparable<T>
    {
        
        protected T start;
        protected T end;

        public Range(T start, T end)
        {
            this.start = start;
            this.end = end;
        }

        public abstract bool contains(T item);
        
    }

    public class CriteriaFactory<ItemToFilter, PropertyType>
    {
        public PropertyAccessor<ItemToFilter, PropertyType> accessor;

        public CriteriaFactory(PropertyAccessor<ItemToFilter, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public Criteria<ItemToFilter> equal_to(PropertyType property_value)
        {
            return new PredicateCriteria<ItemToFilter>(x => accessor(x).Equals(property_value));
        }

        public Criteria<ItemToFilter> not_equal_to(PropertyType property_value)
        {
            return new NotCriteria<ItemToFilter>(equal_to(property_value));
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] property_values)
        {
            return new PredicateCriteria<ItemToFilter>(x => new List<PropertyType>(property_values).Contains(accessor(x)));
        }





    }
}