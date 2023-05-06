namespace ProjektowanieObiektowe.Part3;

public class CommandFactory
{
    private readonly IEnumerable<ICommand> availableCommands = new ICommand[]
    {
        new ListCommand(),
        new ExitCommand(),
        new FindCommand(),
        new AddCommand(),
        new HelpCommand(),
    };

    public ICommand CreateCommand(string[] args)
    {
        var result = availableCommands.FirstOrDefault(com => com.CommandName == args[0]);
        result.Args = string.Join(" ", args);
        return result ?? new CommandNotFound { CommandName = args[0] };
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