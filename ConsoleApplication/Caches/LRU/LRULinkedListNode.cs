using System;

namespace ConsoleApplication.Caches
{
	public class LRULinkedListNode<T, V>
    {
        public LRULinkedListNode<T, V> Prev { get; set; }
        public LRULinkedListNode<T, V> Next { get; set; }
        public T Key { get; set; }
        public V Value { get; set; }

        public LRULinkedListNode(T key, V value)
        {
            Key = key;
            Value = value;
        }
    }
}

