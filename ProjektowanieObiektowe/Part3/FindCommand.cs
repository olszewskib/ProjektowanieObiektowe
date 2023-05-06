using ProjektowanieObiektowe.Part1;
using ProjektowanieObiektowe.Part2;

namespace ProjektowanieObiektowe.Part3;

public class FindCommand : ICommand
{
    public string CommandName => "find";
    public string Args { get; set; }
    protected readonly Dictionary<char,Func<object,object,bool>> options = new Dictionary<char, Func<object, object, bool>>()
    {
        {'=', (x, y) => x.Equals(y)},
        {'<', (x, y) => Comparer<object>.Default.Compare(x, y) < 0},
        {'>', (x, y) => Comparer<object>.Default.Compare(x, y) > 0}
    };

    private readonly IEnumerable<ICommand> availableFindCommands = new ICommand[]
    {
        new FindAuthorCommand(),
        new FindMovieCommand(),
        new FindSeriesCommand(),
        new FindEpisodeCommand(),
    };
    
    public void Execute()
    {
        var args = Args.Split(" ");
        var result = availableFindCommands.FirstOrDefault(com => com.CommandName == args[1]);
        if (result == default)
        {
            Console.WriteLine($"invalid arguments for list function: {args[1]}");
            return;
        }
        result.Args = Args;
        result.Execute();
    }
}

public class FindMovieCommand : ICommand
{
    public string CommandName => "movie";
    public string Args { get; set; }
    protected readonly Dictionary<char,Func<object,object,bool>> options = new Dictionary<char, Func<object, object, bool>>()
    {
        {'=', (x, y) => x.Equals(y)},
        {'<', (x, y) => Comparer<object>.Default.Compare(x, y) < 0},
        {'>', (x, y) => Comparer<object>.Default.Compare(x, y) > 0}
    };

    public void Execute()
    {
        var args = Args.Split(" ");
        Predicate<IMovie> match = movie =>
        {
            var props = new MoviePropertyDictionary(movie);
            for (int i = 2; i < args.Length; i++)
            {
                string criteria = args[i];
                char option = ' ';
                foreach (var c in criteria)
                {
                    if (!char.IsLetterOrDigit(c))
                    {
                        option = c;
                        break;
                    }
                }

                var arguments = criteria.Split(option);
                if (options[option](props.propDictionary[arguments[0]], arguments[1]) == false) return false;
            }

            return true;
        };

        var item = MyAlgorithm<IMovie>.Find(Part3Test.dataBase.moviesHeap.CreateForwardIterator(), match);
        Console.WriteLine(item);
        
    }
}
public class FindAuthorCommand : ICommand
{
    public string CommandName => "author";
    public string Args { get; set; }
    protected readonly Dictionary<char,Func<object,object,bool>> options = new Dictionary<char, Func<object, object, bool>>()
    {
        {'=', (x, y) => x.Equals(y)},
        {'<', (x, y) => Comparer<object>.Default.Compare(x, y) < 0},
        {'>', (x, y) => Comparer<object>.Default.Compare(x, y) > 0}
    };

    public void Execute()
    {
        var args = Args.Split(" ");
        Predicate<IAuthor> match = author =>
        {
            var props = new AuthorPropertyDictionary(author);
            for (int i = 2; i < args.Length; i++)
            {
                string criteria = args[i];
                char option = ' ';
                foreach (var c in criteria)
                {
                    if (!char.IsLetterOrDigit(c))
                    {
                        option = c;
                        break;
                    }
                }

                var arguments = criteria.Split(option);
                if (options[option](props.propDictionary[arguments[0]], arguments[1]) == false) return false;
            }

            return true;
        };

        var item = MyAlgorithm<IAuthor>.Find(Part3Test.dataBase.authorsHeap.CreateForwardIterator(), match);
        Console.WriteLine(item);
        
    }
}
public class FindSeriesCommand : ICommand
{
    public string CommandName => "series";
    public string Args { get; set; }

    protected readonly Dictionary<char,Func<object,object,bool>> options = new Dictionary<char, Func<object, object, bool>>()
    {
        {'=', (x, y) => x.Equals(y)},
        {'<', (x, y) => Comparer<object>.Default.Compare(x, y) < 0},
        {'>', (x, y) => Comparer<object>.Default.Compare(x, y) > 0}
    };
    public void Execute()
    {
        var args = Args.Split(" ");
        Predicate<ISeries> match = series =>
        {
            var props = new SeriesPropertyDictionary(series);
            for (int i = 2; i < args.Length; i++)
            {
                string criteria = args[i];
                char option = ' ';
                foreach (var c in criteria)
                {
                    if (!char.IsLetterOrDigit(c))
                    {
                        option = c;
                        break;
                    }
                }

                var arguments = criteria.Split(option);
                if (options[option](props.propDictionary[arguments[0]], arguments[1]) == false) return false;
            }

            return true;
        };

        var item = MyAlgorithm<ISeries>.Find(Part3Test.dataBase.seriesHeap.CreateForwardIterator(), match);
        Console.WriteLine(item);
        
    }
}

public class FindEpisodeCommand : ICommand
{
    public string CommandName => "episode";
    public string Args { get; set; }

    protected readonly Dictionary<char,Func<object,object,bool>> options = new Dictionary<char, Func<object, object, bool>>()
    {
        {'=', (x, y) => x.Equals(y)},
        {'<', (x, y) => Comparer<object>.Default.Compare(x, y) < 0},
        {'>', (x, y) => Comparer<object>.Default.Compare(x, y) > 0}
    };
    public void Execute()
    {
        var args = Args.Split(" ");
        Predicate<IEpisode> match = episode =>
        {
            var props = new EpisodePropertyDictionary(episode);
            for (int i = 2; i < args.Length; i++)
            {
                string criteria = args[i];
                char option = ' ';
                foreach (var c in criteria)
                {
                    if (!char.IsLetterOrDigit(c))
                    {
                        option = c;
                        break;
                    }
                }

                var arguments = criteria.Split(option);
                if (options[option](props.propDictionary[arguments[0]], arguments[1]) == false) return false;
            }

            return true;
        };

        var item = MyAlgorithm<IEpisode>.Find(Part3Test.dataBase.episodesHeap.CreateForwardIterator(), match);
        Console.WriteLine(item);
        
    }
}
