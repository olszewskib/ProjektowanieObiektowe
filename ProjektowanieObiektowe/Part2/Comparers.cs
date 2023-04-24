using ProjektowanieObiektowe.Part1;

namespace ProjektowanieObiektowe.Part2;

public static class Comparers
{
    public class MovieComparer : IComparer<IMovie>
    {
        public int Compare(IMovie? x, IMovie? y)
        {
            if (y != null && x != null && x.Duration < y.Duration) return -1;
            else if (y != null && x != null && x.Duration > y.Duration) return 1;
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

    public class EpisodeComparer : IComparer<IEpisode>
    {
        public int Compare(IEpisode x, IEpisode y)
        {
            if (x.Director.BirthYear < y.Director.BirthYear) return -1;
            else if (x.Director.BirthYear > y.Director.BirthYear) return 1;
            else return 0;
        }
    }

    public class SeriesComparer : IComparer<ISeries>
    {
        public int Compare(ISeries x, ISeries y)
        {
            if (x.Showrunner.Awards < y.Showrunner.Awards) return -1;
            else if (x.Showrunner.Awards > y.Showrunner.Awards) return 1;
            else return 0;
        }
    }
}