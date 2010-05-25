namespace nothinbutdotnetprep.utility.searching
{
    //Specification Pattern - Determine whether an object meets a certain condition
    public interface Criteria<T>
    {
        bool is_satisfied_by(T item);
    }
}