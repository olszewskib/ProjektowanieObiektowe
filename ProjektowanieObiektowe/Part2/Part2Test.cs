using ProjektowanieObiektowe.Part1;

namespace ProjektowanieObiektowe.Part2;

public class Part2Test
{
    public static void Run()
    {
        var authorHeap = new MyHeap<IMovie>(new Comparers.MovieComparer());
        
        foreach (var movie in DataBase.moviesPairs)
        {
            var adapter = new MovieAdapter(movie);
            authorHeap.Add(adapter);
        }

        Console.WriteLine(authorHeap);
        
    }
}