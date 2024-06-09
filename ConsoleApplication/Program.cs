using ConsoleApplication.BuilderPattern;
using ConsoleApplication.Caches;
using ConsoleApplication.Caches.LFU;

//BankAccount account = new BankAccount(199, "Ahsan", 100.0);

//BankAccountV2 account2 = new BankAccountBuilder()
//                            .WithAccountNumber(100L)
//                            .WithOwner("Ahsan")
//                            .WithBalance(100)
//                            .WithBranch("Bangkok")
//                            .WithInterestRate(5.6)
//                            .Build();


//var cacheIntType = new LRUCacheManagerInt(2);
//var cacheStringType = new LRUCacheManagerString(2);

//cacheIntType.Execute();
//cacheStringType.Execute();


List<List<int>> list = new List<List<int>>()
{
    new List<int>(){1, 1},
    new List<int>(){2, 2},
    new List<int>(){1},
    new List<int>(){3, 3},
    new List<int>(){2},
    new List<int>(){3},
    new List<int>(){4, 4},
    new List<int>(){1},
    new List<int>(){3},
    new List<int>(){4}
    };


var cache = new LFUCache<int, int>(2, 0, -1);

foreach(var item in list)
{
    if(item.Count == 2)
    {
        cache.Put(item[0], item[1]);
    }
    else
    {
        int ans = cache.Get(item[0]);
        Console.WriteLine(ans);
    }
}


