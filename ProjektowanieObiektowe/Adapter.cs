namespace ProjektowanieObiektowe;

public class MovieAdapter : IMovie
{
    private readonly MoviePairs _element;

    public string Title
    {
        get
        {
            string ?title = "";
            foreach (var field in _element.Movies.Where(field => field.Item1 == "Title"))
            {
                title = field.Item2 as string;
            }

            return title;
        }
        set{}
    }

    public string Genre
    {
        get
        {
            string genre="";
            foreach (var field in _element.Movies.Where(field => field.Item1 == "Genre"))
            {
                genre = field.Item2 as string;
            }

            return genre;
        }
        set{}
    }

    public IAuthor Director
    {
        get
        {
            AuthorPairs ?director = null;
            foreach (var field in _element.Movies.Where(field => field.Item1 == "Director"))
            {
                director = field.Item2 as AuthorPairs;
            }

            return new AuthorAdapter(director);
        }

        set {}
    }

    public int ReleaseYear
    {
        get
        {
            int releaseYear = 0;
            foreach (var field in _element.Movies.Where(field => field.Item1 == "ReleaseYear"))
            {
                releaseYear = (int)field.Item2;
            }

            return releaseYear;
        }
        set{}
    }

    public int Duration
    {
        get
        {
            int duration = 0;
            foreach (var field in _element.Movies.Where(field => field.Item1 == "Duration"))
            {
                duration = (int)field.Item2;
            }

            return duration;
        }
        set{}
    }

    public MovieAdapter(MoviePairs element)
    {
        _element = element;
    }
}

public class EpisodesAdapter : IEpisode
{
    private readonly EpisodePairs _element;

    public string Title
    {
        get
        {
            string ?title="";
            foreach (var field in _element.Episodes.Where(field => field.Item1 == "Title"))
            {
                title = field.Item2 as string;
            }

            return title;
        }
        set{}
    }

    public int Duration
    {
        get
        {
            int duration = 0;
            foreach (var field in _element.Episodes.Where(field => field.Item1 == "Duration"))
            {
                duration = (int)field.Item2;
            }

            return duration;
        }
        set{}
    }

    public int ReleaseYear
    {
        get
        {
            int releaseYear = 0;
            foreach (var field in _element.Episodes.Where(field => field.Item1 == "ReleaseYear"))
            {
                releaseYear = (int)field.Item2;
            }

            return releaseYear;
        }
        set{}
    }

    public IAuthor Director
    {
        get
        {
            AuthorPairs ?director = null;
            foreach (var field in _element.Episodes.Where(field => field.Item1 == "Director"))
            {
                director = field.Item2 as AuthorPairs;
            }

            return new AuthorAdapter(director);
        }
        set{}
    }

    public EpisodesAdapter(EpisodePairs element)
    {
        _element = element;
    }
}

public class SeriesAdapter : ISeries
{
    private readonly SeriesPairs _element;

    public string Title
    {
        get
        {
            string ?title="";
            foreach (var field in _element.Series.Where(field => field.Item1 == "Title"))
            {
                title = field.Item2 as string;
            }

            return title;
        }
        set{}
    }

    public string Genre
    {
        get
        {
            string ?genre="";
            foreach (var field in _element.Series.Where(field => field.Item1 == "Genre"))
            {
                genre = field.Item2 as string;
            }

            return genre;
        }
        set{}
    }

    public IAuthor Showrunner
    {
        get
        {
            AuthorPairs ?showrunner = null;
            foreach (var field in _element.Series.Where(field => field.Item1 == "Showrunner"))
            {
                showrunner = field.Item2 as AuthorPairs;
            }

            return new AuthorAdapter(showrunner);
        }
        set{}
    }

    public IEpisode[] Episodes
    {
        get
        {
            EpisodePairs[] ?episodes = null;
            foreach (var field in _element.Series.Where(field => field.Item1 == "Episodes"))
            {
                episodes = field.Item2 as EpisodePairs[];
            }

            var result = new List<IEpisode>();

            foreach (var ep in episodes)
            {
                result.Add(new EpisodesAdapter(ep));
            }

            return result.ToArray();
        }
        set{}
    }

    public SeriesAdapter(SeriesPairs element)
    {
        _element = element;
    }
}

public class AuthorAdapter : IAuthor
{
    private readonly AuthorPairs _element;
    
    public string Name
    {
        get
        {
            string ?name="";
            foreach (var field in _element.Authors.Where(field => field.Item1 == "Name"))
            {
                name = field.Item2 as string;
            }

            return name;
        }
        set{}
    }

    public string Surname
    {
        get
        {
            string ?surname="";
            foreach (var field in _element.Authors.Where(field => field.Item1 == "Surname"))
            {
                surname = field.Item2 as string;
            }

            return surname;
        }
        set{}
    }

    public int BirthYear
    {
        get
        {
            int birthYear = 0;
            foreach (var field in _element.Authors.Where(field => field.Item1 == "BirthYear"))
            {
                birthYear = (int)field.Item2;
            }

            return birthYear;
        }
        set{}
    }

    public int Awards
    {
        get
        {
            int awards = 0;
            foreach (var field in _element.Authors.Where(field => field.Item1 == "Awards"))
            {
                awards = (int)field.Item2;
            }

            return awards;
        }
        set{}
    }

    public AuthorAdapter(AuthorPairs element)
    {
        _element = element;
    }
}