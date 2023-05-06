using System.Reflection;
using System.Resources;
using System.Threading.Channels;

namespace ProjektowanieObiektowe.Part3;

public static class Part3Test
{
    public static DataBase dataBase;
    
    public static void Run()
    {
        dataBase = new DataBase();
        dataBase.InitHeaps();
        
        var inv = new Invoker();
        Console.WriteLine("Welcome to ProjOb CLI");
        Console.WriteLine("List of available commands:");
        Console.WriteLine("\t [list <name_of_the_class>] (movies,authors,series,episodes)");
        Console.WriteLine("\t [find <name_of_the_class> [<requirements>]] (<name_of_field> =|<|> <value>)");
        Console.WriteLine("\t [add <name_of_the_class> base|sec]");
        Console.WriteLine("\t [help]");
        Console.WriteLine("\t [exit]");
        Console.WriteLine();

        while (true)
        {
            var input = Console.ReadLine();
            var args = input.Split(" ");
            try
            {
                inv.Process(args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }
    }
}