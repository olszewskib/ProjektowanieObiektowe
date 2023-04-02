namespace ProjektowanieObiektowe;

public class MoviePairs
{
    public readonly List<Tuple<string, object>> Movies = new();

    public MoviePairs(string title, string genre, AuthorPairs author, int releaseYear, int duration)
    {
        Movies.Add(new Tuple<string, object>("Title", title));
        Movies.Add(new Tuple<string, object>("Genre", genre));
        Movies.Add(new Tuple<string, object>("Director", author));
        Movies.Add(new Tuple<string, object>("ReleaseYear", releaseYear));
        Movies.Add(new Tuple<string, object>("Duration", duration));
        
    }
}

public class AuthorPairs
{
    public readonly List<Tuple<string, object>> Authors = new();
    
    public AuthorPairs(string name, string surname, int birthYear, int awards)
    {
        Authors.Add(new Tuple<string, object>("Name", name));
        Authors.Add(new Tuple<string, object>("Surname", surname));
        Authors.Add(new Tuple<string, object>("BirthYear", birthYear));
        Authors.Add(new Tuple<string, object>("Awards", awards));
    }
}

public class EpisodePairs
{
    public readonly List<Tuple<string, object>> Episodes = new();
    
    public EpisodePairs(string title, int duration, int releaseYear, AuthorPairs author)
    {
        Episodes.Add(new Tuple<string, object>("Title", title));
        Episodes.Add(new Tuple<string, object>("Duration", duration));
        Episodes.Add(new Tuple<string, object>("ReleaseYear", releaseYear));
        Episodes.Add(new Tuple<string, object>("Director", author));
    }
}

public class SeriesPairs
{
    public readonly List<Tuple<string, object>> Series = new();
    
    public SeriesPairs(string title, string genre, AuthorPairs showrunner, EpisodePairs[] episodes)
    {
        Series.Add(new Tuple<string, object>("Title", title));
        Series.Add(new Tuple<string, object>("Genre", genre));
        Series.Add(new Tuple<string, object>("Showrunner", showrunner));
        Series.Add(new Tuple<string, object>("Episodes", episodes));
    }
}
