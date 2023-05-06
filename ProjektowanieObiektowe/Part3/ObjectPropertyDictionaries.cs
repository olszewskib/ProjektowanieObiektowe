using ProjektowanieObiektowe.Part1;

namespace ProjektowanieObiektowe.Part3;

public class ObjectPropertyDictionaries
{
    public readonly Dictionary<string, object> propDictionary = new();
}

public class MoviePropertyDictionary : ObjectPropertyDictionaries
{
    public MoviePropertyDictionary(IMovie movie)
    {
        propDictionary.Add("Title",movie.Title);
        propDictionary.Add("Genre",movie.Genre);
        propDictionary.Add("ReleaseYear",movie.ReleaseYear.ToString());
        propDictionary.Add("Duration",movie.Duration.ToString());
    }
}

public class AuthorPropertyDictionary : ObjectPropertyDictionaries
{
    public AuthorPropertyDictionary(IAuthor author)
    {
        propDictionary.Add("Name",author.Name);
        propDictionary.Add("Surname",author.Surname);
        propDictionary.Add("BirthYear",author.BirthYear.ToString());
        propDictionary.Add("Awards",author.Awards.ToString());
    }
}

public class SeriesPropertyDictionary : ObjectPropertyDictionaries
{
    public SeriesPropertyDictionary(ISeries series)
    {
        propDictionary.Add("Title",series.Title);
        propDictionary.Add("Genre",series.Genre);
    }
}

public class EpisodePropertyDictionary : ObjectPropertyDictionaries
{
    public EpisodePropertyDictionary(IEpisode episode)
    {
        propDictionary.Add("Title",episode.Title);
        propDictionary.Add("Duration",episode.Duration.ToString());
        propDictionary.Add("ReleaseYear",episode.ReleaseYear.ToString());
    }
}