using ProjektowanieObiektowe.Adapters;
using ProjektowanieObiektowe.Collections;

namespace ProjektowanieObiektowe.CLI;

public class ListCommand : ICommand
{
    public string CommandName => "list";
    public string Args { get; set; }

    private readonly IEnumerable<ICommand> availableListCommands = new ICommand[]
    {
        new ListMoviesCommand(),
        new ListAuthorsCommand(),
        new ListSeriesCommand(),
        new ListEpisodeCommand()
    };

    public void Execute()
    {
        var args = Args.Split(" ");
        var result = availableListCommands.FirstOrDefault(com => com.CommandName == args[1]);
        if (result == default)
        {
            Console.WriteLine($"invalid arguments for list function: {args[1]}");
            return;
        }
        result.Execute();
    }
}

public class ListMoviesCommand : ICommand
{
    public string CommandName => "movies";
    public string Args { get; set; }

    public void Execute()
    {
        var instance = Part3Test.dataBase.moviesHeap;
        MyAlgorithm<IMovie>.Print(instance.CreateForwardIterator());

    }
}

public class ListAuthorsCommand : ICommand
{
    public string CommandName => "authors";
    public string Args { get; set; }

    public void Execute()
    {
        var instance = Part3Test.dataBase.authorsHeap;
        MyAlgorithm<IAuthor>.Print(instance.CreateForwardIterator());

    }
}

public class ListSeriesCommand : ICommand
{
    public string CommandName => "series";
    public string Args { get; set; }

    public void Execute()
    {
        var instance = Part3Test.dataBase.seriesHeap;
        MyAlgorithm<ISeries>.Print(instance.CreateForwardIterator());

    }
}

public class ListEpisodeCommand : ICommand
{
    public string CommandName => "episodes";
    public string Args { get; set; }

    public void Execute()
    {
        var instance = Part3Test.dataBase.episodesHeap;
        MyAlgorithm<IEpisode>.Print(instance.CreateForwardIterator());
    }
}
