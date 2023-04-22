using System.Reflection;

namespace ProjektowanieObiektowe.Part3;

public static class Part3Test
{
    public static void Run()
    {
        var inv = new Invoker();
        var input = Console.ReadLine();
        string[] args = { input };
        inv.Process(args);
        
    }
}