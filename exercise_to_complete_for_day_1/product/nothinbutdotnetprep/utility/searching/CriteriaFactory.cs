using System;

namespace nothinbutdotnetprep.utility.searching
{
    public class CriteriaFactory<ItemToFilter, PropertyType>
    {
        public Func<ItemToFilter, PropertyType> accessor;

        public CriteriaFactory(Func<ItemToFilter, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value)
        {
            return new PropertyCriteria<ItemToFilter, PropertyType>(accessor,
                                                                    new EqualToCriteria<PropertyType>(value));
        }

        public Criteria<ItemToFilter> not_equal_to(PropertyType propertyValue)
        {
            return new NotCriteria<ItemToFilter>(equal_to(propertyValue));
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] property_values)
        {
            return new PropertyCriteria<ItemToFilter, PropertyType>(accessor,
                                                                    new EqualToAnyCriteria<PropertyType>(property_values));
        }
    }
}