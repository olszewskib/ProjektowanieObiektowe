namespace ProjektowanieObiektowe.Adapters;

public interface IMovie
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public IAuthor Director { get; set; }
    public int ReleaseYear { get; set; }
    public int Duration { get; set; }
}

public interface ISeries
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public IAuthor Showrunner { get; set; }
    public IEpisode[] Episodes { get; set; }
}

public interface IAuthor
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int BirthYear { get; set; }
    public int Awards { get; set; }
}

public interface IEpisode
{
    public string Title { get; set; }
    public int Duration { get; set; }
    public int ReleaseYear { get; set; }
    public IAuthor Director { get; set; }
}