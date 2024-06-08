using System;

namespace ConsoleApplication.Caches
{
	public class DoublyLinkedList<T, V>
    {
        public LinkedListNode<T, V> Head { get; }
        public LinkedListNode<T, V> Tail { get; }
        public int Size { get; set; }

        public DoublyLinkedList(T key, V value)
        {
            Size = 0;
            Head = new LinkedListNode<T, V>(key, value);
            Tail = new LinkedListNode<T, V>(key, value);
            Head.Next = Tail;
            Tail.Prev = Head;
        }

        public LinkedListNode<T, V> Append(T key, V value)
        {
            var node = new LinkedListNode<T, V>(key, value);
            Tail.Prev.Next = node;
            node.Next = Tail;
            node.Prev = Tail.Prev;
            Tail.Prev = node;

            Size += 1;

            return node;
        }

        public void Remove(LinkedListNode<T, V> node)
        {
            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;

            Size -= 1;
        }

        public LinkedListNode<T, V> Pop => Head.Next;
	}
}

