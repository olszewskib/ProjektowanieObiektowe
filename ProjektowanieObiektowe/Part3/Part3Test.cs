using System.Reflection;

namespace ProjektowanieObiektowe.Part3;

public static class Part3Test
{
    public static DataBase dataBase;
    
    public static void Run()
    {
        dataBase = new DataBase();
        dataBase.InitHeaps();
        
        var inv = new Invoker();

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