using ProjektowanieObiektowe.Part1;
namespace ProjektowanieObiektowe;

public static class DataBase
{
    // inicjalizacja danych dla reprezentacji bazowej
    public static Author[] authorsBase =
    {
        new Author("Francis", "Coppola", 1939, 32),
        new Author("Steven", "Spielberg", 1956, 73),
        new Author("Charlie", "Chaplin", 1889, 6),
        new Author("Vince", "Gilligan", 1967, 17),
        new Author("Rian", "Johnson", 1973, 29),
        new Author("Greg", "Daniels", 1963, 5),
        new Author("Troy", "Miller", 1960, 0),
        new Author("Victor", "Nelli, Jr.", 1960, 0),
        new Author("Charles", "McDougall", 1960, 0)
    };

    public static Movie[] moviesBase =
    {
        new Movie("Apocalypse now", "war film", authorsBase[0], 147, 1979),
        new Movie("The Godfather", "criminal", authorsBase[0], 175, 1972),
        new Movie("Raiders of the lost ark", "adventure", authorsBase[1], 115, 1981),
        new Movie("The Great Dictator", "comedy", authorsBase[2], 125, 1940)
    };

    public static Episode[] episodesBase =
    {
        new Episode("Fly", 45, 2010, authorsBase[4]),
        new Episode("Ozymandias", 50, 2013, authorsBase[4]),
        new Episode("Pilot", 43, 2008, authorsBase[3]),
        new Episode("Dwight K. Schrute, (Acting) Manager", 22, 2011, authorsBase[6]),
        new Episode("The Carpet", 23, 2006, authorsBase[7]),
        new Episode("Dwight's Speech", 22, 2006, authorsBase[8])
    };

    public static Episode[] episodes0 = { episodesBase[0], episodesBase[1], episodesBase[2] };
    public static Episode[] episodes1 = { episodesBase[3], episodesBase[4], episodesBase[5] };
    
    public static Series[] seriesBase =
    {
        new Series("Breaking Bad", "drama", authorsBase[3], episodes0),
        new Series("The Office US", "horror", authorsBase[5], episodes1)
    };

    
    // inicjalizacja danych dla drugiej reprezentacji
    public static AuthorPairs[] authorsPairs =
    {
        new AuthorPairs("Francis", "Coppola", 1939, 32),
        new AuthorPairs("Steven", "Spielberg", 1956, 73),
        new AuthorPairs("Charlie", "Chaplin", 1889, 6),
        new AuthorPairs("Vince", "Gilligan", 1967, 17),
        new AuthorPairs("Rian", "Johnson", 1973, 29),
        new AuthorPairs("Greg", "Daniels", 1963, 5),
        new AuthorPairs("Troy", "Miller", 1960, 0),
        new AuthorPairs("Victor", "Nelli, Jr.", 1960, 0),
        new AuthorPairs("Charles", "McDougall", 1960, 0)
    };
    
    public static MoviePairs[] moviesPairs = {
        new MoviePairs("Apocalypse now", "war film", authorsPairs[0], 147, 1979),
        new MoviePairs("The Godfather", "criminal", authorsPairs[0], 175, 1972 ),
        new MoviePairs("Raiders of the lost ark", "adventure", authorsPairs[1], 115, 1981),
        new MoviePairs("The Great Dictator", "comedy", authorsPairs[2], 125, 1940),
   };

    public static EpisodePairs[] episodesPairs =
    {
        new EpisodePairs("Fly", 45, 2010, authorsPairs[4]),
        new EpisodePairs("Ozymandias", 50, 2013, authorsPairs[4]),
        new EpisodePairs("Pilot", 43, 2008, authorsPairs[3]),
        new EpisodePairs("Dwight K. Schrute, (Acting) Manager", 22, 2011, authorsPairs[6]),
        new EpisodePairs("The Carpet", 23, 2006, authorsPairs[7]),
        new EpisodePairs("Dwight's Speech", 22, 2006, authorsPairs[8])
    };
    
    public static EpisodePairs[] episodes00 = { episodesPairs[0], episodesPairs[1], episodesPairs[2] };
    public static EpisodePairs[] episodes11 = { episodesPairs[3], episodesPairs[4], episodesPairs[5] };

    public static SeriesPairs[] seriesPairs =
    {
        new SeriesPairs("Breaking Bad", "drama", authorsPairs[3], episodes00),
        new SeriesPairs("The Office US", "horror", authorsPairs[5], episodes11)
    };
}