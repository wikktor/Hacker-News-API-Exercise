Assumptions:
 - Best stories ranking and scores change slowly, and we do not need to take all data from single point in time
 - Worst result of cashing each item independently is could be that list of best stories is not consistant with scores in them
   This would result with higher ranking story to have lower score than one afther that. 
   Soultion to that is to reorder them after all data is collected.
 - Time for a request should not take more than few secconds even for largest "n". - Concurency in requests is required (without that it can take about 2 min for n=200 )
 - Caching should be seperated from client and service. CachedHackerNewsClient decorator was added.
 - LazyCache instead of memoryCache used to guarantee minimal number of requests to HackerNewsAPI



Enhancements or changes you would make, given the time:
- Error handling is to be implemented (There is Polly added  - so risk should be low)
- Put more description on controler and model for better OPEN API 
- Split to multiple projects ( Dto and service seperatly)
- Unit tests
- Integration tests
- In case it would need to be hosted on multiple instances - distributed cashe would be an upgrade. For example Redis.