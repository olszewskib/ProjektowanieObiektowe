using System.ComponentModel;

namespace ProjektowanieObiektowe;

class Program
{
    static void Main(string[] args)
    {


        var heap =  new MyHeap<int>(Comparer<int>.Default);
        heap.Add(1);
        heap.Add(2);
        heap.Add(3);
        Console.WriteLine(heap);
        heap.Delete(1);
        heap.Delete(3);

        var it = heap.CreateForwardIterator();
        MyAlgorithm<int>.ForEach(it,x=>x+10);




        //Console.WriteLine(res);
    }
}
 