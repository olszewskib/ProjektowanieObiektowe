namespace ProjektowanieObiektowe.Part2;

public interface IMyIterator<out T>
{
    T Current { get; }
    bool MoveNext();
    bool HasMore();
}

public class VecForwardIterator<T> : IMyIterator<T>
{
    private MyVector<T> vec;
    private int currentPosition;

    public T Current => vec[currentPosition];
    
    public VecForwardIterator(MyVector<T> collection)
    {
        vec = collection;
        currentPosition = 0;
    }

    public bool MoveNext()
    {
        if (!HasMore()) return false;
        
        currentPosition++;
        return true;

    }

    public bool HasMore()
    {
        return currentPosition < vec.Length;
    }
    
}

public class VecReverseIterator<T> : IMyIterator<T>
{
    private MyVector<T> vec;
    private int currentPosition;

    public T Current => vec[currentPosition];
    
    public VecReverseIterator(MyVector<T> collection)
    { 
        vec = collection;
        currentPosition = vec.Length > 0 ? vec.Length-1 : 0; 
    }

    public bool MoveNext()
    {
        if (!HasMore()) return false;

        currentPosition--;
        return true;
    }

    public bool HasMore()
    {
        return currentPosition > 0;
    }
}

public class DllForwardIterator<T> : IMyIterator<T>
{
    private MyDLL<T> list;
    private MyDLL<T>.node cNode;

    public DllForwardIterator(MyDLL<T> list)
    {
        this.list = list;
        cNode = list.Head;
    }

    public T Current => cNode.val;
    public bool MoveNext()
    {
        if (cNode.next != null)
        {
            cNode = cNode.next;
            return true;
        }

        return false;
    }

    public bool HasMore()
    {
        return cNode.next != null;
    }
}

public class DllReverseIterator<T> : IMyIterator<T>
{
    private MyDLL<T> list;
    private MyDLL<T>.node cNode;

    public DllReverseIterator(MyDLL<T> list)
    {
        this.list = list;
        cNode = list.Tail;
    }

    public T Current => cNode.val;
    public bool MoveNext()
    {
        if (cNode.prev != null)
        {
            cNode = cNode.prev;
            return true;
        }

        return false;
    }

    public bool HasMore()
    {
        return cNode.prev != null;
    }
}

public class HeapForwardIterator<T> : IMyIterator<T>
{

    private MyHeap<T> heap;
    private int currentPostition;

    public T Current => heap[currentPostition];
    
    public HeapForwardIterator(MyHeap<T> heap)
    {
        this.heap = heap;
        currentPostition = 1;
    }

    public bool MoveNext()
    {
        if (!HasMore()) return false;
        
        currentPostition++;
        return true;

    }

    public bool HasMore()
    {
        return currentPostition < heap.Length;
    }
}

public class HeapReverseIterator<T> : IMyIterator<T>
{
    private MyHeap<T> heap;
    private int currenntPosition;

    public T Current => heap[currenntPosition];
    
    public HeapReverseIterator(MyHeap<T> heap)
    {
        this.heap = heap;
        currenntPosition = heap.Length-1;
    }

    public bool MoveNext()
    {
        if (!HasMore()) return false;

        currenntPosition--;
        return true;
    }

    public bool HasMore()
    {
        return currenntPosition > 1;
    }
}