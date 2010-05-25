using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.searching
{
    public class CriteriaFactory<ItemToFilter, PropertyType>
    {
        public PointerToAProperty<ItemToFilter, PropertyType> accessor;

        public CriteriaFactory(PointerToAProperty<ItemToFilter, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public Criteria<ItemToFilter> equal_to(PropertyType propertyValue)
        {
            return new PredicateCriteria<ItemToFilter>(x => accessor(x).Equals(propertyValue));
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] propertyValues)
        {
            return new PredicateCriteria<ItemToFilter>(x =>
            {
                return
                    new List<PropertyType>(propertyValues).Contains(
                        accessor(x));
            });
        }
    }
}