using System;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetprep.collections;
using nothinbutdotnetprep.utility.searching;
using Rhino.Mocks;

namespace nothinbutdotnetprep.specs
{
    public abstract class concern_for_property_criteria : Observes<Criteria<Movie>,
                                                              PropertyCriteria<Movie, int>>
    {
    }

    [Subject(typeof(PropertyCriteria<Movie, int>))]
    public class when_determining_whether_it_matches_an_item : concern_for_property_criteria
    {
        Establish c = () =>
        {
            the_movie = new Movie();
            func = x =>
            {
                movie_targeted = x;
                return 2;
            };
            actual_criteria = the_dependency<Criteria<int>>();
            actual_criteria.Stub(x => x.is_satisfied_by(2)).Return(true);
            provide_a_basic_sut_constructor_argument(func);
        };

        Because b = () =>
            result = sut.is_satisfied_by(the_movie);

        It should_make_the_determination_by_using_its_accessor_and_raw_criteria = () => { result.ShouldBeTrue(); };

        static bool result;
        static Func<Movie, int> func;
        static Movie the_movie;
        static Movie movie_targeted;
        static Criteria<int> actual_criteria;
    }
}