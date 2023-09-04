using LazyCache;

namespace HackerNewsBestStoriesService.HackerNewsClient
{
    public class CachedHackerNewsClient : IHackerNewsClient
    {
        private readonly IHackerNewsClient _hackerNewsClient;
        private readonly IAppCache _cache;
        private readonly int _cacheExpirationTimeout;

        public CachedHackerNewsClient(IHackerNewsClient hackerNewsClient, IAppCache cache, int cacheExpirationTimeoutMinutes)
        {
            _hackerNewsClient = hackerNewsClient;
            _cache = cache;
            _cacheExpirationTimeout = cacheExpirationTimeoutMinutes;
        }

        public async Task<IList<int>> GetBestStoriesIds()
        {
            return await _cache.GetOrAddAsync("list", () =>  _hackerNewsClient.GetBestStoriesIds(), DateTimeOffset.Now.AddMinutes(_cacheExpirationTimeout));
        }

        public async Task<HackerNewsItemDto?> GetItem(int id)
        {
            return await _cache.GetOrAddAsync($"i:{id}", () =>  _hackerNewsClient.GetItem(id), DateTimeOffset.Now.AddMinutes(_cacheExpirationTimeout));
        }
    }
}
