using ConsoleApplication.BuilderPattern;
using ConsoleApplication.Caches;

//BankAccount account = new BankAccount(199, "Ahsan", 100.0);

//BankAccountV2 account2 = new BankAccountBuilder()
//                            .WithAccountNumber(100L)
//                            .WithOwner("Ahsan")
//                            .WithBalance(100)
//                            .WithBranch("Bangkok")
//                            .WithInterestRate(5.6)
//                            .Build();


var cacheIntType = new LRUCacheManagerInt(2);
var cacheStringType = new LRUCacheManagerString(2);

cacheIntType.Execute();
cacheStringType.Execute();

