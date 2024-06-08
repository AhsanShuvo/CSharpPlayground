using System;

namespace ConsoleApplication.Caches
{
	public class LinkedListNode<T, V>
	{
        public LinkedListNode<T, V> Prev { get; set; }
        public LinkedListNode<T, V> Next { get; set; }
        public T Key { get; set; }
        public V Value { get; set; }

        public LinkedListNode(T key, V value)
        {
            Key = key;
            Value = value;
        }
    }
}

