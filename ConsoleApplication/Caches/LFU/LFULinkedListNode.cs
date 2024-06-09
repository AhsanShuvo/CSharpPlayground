using System;

namespace ConsoleApplication.Caches.LFU
{
	public class LFULinkedListNode<T, V>
	{
        public LFULinkedListNode<T, V> Prev { get; set; }
        public LFULinkedListNode<T, V> Next { get; set; }
        public T Key { get; set; }
        public V Value { get; set; }
        public int Counter { get; set; }

		public LFULinkedListNode(T key, V value)
		{
			this.Key = key;
			this.Value = value;
			this.Counter = 0;
		}
	}
}

