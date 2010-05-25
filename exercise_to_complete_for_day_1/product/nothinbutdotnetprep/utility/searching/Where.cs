using System;

namespace nothinbutdotnetprep.utility.searching
{
    public delegate PropertyType PointerToAProperty<ItemToFilter, PropertyType>(ItemToFilter item);

    public class Where<ItemToFilter>
    {
        public static ComparableCriteriaFactory<ItemToFilter, PropertyType> has_an<PropertyType>(
            PointerToAProperty<ItemToFilter, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            return new ComparableCriteriaFactory<ItemToFilter, PropertyType>(accessor);
        }

        public static CriteriaFactory<ItemToFilter, PropertyType> has_a<PropertyType>(
            PointerToAProperty<ItemToFilter, PropertyType> accessor)
        {
            return new CriteriaFactory<ItemToFilter, PropertyType>(accessor);
        }
    }
}