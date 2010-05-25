using System;

namespace nothinbutdotnetprep.utility.searching
{
    public class ComparableCriteriaFactory<ItemToFilter, PropertyType> where PropertyType : IComparable<PropertyType>
    {
        readonly PropertyAccessor<ItemToFilter, PropertyType> accessor;

        public ComparableCriteriaFactory(PropertyAccessor<ItemToFilter, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public bool not { get; set; }

        public Criteria<ItemToFilter> greater_than(PropertyType property_value)
        {
            return new PredicateCriteria<ItemToFilter>(x => accessor(x).CompareTo(property_value) > 0);
        }

        public Criteria<ItemToFilter> between(PropertyType start, PropertyType end)
        {
            return new PredicateCriteria<ItemToFilter>(x => new InclusiveRange<PropertyType>(start, end).contains(accessor(x)));
        }
    }


    public class InverseComparableCriteriaFactory<ItemToFilter, PropertyType> where PropertyType : IComparable<PropertyType>
    {
        readonly PropertyAccessor<ItemToFilter, PropertyType> accessor;
        readonly ComparableCriteriaFactory<ItemToFilter, PropertyType> comparable_criteria_factory;

        public InverseComparableCriteriaFactory(PropertyAccessor<ItemToFilter, PropertyType> accessor, ComparableCriteriaFactory<ItemToFilter, PropertyType> comparable_criteria_factory)
        {
            this.accessor = accessor;
            this.comparable_criteria_factory = comparable_criteria_factory;
        }

        public Criteria<ItemToFilter> greater_than(PropertyType property_value)
        {
            return new PredicateCriteria<ItemToFilter>(x => new NotCriteria<ItemToFilter>(x => accessor(x).CompareTo(property_value) > 0));
        }

        public Criteria<ItemToFilter> between(PropertyType start, PropertyType end)
        {
            return new PredicateCriteria<ItemToFilter>(x => new InclusiveRange<PropertyType>(start, end).contains(accessor(x)));
        }
    }
    
}