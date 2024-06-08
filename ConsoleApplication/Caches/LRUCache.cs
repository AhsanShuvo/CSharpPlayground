using System;


namespace ConsoleApplication.Caches
{
    public class LRUCache<T, V>
    {
        private int cacheSize;
        private DoublyLinkedList<T, V> List;
        private Dictionary<T, LinkedListNode<T, V> > Cache;

        public LRUCache(int size, T initKey, V initValue)
        {
            cacheSize = size;
            List = new DoublyLinkedList<T, V>(initKey, initValue);
            Cache = new Dictionary<T, LinkedListNode<T, V>>();
        }

        public V Get(T key)
        {
            if (Cache.ContainsKey(key))
            {
                var removedNode = Cache[key];
                List.Remove(removedNode);
                var node = List.Append(key, removedNode.Value);
                Cache[key] = node;
                return node.Value;
            }
            else return List.Head.Value;
        }

        public void Put(T key, V value)
        {
            if (Cache.ContainsKey(key))
            {
                List.Remove(Cache[key]);
                var node = List.Append(key, value);
                Cache[key] = node;
            }
            else
            {
                var node = List.Append(key, value);
                Cache[key] = node;
                if (List.Size > cacheSize)
                {
                    var removedNode = List.Pop;
                    List.Remove(removedNode);
                    Cache.Remove(removedNode.Key);
                }
            }
        }

    }
}

