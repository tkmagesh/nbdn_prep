namespace nothinbutdotnetprep.utility.searching
{
    public class NotCriteriaFactory<ItemToFilter, PropertyType> : CriteriaFactory<ItemToFilter, PropertyType>
    {
        CriteriaFactory<ItemToFilter, PropertyType> to_negate;

        public NotCriteriaFactory(CriteriaFactory<ItemToFilter, PropertyType> to_negate)
        {
            this.to_negate = to_negate;
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value)
        {
            return new NotCriteria<ItemToFilter>(to_negate.equal_to(value));
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] property_values)
        {
            return new NotCriteria<ItemToFilter>(to_negate.equal_to_any(property_values));
        }
    }
}