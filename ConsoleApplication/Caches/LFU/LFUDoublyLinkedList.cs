
namespace ConsoleApplication.Caches.LFU
{
	public class LFUDoublyLinkedList<T, V>
	{
        public LFULinkedListNode<T, V> Head { get; }
        public LFULinkedListNode<T, V> Tail { get; }
        public int Size { get; set; }

        public LFUDoublyLinkedList(T initKey, V initValue)
		{
			this.Size = 0;
			this.Head = new LFULinkedListNode<T, V>(initKey, initValue);
			this.Tail = new LFULinkedListNode<T, V>(initKey, initValue);
            this.Head.Next = Tail;
            this.Tail.Prev = Head;
		}

        public LFULinkedListNode<T, V> Append(T key, V value, LFULinkedListNode<T, V> nextNode)
        {
            var node = new LFULinkedListNode<T, V>(key, value);
            nextNode.Prev.Next = node;
            node.Next = nextNode;
            node.Prev = nextNode.Prev;
            nextNode.Prev = node;

            Size += 1;

            return node;
        }

        public void Remove(LFULinkedListNode<T, V> node)
        {
            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;
            Size -= 1;
        }

        public LFULinkedListNode<T, V> Pop()
        {
            return Head.Next;
        }
    }
}

