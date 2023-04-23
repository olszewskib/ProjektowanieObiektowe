using System.Runtime.InteropServices;

namespace ProjektowanieObiektowe.Part2;

public class MyAlgorithm<T>
{
    public static T Find(IMyIterator<T> it, Predicate<T> fun)
    {
        while (it.HasMore())
        {
            if (fun(it.Current)) return it.Current;
            it.MoveNext();
        }

        Console.WriteLine("Not instances found");
        return default;
    }

    public static void Print(IMyIterator<T> it)
    {
        while (it.HasMore())
        {
            Console.WriteLine(it.Current);
            it.MoveNext();
        }
    }
    
    public static void ForEach(IMyIterator<T> it, Func<T,T> fun)
    {
        while (it.HasMore())
        {
            var sth = fun(it.Current);
            Console.WriteLine(sth);
            it.MoveNext();
        }
        
    }
    
    public static int CountIf(IMyIterator<T> it, Predicate<T> fun)
    {
        int count = 0;
        while (it.HasMore())
        {
            if(fun(it.Current)) count++;
            it.MoveNext();
        }
        return count;
    }
}
