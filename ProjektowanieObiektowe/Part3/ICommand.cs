namespace ProjektowanieObiektowe.Part3;

public interface ICommand
{
    string CommandName { get; }
    string Args { get; set; }
    void Execute();
}