using System.ComponentModel;

namespace ProjektowanieObiektowe;

class Program
{
    static void Main(string[] args)
    {


        var list = new MyDLL<int>();

        Console.WriteLine(list);
        
        list.Add(1);
        list.Add(-22);
        list.Add(-3);
        list.Add(12);

        Console.WriteLine(list);
        
     

        MyAlgorithm<int>.Print(list, x => x < 0, true);
        //Console.WriteLine(res);
    }
}
 