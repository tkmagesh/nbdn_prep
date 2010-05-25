using System;

namespace nothinbutdotnetprep.utility.searching
{
    public class ComparableCriteriaFactory<ItemToFilter, PropertyType> where PropertyType : IComparable<PropertyType>
    {
        PointerToAProperty<ItemToFilter, PropertyType> accessor;

        public ComparableCriteriaFactory(PointerToAProperty<ItemToFilter, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public Criteria<ItemToFilter> greater_than(PropertyType property_value)
        {
            return
                new PredicateCriteria<ItemToFilter>(x => accessor(x).CompareTo(property_value) > 0);
        }

        public Criteria<ItemToFilter> between(PropertyType start, PropertyType end)
        {
            return
                new PredicateCriteria<ItemToFilter>(
                    x => 
                        accessor(x).CompareTo(start) >= 0 &&
                        accessor(x).CompareTo(end) <= 0);
        }
    }
}