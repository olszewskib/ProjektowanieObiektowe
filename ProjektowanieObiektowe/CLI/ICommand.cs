namespace ProjektowanieObiektowe.CLI;

public interface ICommand
{
    string CommandName { get; }
    string Args { get; set; }
    void Execute();
}