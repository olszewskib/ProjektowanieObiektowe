namespace ProjektowanieObiektowe.Part3;

public class ExitCommand : ICommand
{
    public string CommandName => "exit";
    public string Args { get; set; }
    public void Execute()
    {
        throw new Exception("exiting program");
    }
}
