using System.Runtime.CompilerServices;
using ProjektowanieObiektowe.Part1;
using ProjektowanieObiektowe.Part2;
using ProjektowanieObiektowe.Part3;

namespace ProjektowanieObiektowe.Part3;

// responsible for creating a command
public class CommandFactory
{
    private string[] args;
    
    private readonly IEnumerable<ICommand> availableCommands = new ICommand[]
    {
        new ListCommand(),
        new ExitCommand()
    };

    public ICommand CreateCommand(string[] args)
    {
        var result = availableCommands.FirstOrDefault(com => com.CommandName == args[0]);
        result.Args = string.Join(" ", args);
        return result ?? new CommandNotFound { CommandName = args[0] };
    }
}

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

public class FindCommand : ICommand
{
    public string CommandName => "find";
    public string Args { get; set; }
    
    public void Execute()
    {
        //add excecution
    }
}

public class FindMovieCommand : ICommand
{
    public string CommandName => "movie";
    public string Args { get; set; }
    public void Execute()
    {
        var args = Args.Split(" ");
        Predicate<IMovie> match = movie =>
        {
            for (int i = 2; i < args.Length; i++)
            {
                // zrobic splita po operatorze
                // zrobic slownik majacy jako key operator po ktorym byl split a jako value predykat przyjmujacy propertyname i "value"
                //
                
            }

            return true;
        };

        MyAlgorithm<IMovie>.Find(Part3Test.dataBase.moviesHeap.CreateForwardIterator(), match);
    }
}

public class ExitCommand : ICommand
{
    public string CommandName => "exit";
    public string Args { get; set; }
    public void Execute()
    {
        throw new Exception("exiting program");
    }
}

public class CommandNotFound : ICommand
{
    public string CommandName { get; set; }
    public string Args { get; set; }

    public void Execute()
    {
        Console.WriteLine("Could not find command of name: " + CommandName);
    }
}