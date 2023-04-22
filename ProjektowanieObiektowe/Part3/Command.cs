using ProjektowanieObiektowe.Part1;
using ProjektowanieObiektowe.Part2;

namespace ProjektowanieObiektowe.Part3;

// responsible for creating a command
public class CommandFactory
{
    private readonly IEnumerable<ICommand> availableCommands = new ICommand[]
    {
        new ListCommand()
    };

    public ICommand CreateCommand(string[] args)
    {
        var result = availableCommands.FirstOrDefault(com => com.CommandName == args[0]);
        return result ?? new CommandNotFound { CommandName = args[0] };
    }
}

public class ListCommand : ICommand 
{
    public string CommandName => "list";

    public void Execute()
    {
        var db = new DataBase();
        db.InitHeaps();
        Console.WriteLine("Listing elements...");
        
        var it = db.authorsHeap.CreateForwardIterator();
        MyAlgorithm<IAuthor>.Print(it);
    }
}

public class CommandNotFound : ICommand
{
    public string CommandName { get; set; }

    public void Execute()
    {
        Console.WriteLine("Could not find command of name: " + CommandName);
    }
}