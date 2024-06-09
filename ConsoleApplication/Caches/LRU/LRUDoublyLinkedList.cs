using System;

namespace ConsoleApplication.Caches
{
	public class LRUDoublyLinkedList<T, V>
    {
        public LRULinkedListNode<T, V> Head { get; }
        public LRULinkedListNode<T, V> Tail { get; }
        public int Size { get; set; }

        public LRUDoublyLinkedList(T key, V value)
        {
            Size = 0;
            Head = new LRULinkedListNode<T, V>(key, value);
            Tail = new LRULinkedListNode<T, V>(key, value);
            Head.Next = Tail;
            Tail.Prev = Head;
        }

        public LRULinkedListNode<T, V> Append(T key, V value)
        {
            var node = new LRULinkedListNode<T, V>(key, value);
            Tail.Prev.Next = node;
            node.Next = Tail;
            node.Prev = Tail.Prev;
            Tail.Prev = node;

            Size += 1;

            return node;
        }

        public void Remove(LRULinkedListNode<T, V> node)
        {
            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;

            Size -= 1;
        }

        public LRULinkedListNode<T, V> Pop => Head.Next;
	}
}

