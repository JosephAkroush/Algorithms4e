  class Program
  {
      static void Main(string[] args)
      {
          SeparateChainingHashSymbolTable<string, string> symbolTable = new SeparateChainingHashSymbolTable<string, string>();

          symbolTable.Put("H", "H");
          symbolTable.Put("E", "E");
          symbolTable.Put("L", "L");
          symbolTable.Put("L", "L");
          symbolTable.Put("O", "O");
          symbolTable.Put("W", "W");
          symbolTable.Put("O", "O");
          symbolTable.Put("R", "R");
          symbolTable.Put("L", "L");
          symbolTable.Put("D", "D");

          Console.WriteLine(symbolTable.Get("H") ?? "NOT FOUND");
          Console.WriteLine(symbolTable.Get("L") ?? "NOT FOUND");
          Console.WriteLine(symbolTable.Get("Q") ?? "NOT FOUND");
      }
  }

  public class SeparateChainingHashSymbolTable<K, V>
  {
      private int _m;
      private Node<K, V>[] _nodes;

      public SeparateChainingHashSymbolTable()
          : this(997)
      {
      }

      public SeparateChainingHashSymbolTable(int m)
      {
          _m = m;

          _nodes = new Node<K, V>[_m];

          for (int i = 0; i < _m; i++)
          {
              _nodes[i] = new Node<K, V>();
          }
      }

      public V Get(K key)
      {
          int index = GetHashCode(key);

          Node<K, V> node = _nodes[index];

    // Head of linked list is empty
          // Note: I understand K can be a value type where the null comparison is invalid
    if (node.Key == null)
    {
              return default(V);
    }

          while (node != null)
          {
              if (node.Key.Equals(key))
              {
                  return node.Data;
              }

              node = node.Next;
          }

          return default(V);
      }

      public void Put(K key, V data)
      {
          int index = GetHashCode(key);

          Node<K, V> node = _nodes[index];

    // Head of linked list is empty
    // Note: I understand K can be a value type where the null comparison is invalid
    if (node.Key == null)
          {
              node.Key = key;
              node.Data = data;

              return;
          }

          while (node.Next != null)
          {
              if (node.Key.Equals(key))
              {
                  node.Data = data;

                  return;
              }

              node = node.Next;
          }

          if (node.Key.Equals(key))
          {
              node.Data = data;
          }
          else
          {
              node.Next = new Node<K, V>();
              node.Next.Key = key;
              node.Next.Data = data;
          }
      }

      private int GetHashCode(K key)
      {
          return (key.GetHashCode() & 0x7fffffff) % _m;
      }
  }

  public class Node<K, V>
  {
      public K Key { get; set; }
      public V Data { get; set; }
      public Node<K, V> Next { get; set; }
  }
