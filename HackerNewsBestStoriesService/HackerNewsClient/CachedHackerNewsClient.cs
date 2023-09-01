using LazyCache;

namespace HackerNewsBestStoriesService.HackerNewsClient
{
    public class CachedHackerNewsClient : IHackerNewsClient
    {
        private readonly IHackerNewsClient _hackerNewsClient;
        private readonly IAppCache _cache;

        public CachedHackerNewsClient(IHackerNewsClient hackerNewsClient, IAppCache cache)
        {
            _hackerNewsClient = hackerNewsClient;
            _cache = cache;
        }

        public async Task<IList<int>> GetBestStoriesIds()
        {
            return await _cache.GetOrAddAsync("list", () =>  _hackerNewsClient.GetBestStoriesIds(), DateTimeOffset.Now.AddMinutes(5));
        }

        public async Task<HackerNewsItemDto?> GetItem(int id)
        {
            return await _cache.GetOrAddAsync($"i:{id}", () =>  _hackerNewsClient.GetItem(id), DateTimeOffset.Now.AddMinutes(5));
        }
    }
}
