using System;

namespace nothinbutdotnetprep.utility.searching
{
    public class FuncCriteria<T> : Criteria<T>
    {
        Func<T,bool> actual_criteria;

        public FuncCriteria(Func<T,bool > actual_criteria)
        {
            this.actual_criteria = actual_criteria;
        }

        public bool is_satisfied_by(T item)
        {
            return actual_criteria(item);
        }
    }
}