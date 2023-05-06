using ProjektowanieObiektowe.Adapters;

namespace ProjektowanieObiektowe.CLI.AddCommand;

// Movies
public abstract class MovieBuilder
{
    public abstract IMovie Build(string title, string genre, int releaseYear, int duration);
}
public class BaseMovieBuilder : MovieBuilder
{
    public override IMovie Build(string title, string genre, int releaseYear, int duration)
    {
        return new Movie(title, genre, new Author(), releaseYear, duration);
    }
}
public class SecMovieBuilder : MovieBuilder
{
    public override IMovie Build(string title, string genre, int releaseYear, int duration)
    {
        return new MovieAdapter(new MoviePairs(title, genre, new AuthorPairs(), releaseYear, duration));
    }
}

// Authors
public abstract class AuthorBuilder
{
    public abstract IAuthor Build(string name, string surname, int birthYear, int awards);
}

public class BaseAuthorBuilder : AuthorBuilder
{
    public override IAuthor Build(string name, string surname, int birthYear, int awards)
    {
        return new Author(name, surname, birthYear, awards);
    }
}
public class SecAuthorBuilder : AuthorBuilder
{
    public override IAuthor Build(string name, string surname, int birthYear, int awards)
    {
        return new AuthorAdapter(new AuthorPairs(name, surname, birthYear, awards));
    }
}

// Episodes
public abstract class EpisodeBuilder
{
    public abstract IEpisode Build(string title, int duration, int releaseYear);
}
public class BaseEpisodeBuilder : EpisodeBuilder
{
    public override IEpisode Build(string title, int duration, int releaseYear)
    {
        return new Episode(title, duration, releaseYear, new Author());
    }
}
public class SecEpisodeBuilder : EpisodeBuilder
{
    public override IEpisode Build(string title, int duration, int releaseYear)
    {
        return new EpisodesAdapter(new EpisodePairs(title, duration, releaseYear, new AuthorPairs()));
    }
}

// Series
public abstract class SeriesBuilder
{
    public abstract ISeries Build(string title, string genre);
}
public class BaseSeriesBuilder : SeriesBuilder
{
    public override ISeries Build(string title, string genre)
    {
        return new Series(title, genre, new Author(), Array.Empty<Episode>());
    }
}
public class SecSeriesBuilder : SeriesBuilder
{
    public override ISeries Build(string title, string genre)
    {
        return new SeriesAdapter(new SeriesPairs(title, genre, new AuthorPairs(), Array.Empty<EpisodePairs>()));
    }
}
