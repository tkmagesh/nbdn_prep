using System.Collections.Generic;
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
            //return new PredicateCriteria<ItemToFilter>(x => !accessor(x).Equals(propertyValue));
            return new NotCriteria<ItemToFilter>(equal_to(property_value));
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] property_values)
        {
            return new PredicateCriteria<ItemToFilter>(x => new List<PropertyType>(property_values).Contains(accessor(x)));

            /* return new PredicateCriteria<ItemToFilter>(x =>
             {
                 foreach (var propertyValue in propertyValues)
                 {
                     if (accessor(x).Equals(propertyValue))
                         return true;
                 }
                 return false;
             });*/
        }





    }
}