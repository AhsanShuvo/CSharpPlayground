using System;

namespace ConsoleApplication.Caches
{
	public class LRUCacheManagerString : BaseCacheManager
	{
        public List<List<string>> list = new List<List<string>>() {
            new List<string>() { "Thailand" },
            new List<string>() { "Bangladesh", "Dhaka" },
            new List<string>() {"India", "Delhi"},
            new List<string>() { "India" },
            new List<string>() { "Thailand", "Bangkok" },
            new List<string>() { "Bangladesh" },
            new List<string>() { "England", "London" },
            new List<string>() { "Thailand" },
            new List<string>() { "England" },
            new List<string>() { "India" }
        };

        private LRUCache<string, string> _cache;

        public LRUCacheManagerString(int size)
        {
            _cache = new LRUCache<string, string>(size, string.Empty, "not_found");
        }

        public override void Execute()
        {
            foreach(var item in list)
            {
                if(item.Count == 2)
                {
                    _cache.Put(item[0], item[1]);
                }
                else
                {
                    string ans = _cache.Get(item[0]);
                    Console.WriteLine("For Key: " + item[0] + " Value: " + ans);
                }
            }
        }
    }
}

