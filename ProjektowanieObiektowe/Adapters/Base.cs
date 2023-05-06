namespace ProjektowanieObiektowe.Adapters
{
    
	public class Movie : IMovie
	{
        public string Title { get; set; }
        public string Genre { get; set; }
        public IAuthor Director { get; set; }
        public int ReleaseYear { get; set; }
        public int Duration { get; set; }

        public Movie(){}
        public Movie(string title, string genre, Author director, int releseYear, int duraion)
        {
            Title = title;
            Genre = genre;
            Director = director;
            ReleaseYear = releseYear;
            Duration = duraion;

        }
        public override string ToString()
        {
            return $"Title: {this.Title}, Genre: {this.Genre}, " + $"Director: {this.Director}, ReleseYear: {this.ReleaseYear}, Duration: {this.Duration}";
        }

    }

    public class Series : ISeries
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public IAuthor Showrunner { get; set; }
        public IEpisode[] Episodes { get; set; }

        public Series(string title, string genre, Author showrunner, Episode[] episodes)
        {
            Title = title;
            Genre = genre;
            Showrunner = showrunner;
            Episodes = new IEpisode[episodes.Length];

            for (int i = 0; i < episodes.Length; i++)
                Episodes[i] = episodes[i];

        }
        public override string ToString()
        {
            string episodes ="";
            foreach (var episode in Episodes)
                episodes += episode + "\n";

            return $"Title: {this.Title}, Genre: {this.Genre}, "  + $"Showrunner: {this.Showrunner}" + "\nEpisodes:\n" + episodes;
        }
    }

    public class Author : IAuthor
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int BirthYear { get; set; }
        public int Awards { get; set; }

        public Author(){}
        public Author(string name, string surname, int birthYear, int awards)
        {
            Name = name;
            Surname = surname;
            BirthYear = birthYear;
            Awards = awards;

        }

        public override string ToString()
        {
            return $"Name: {this.Name}, Surname: {this.Surname}, Birth year: {this.BirthYear}";
        }
    }

    public class Episode : IEpisode
    {
        public string Title { get; set; }
        public int Duration { get; set; }
        public int ReleaseYear { get; set; }
        public IAuthor Director { get; set; }

        public Episode() {}
        public Episode(string title, int duration, int releaseYear, Author director)
        {
            Title = title;
            Duration = duration;
            ReleaseYear = releaseYear;
            Director = director;
        }

        public override string ToString()
        {
            return
                $"Title: {this.Title}, Duration: {this.Duration}, ReleaseYear: {this.ReleaseYear}, Director: {this.Director}";
        }
        
    }
	
}

