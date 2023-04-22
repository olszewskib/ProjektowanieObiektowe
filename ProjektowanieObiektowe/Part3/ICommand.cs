namespace ProjektowanieObiektowe.Part3;

public interface ICommand
{
    string CommandName { get; }
    void Execute();
}