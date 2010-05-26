namespace nothinbutdotnetprep.utility.searching
{
    public interface CriteriaFactory<ItemToFilter, PropertyType>
    {
        Criteria<ItemToFilter> equal_to(PropertyType value);
        Criteria<ItemToFilter> equal_to_any(params PropertyType[] property_values);
    }
}