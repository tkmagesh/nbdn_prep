using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.searching
{
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