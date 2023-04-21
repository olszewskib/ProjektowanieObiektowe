using ProjektowanieObiektowe.Part1;
using ProjektowanieObiektowe.Part2;

namespace ProjektowanieObiektowe;

class Program
{
    static void Main(string[] args)
    {


        var heap =  new MyHeap<int>(Comparer<int>.Default);
        heap.Add(1);
        heap.Add(2);
        heap.Add(3);
        heap.Add(4);
        heap.Add(5);
        Console.WriteLine(heap);
        heap.Delete(1);
        heap.Delete(3);
        heap.Delete(5);
        Console.WriteLine(heap);

        var it = heap.CreateForwardIterator();
        MyAlgorithm<int>.ForEach(it,x=>x+10);

        Console.WriteLine();
        Part2Test.Run();



        //Console.WriteLine(res);
    }
}
 