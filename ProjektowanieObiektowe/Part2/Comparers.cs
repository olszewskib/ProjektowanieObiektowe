using ProjektowanieObiektowe.Part1;

namespace ProjektowanieObiektowe.Part2;

public static class Comparers
{
    public class MovieComparer : IComparer<IMovie>
    {
        public int Compare(IMovie x, IMovie y)
        {
            if (x.Duration < y.Duration) return -1;
            else if (x.Duration > y.Duration) return 1;
            else return 0;
        }
    }

    public class AuthorComparer : IComparer<IAuthor>
    {
        public int Compare(IAuthor x, IAuthor y)
        {
            
            if (x.BirthYear < y.BirthYear) return -1;
            else if (x.BirthYear > y.BirthYear) return 1;
            else return 0;
        }
    }
}