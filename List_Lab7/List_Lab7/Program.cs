using System.Collections;

public class LinkedList<T> : IEnumerable<T>
{
    private class Node<U>
    {
        public U Value { get; set; }
        public Node<U> Next { get; set; }

        public Node(U value)
        {
            Value = value;
            Next = null;
        }
    }

    private Node<T> head;
    private Node<T> tail;
    private int count;

    public LinkedList()
    {
        head = null;
        tail = null;
        count = 0;
    }
    
    public void AddFirst(T item)
    {
        var newNode = new Node<T>(item);
        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            newNode.Next = head;
            head = newNode;
        }
        count++;
    }

    public void AddLast(T item)
    {
        var newNode = new Node<T>(item);
        if (tail == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            tail = newNode;
        }
        count++;
    }

    public void Clear()
    {
        head = null;
        tail = null;
        count = 0;
    }

    public T Find(T item)
    {
        var current = head;
        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Value, item))
                return current.Value;
            current = current.Next;
        }
        return default; 
    }

    public bool Contains(T item)
    {
        return Find(item) != null && !EqualityComparer<T>.Default.Equals(Find(item), default(T));
    }
    
    public T FindLast()
    {
        return tail != null ? tail.Value : default; 
    }

    public bool Remove(T item)
    {
        if (head == null) return false;

        if (EqualityComparer<T>.Default.Equals(head.Value, item))
        {
            RemoveFirst();
            return true;
        }

        var current = head;
        while (current.Next != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Next.Value, item))
            {
                current.Next = current.Next.Next;
                count--;
                if (current.Next == null)
                {
                    tail = current;
                }
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public void RemoveFirst()
    {
        if (head == null) return;

        head = head.Next;
        count--;

        if (head == null)
            tail = null;
    }

    public void RemoveLast()
    {
        if (head == null) return;

        if (head == tail)
        {
            head = null;
            tail = null;
        }
        else
        {
            var current = head;
            while (current.Next != tail)
            {
                current = current.Next;
            }
            current.Next = null;
            tail = current;
        }
        count--;
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    public IEnumerator<T> GetEnumerator()
    {
        var current = head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }


}
public class Program
{
    public static void Main()
    {
        var list = new LinkedList<string>();
        list.AddFirst("qwrwqrq");
        list.AddLast("2");
        list.AddLast("3");
        list.AddLast("4");
        list.AddLast("5");

        Console.WriteLine("List elements:");
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine($"Contains 2: {list.Contains("2")}");
        list.Remove("2");
        Console.WriteLine($"Contains 2 after removal: {list.Contains("2")}");
        
        list.RemoveFirst();
        Console.WriteLine($"Last element (tail): {list.FindLast()}");
        list.RemoveLast();
        Console.WriteLine("REMOVED TAIL");
        Console.WriteLine($"Last element (tail): {list.FindLast()}");
        Console.WriteLine("List after removals:");
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }
}
