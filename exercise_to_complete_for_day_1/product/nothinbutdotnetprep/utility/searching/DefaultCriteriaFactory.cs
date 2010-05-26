using System;

namespace nothinbutdotnetprep.utility.searching
{
    public class DefaultCriteriaFactory<ItemToFilter, PropertyType> : CriteriaFactory<ItemToFilter, PropertyType>
    {
        public Func<ItemToFilter, PropertyType> accessor;

        public DefaultCriteriaFactory(Func<ItemToFilter, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public NotCriteriaFactory<ItemToFilter, PropertyType> not
        {
            get { return new NotCriteriaFactory<ItemToFilter,PropertyType>(this); }
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value)
        {
            return new PropertyCriteria<ItemToFilter, PropertyType>(accessor,
                                                                    new EqualToCriteria<PropertyType>(value));
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] property_values)
        {
            return new PropertyCriteria<ItemToFilter, PropertyType>(accessor,
                                                                    new EqualToAnyCriteria<PropertyType>(property_values));
        }
    }
}