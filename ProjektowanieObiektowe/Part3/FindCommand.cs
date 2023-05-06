using ProjektowanieObiektowe.Part1;
using ProjektowanieObiektowe.Part2;

namespace ProjektowanieObiektowe.Part3;

public class FindCommand : ICommand
{
    public string CommandName => "find";
    public string Args { get; set; }
    
    public void Execute()
    {
        //add excecution
    }
}

public class FindMovieCommand : ICommand
{
    public string CommandName => "movie";
    public string Args { get; set; }
    public void Execute()
    {
        var args = Args.Split(" ");
        Predicate<IMovie> match = movie =>
        {
            for (int i = 2; i < args.Length; i++)
            {
                // zrobic splita po operatorze
                // zrobic slownik majacy jako key operator po ktorym byl split a jako value predykat przyjmujacy propertyname i "value"
                //
                
            }

            return true;
        };

        MyAlgorithm<IMovie>.Find(Part3Test.dataBase.moviesHeap.CreateForwardIterator(), match);
    }
}
