using ProjektowanieObiektowe.Part1;

namespace ProjektowanieObiektowe.Part2;

public class Part2Test
{
    public static void Run()
    {
        var authorHeap = new MyHeap<ISeries>(new Comparers.SeriesComparer());
        var it = authorHeap.CreateForwardIterator();
        

        foreach (var series in DataBase.seriesPairs)
        {
            var adapter = new SeriesAdapter(series);
            authorHeap.Add(adapter);
        }

        Predicate<ISeries> predicate = Test;
        
        var serie = MyAlgorithm<ISeries>.Find(it,predicate);
        //Console.WriteLine(i);
        //Console.WriteLine();
        Console.WriteLine(serie);
        
    }

    public static bool Test(ISeries series)
    {
        if (series.Showrunner.Awards == 5 ) return true;
        return false;
    }
}