namespace ProjektowanieObiektowe.Part3;

// responsible for initializing a request (getting the arguments)
public class Invoker
{
    private CommandFactory commandFactory;

    public Invoker()
    {
        commandFactory = new CommandFactory();
    }

    public void Process(string[] args)
    {
        // arguments parsing
        var command = commandFactory.CreateCommand(args);
        command.Execute();
    }
}