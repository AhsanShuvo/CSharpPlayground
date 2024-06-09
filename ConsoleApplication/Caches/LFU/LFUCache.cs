using System.Collections.Generic;

namespace ConsoleApplication.Caches.LFU
{
	public class LFUCache<T, V>
	{
		private int _cacheSize;
        private LFUDoublyLinkedList<T, V> _list;
        private Dictionary<T, LFULinkedListNode<T, V> > _cache;
		private Dictionary<int, LFULinkedListNode<T, V>> _nodeFrequentPerNumber;

        public LFUCache(int size, T initKey, V initValue)
		{
			_cacheSize = size;
			_list = new LFUDoublyLinkedList<T, V>(initKey, initValue);
			_cache = new Dictionary<T, LFULinkedListNode<T, V>>();
			_nodeFrequentPerNumber = new Dictionary<int, LFULinkedListNode<T, V>>();
        }

        public void Put(T key, V value)
        {
            if (_cache.ContainsKey(key))
            {
                var removedNode = _cache[key];
                var pos = FindNextPosition(removedNode.Counter);
                UpdateFrequency(removedNode);
                _list.Remove(removedNode);
                
                var node = _list.Append(key, value, pos);
                _cache[key] = node;
                _nodeFrequentPerNumber[removedNode.Counter + 1] = node;
                node.Counter = removedNode.Counter + 1;
            }
            else
            {
                if (_list.Size == _cacheSize)
                {
                    var removedNode = _list.Pop();
                    _list.Remove(removedNode);
                    _cache.Remove(removedNode.Key);
                    if (_nodeFrequentPerNumber[removedNode.Counter] == removedNode) _nodeFrequentPerNumber.Remove(removedNode.Counter);
                }
                var nextNode = FindNextPosition(1);
                var node = _list.Append(key, value, nextNode);
                node.Counter = 1;
                _cache[key] = node;
                _nodeFrequentPerNumber[1] = node;
            }
        }

        public V Get(T key)
        {
            if (_cache.ContainsKey(key))
            {
                var removedNode = _cache[key];
                var nextNode = FindNextPosition(removedNode.Counter);
                UpdateFrequency(removedNode);
                _list.Remove(removedNode);
                
                var node = _list.Append(key, removedNode.Value, nextNode);
                _cache[key] = node;
                _nodeFrequentPerNumber[removedNode.Counter + 1] = node;
                node.Counter = removedNode.Counter + 1;
                return node.Value;
            }
            else return _list.Head.Value;
        }

        private void UpdateFrequency(LFULinkedListNode<T, V> node)
        {
            var prevNode = node.Prev;
            var nextNode = node.Next;

            if (prevNode.Counter == node.Counter) _nodeFrequentPerNumber[node.Counter] = prevNode;
            else if (nextNode.Counter == node.Counter) _nodeFrequentPerNumber[node.Counter] = nextNode;
            else _nodeFrequentPerNumber.Remove(node.Counter);
        }

        private LFULinkedListNode<T, V> FindNextPosition(int counter)
        {
            if (_nodeFrequentPerNumber.ContainsKey(counter))
            {
                var nextNode = _nodeFrequentPerNumber[counter].Next;
                if (nextNode.Counter == counter + 1) return nextNode.Next;
                else return nextNode;
            }
            else return _list.Head.Next;
        }
    }
}

