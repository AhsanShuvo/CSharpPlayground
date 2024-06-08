using System;

namespace ConsoleApplication.Caches
{
    public class LRUCacheManagerInt : BaseCacheManager
    {
        public List<List<int>> list = new List<List<int>>() {
            new List<int>() { 1, 1 },
            new List<int>() {2, 2},
            new List<int>() { 1 },
            new List<int>() { 3, 3 },
            new List<int>() { 2 },
            new List<int>() { 4, 4 },
            new List<int>() { 1 },
            new List<int>() { 3 },
            new List<int>() { 4 }
        };

        private LRUCache<int, int> _cache;

        public LRUCacheManagerInt(int size)
        {
            _cache = new LRUCache<int, int>(size, 0, -1);
        }

        public override void Execute()
        { 
            foreach (var item in list)
            {
                if (item.Count == 2)
                {
                    _cache.Put(item[0], item[1]);
                }
                else
                {
                    int ans = _cache.Get(item[0]);
                    Console.WriteLine(ans);
                }
            }
        }
    }
}

