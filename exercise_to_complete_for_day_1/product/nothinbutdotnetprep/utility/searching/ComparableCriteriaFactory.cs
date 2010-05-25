using System;
using nothinbutdotnetprep.utility.ranges;

namespace nothinbutdotnetprep.utility.searching
{
    public class ComparableCriteriaFactory<ItemToFilter, PropertyType> where PropertyType : IComparable<PropertyType>
    {
        Func<ItemToFilter, PropertyType> accessor;

        public ComparableCriteriaFactory(Func<ItemToFilter, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public Criteria<ItemToFilter> greater_than(PropertyType property_value)
        {
            return new PropertyCriteria<ItemToFilter, PropertyType>(x => default(PropertyType),
                                                                    new GreaterThanCriteria<PropertyType>(property_value));
        }

        public Criteria<ItemToFilter> between(PropertyType start, PropertyType end)
        {
            return new PropertyCriteria<ItemToFilter, PropertyType>(accessor,
            new FallsInRangeCriteria<PropertyType>(
                new RangeWithNoUpperBound<PropertyType>()));
        }
    }
}