namespace ProjektowanieObiektowe.Collections;

public interface IMyCollections<T>
{
    void Add(T item);
    void Delete(T item);
    IMyIterator<T> CreateForwardIterator(); // wartosc zwracana musi byc interfejsem aby mozna bylo zwracac rozne iteratory
    IMyIterator<T> CreateReverseIterator();

}


public class MyVector<T> : IMyCollections<T>
{
    private T[] elements;
    public int Length => elements.Length;

    public MyVector()
    {
        elements = Array.Empty<T>();
    }

    public T this[int index]
    {
        get => elements[index];
        set => elements[index] = value;
    }

    public void Add(T item)
    {
        var len = elements.Length;
        var tmp = new T[len + 1];
        Array.Copy(elements,tmp,len);
        tmp[len] = item;
        elements = tmp;
    }

    public void Delete(T item)
    {
        if (elements.Contains(item) == false || elements.Length == 0) throw new Exception("Element not in Collection");
        var tmp = new T[elements.Length - 1];
        var j = 0;
        foreach (var t in elements)
        {
            if(t.Equals(item)) continue;
            tmp[j++] = t;
        }

        elements = tmp;
    }

    public IMyIterator<T> CreateForwardIterator()
    {
        return new VecForwardIterator<T>(this);
    }

    public IMyIterator<T> CreateReverseIterator()
    {
        return new VecReverseIterator<T>(this);
    }

    public override string ToString()
    {
        if (elements.Length == 0) return "empty vector";

        string items = "";
        foreach (var element in elements)
            items += element.ToString();

        return items;
    }
}

public class MyDLL<T> : IMyCollections<T>
{
    public class node
    {
        public T val;
        public node? next;
        public node? prev;

        public node(T val)
        {
            this.val = val;
            this.next = null;
            this.prev = null;
        }
    }

    public node? Head { get; set; }
    public node? Tail { get; set; }

    public MyDLL()
    {
        Head = null;
        Tail = null;
    }

    public void Add(T item)
    {
        var tmp = new node(item);
        if (Head == Tail && Head == null)
        {
            Head = tmp;
            Tail = tmp;
            return;
        }

        Tail.next = tmp;
        tmp.prev = Tail;
        Tail = tmp;

    }

    public void Delete(T item)
    {
        if (Head == null) return;

        if (Head.val.Equals(item) && Tail.val.Equals(item))
        {
            Head = null;
            Tail = null;
            return;
        }
        
        if (Head.val.Equals(item))
        {
            Head.next.prev = null;
            Head = Head.next;
            return;
        }

        if (Tail.val.Equals(item))
        {
            Tail.prev.next = null;
            Tail = Tail.prev;
            return;
        }

        var tmp = Head.next;

        while(tmp != null)
        {
            if (tmp.val.Equals(item))
            {
                tmp.prev.next = tmp.next;
                tmp.next.prev = tmp.prev;
                return;
            }
        }

    }

    public IMyIterator<T> CreateForwardIterator()
    {
        return new DllForwardIterator<T>(this);
    }

    public IMyIterator<T> CreateReverseIterator()
    {
        return new DllReverseIterator<T>(this);
    }

    public override string ToString()
    {
        if (Head == null) return "empty list";

        string ret = "null";
        var tmp = Head;

        while (tmp!= null)
        {
            ret += $"<->{tmp.val}";
            tmp = tmp.next;
        }

        ret += "<->null";
        return ret;
    }
}

public class MyHeap<T> : IMyCollections<T>
{
    private IComparer<T> comparer;
    private List<T> storage = new List<T>();

    public int Length => storage.Count;

    public MyHeap(IComparer<T> comparer)
    {
        storage.Add(default);
        this.comparer = comparer;
    }

    private void DownHeap(int i, int n)
    {
        var ind = 2 * i;
        var val = storage[i];

        while (2 * i <= n)
        {
            if (ind + 1 <= n)
                if (comparer.Compare(storage[ind + 1], storage[ind]) > 0)
                    ind += 1;

            if (comparer.Compare(storage[ind], val) > 0)
            {
                storage[i] = storage[ind];
                i = ind;
                ind = 2 * i;
            }
            else
            {
                break;
            }

            storage[i] = val;
        }
    }

    private void UpHeap(int i)
    {
        var val = storage[i];

        while (i!= 1 && comparer.Compare(val, storage[i / 2]) > 0)
        {
            storage[i] = storage[i / 2];
            i /= 2;
        }
        storage[i] = val;
    }

    public void Add(T item)
    {
        storage.Add(item);
        UpHeap(storage.Count-1);
        
    }

    public void Delete(T item)
    {
        if (comparer.Compare(item, storage[1]) != 0)
        {
            Console.WriteLine("TRYING TO DELETE NODE OTHER THAN ROOT");
            return;
        }
        (storage[1], storage[^1]) = (storage[^1], storage[1]);
        storage.RemoveAt(storage.Count-1);
        
        
        DownHeap(1,storage.Count-1);
    }

    public T this[int index]
    {
        get => storage[index];
        set => storage[index] = value;
    }
    
    public IMyIterator<T> CreateForwardIterator()
    {
        return new HeapForwardIterator<T>(this);
    }

    public IMyIterator<T> CreateReverseIterator()
    {
        return new HeapReverseIterator<T>(this);
    }

    public override string ToString()
    {
        string val = String.Empty;
        for(int i=1; i<storage.Count; i++)
            val += $"{storage[i]}\n";
        return val;
    }
}