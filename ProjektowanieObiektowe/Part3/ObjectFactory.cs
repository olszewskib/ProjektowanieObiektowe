using System.Reflection.Metadata;

namespace ProjektowanieObiektowe.Part3;

public abstract class ObjectFactory
{
   public readonly Dictionary<string, string> propDictionary = new();
   public string Representation { get; set; }
   public abstract void Add();

   public void ShowOptions()
   {
      Console.Write("[Available fields: ");
      foreach(var prop in propDictionary.Keys)
         Console.Write(prop + ", ");
      Console.WriteLine("]");
   }

   public bool DeclareProperty(string name, string value)
   {
      if (!propDictionary.ContainsKey(name)) return false;
      propDictionary[name] = value;
      return true;
   }
   
}

public class MovieFactory : ObjectFactory
{
   public MovieFactory()
   {
      propDictionary.Add("Title","");
      propDictionary.Add("Genre","");
      propDictionary.Add("ReleaseYear","");
      propDictionary.Add("Duration","");
   }

   private readonly Dictionary<string,MovieBuilder> availableMovieBuilders = new Dictionary<string, MovieBuilder>()
   {
      {"base",new BaseMovieBuilder()},
      {"sec",new SecMovieBuilder()}
   };

   public override void Add()
   {
      var movie = availableMovieBuilders[Representation].Build(
         propDictionary["Title"],
         propDictionary["Genre"],
         int.Parse(propDictionary["ReleaseYear"]),
         int.Parse(propDictionary["Duration"]));
      
      Part3Test.dataBase.moviesHeap.Add(movie);
   }
}

public class AuthorFactory : ObjectFactory
{
   public AuthorFactory()
   {
      propDictionary.Add("Name",String.Empty);
      propDictionary.Add("Surname",String.Empty);
      propDictionary.Add("BirthYear",String.Empty);
      propDictionary.Add("Awards",String.Empty);
   }
   
   private readonly Dictionary<string,AuthorBuilder> availableAuthorBuilders = new Dictionary<string, AuthorBuilder>()
   {
      {"base",new BaseAuthorBuilder()},
      {"sec",new SecAuthorBuilder()}
   };

   public override void Add()
   {
      var author = availableAuthorBuilders[Representation].Build(
         propDictionary["Title"],
         propDictionary["Surname"],
         int.Parse(propDictionary["BirthYear"]),
         int.Parse(propDictionary["Awards"]));
      
      Part3Test.dataBase.authorsHeap.Add(author);
   }
}

public class EpisodeFactory : ObjectFactory
{
   public EpisodeFactory()
   {
      propDictionary.Add("Title",string.Empty);
      propDictionary.Add("Duration",string.Empty);
      propDictionary.Add("ReleaseYear",string.Empty);
   }

   private readonly Dictionary<string, EpisodeBuilder> availableEpisodeBuilders =
      new Dictionary<string, EpisodeBuilder>()
      {
         { "base", new BaseEpisodeBuilder() },
         { "sec", new SecEpisodeBuilder() },
      };
   
   public override void Add()
   {
      var episode = availableEpisodeBuilders[Representation].Build(
         propDictionary["Title"],
         int.Parse(propDictionary["Duration"]),
         int.Parse(propDictionary["ReleaseYear"]));
      
      Part3Test.dataBase.episodesHeap.Add(episode);
   }
   
}

public class SeriesFactory : ObjectFactory
{
   public SeriesFactory()
   {
      propDictionary.Add("Title",string.Empty);
      propDictionary.Add("Genre",string.Empty);
   }
   
   private readonly Dictionary<string, SeriesBuilder> availableSeriesBuilders =
      new Dictionary<string, SeriesBuilder>()
      {
         { "base", new BaseSeriesBuilder() },
         { "sec", new SecSeriesBuilder() },
      };
   
   public override void Add()
   {
      var series = availableSeriesBuilders[Representation].Build(
         propDictionary["Title"],
         propDictionary["Genre"]);
      
      Part3Test.dataBase.seriesHeap.Add(series);
   }
}