using System.Runtime.CompilerServices;
using ProjektowanieObiektowe.Part1;
using ProjektowanieObiektowe.Part2;

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

    public void Execute()
    {
        var db = new DataBase();
        var args = Args.Split(" ");
        db.InitHeaps();
        var type = typeof(IMovie);
        

        Console.WriteLine("Listing elements...");
        Console.WriteLine(db.Heaps[args[1]]);
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