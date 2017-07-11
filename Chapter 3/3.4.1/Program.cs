class Program
{
    static void Main(string[] args)
    {
        HashTable hashTable = new HashTable();

        hashTable.Insert("E", "E");
        hashTable.Insert("A", "A");
        hashTable.Insert("S", "S");
        hashTable.Insert("Y", "Y");
        hashTable.Insert("Q", "Q");
        hashTable.Insert("U", "U");
        hashTable.Insert("T", "T");
        hashTable.Insert("I", "I");
        hashTable.Insert("O", "O");
        hashTable.Insert("N", "N");
    }
}

public class Node
{
    public string Key { get; set; }
    public string Data { get; set; }
    public Node Next { get; set; }
}

public class LinkedList
{
    private Node _head;

    public void Add(string key, string data)
    {
        if (_head == null)
        {
            _head = new Node();
            _head.Key = key;
            _head.Data = data;

            return;
        }

        Node node = _head;

        while (node.Next != null)
        {
            // Update if exists.
            if (node.Key.Equals(key))
            {
                node.Data = data;

                return;
            }

            node = node.Next;
        }

        // Update tail if key exists. Insert at tail if key doesn't exist.
        if (node.Key.Equals(key))
        {
            node.Data = data;
        }
        else
        {
            node.Next = new Node();
            node.Next.Key = key;
            node.Next.Data = data;
        }
    }

    public string Get(string key)
    {
        if (_head == null)
        {
            return null;
        }

        Node node = _head;

        while (node != null)
        {
            if (node.Key.Equals(key))
            {
                return node.Data;
            }

            node = node.Next;
        }

        return null;
    }
}

public class HashTable
{
    private readonly int _asciiDiff = 64;
    private readonly int _capacity = 5;
    private LinkedList[] _chains;

    public HashTable()
    {
        _chains = new LinkedList[_capacity];

        for (int i = 0; i < _capacity; i++)
        {
            _chains[i] = new LinkedList();
        }
    }

    public string Get(string key)
    {
        int index = GetHashCode(key[0]);

        return _chains[index].Get(key);
    }

    public void Insert(string key, string data)
    {
        int index = GetHashCode(key[0]);

        _chains[index].Add(key, data);
    }

    private int GetHashCode(char key)
    {
        return 11 * (key - _asciiDiff) % _capacity;
    }
}
