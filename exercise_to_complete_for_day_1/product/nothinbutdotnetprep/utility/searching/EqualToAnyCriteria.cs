using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.searching
{
    public class EqualToAnyCriteria<T> : Criteria<T>
    {
        IList<T> values;

        public EqualToAnyCriteria(IEnumerable<T> values)
        {
            this.values = new List<T>(values);
        }

        public bool is_satisfied_by(T item)
        {
            return values.Contains(item);
        }
    }
}