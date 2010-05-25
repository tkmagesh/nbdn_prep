using System;
using System.Collections.Generic;
using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.utility.sorting
{
    public class MovieDateComparer : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            //0  = sort same
            //<0 = x < y
            //>0 = x > y
            return x.date_published.CompareTo(y.date_published);
        }
    }
}