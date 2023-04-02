namespace ProjektowanieObiektowe;

public static class MyAlgorithm<T>
{
    // direction = true -> from beginning, direction = false -> from end

    public static T Find(IMyCollections<T> collection, Func<T, bool> fun, bool direction)
    {
        var it = direction ? collection.CreateForwardIterator() : collection.CreateReverseIterator();
        while (it.HasMore())
        {
            if (fun(it.Current)) return it.Current;
            it.MoveNext();
        }

        if (fun(it.Current)) return it.Current;
        return default;
    }

    public static void Print(IMyCollections<T> collection, Func<T, bool> fun, bool direction)
    {
        var it = direction ? collection.CreateForwardIterator() : collection.CreateReverseIterator();
        while (it.HasMore())
        {
            if (fun(it.Current)) Console.WriteLine(it.Current);
            it.MoveNext();
        }
        
        if (fun(it.Current)) Console.WriteLine(it.Current);
    }

}
