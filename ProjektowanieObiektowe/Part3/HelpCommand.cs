namespace ProjektowanieObiektowe.Part3;

public class HelpCommand : ICommand
{
    public string CommandName => "help";
    public string Args { get; set; }

    public void Execute()
    {
        Console.WriteLine("List of available commands:");
            Console.WriteLine("\t [list <name_of_the_class>] (movies,authors,series,episodes)");
            Console.WriteLine("\t [find <name_of_the_class> [<requirements>]] (<name_of_field> =|<|> <value>)");
            Console.WriteLine("\t [add <name_of_the_class> base|sec]");
            Console.WriteLine("\t [help]");
            Console.WriteLine("\t [exit]");
            Console.WriteLine();
    }
}