using System.Net.Http;

namespace HackerNewsBestStoriesService.HackerNewsClient
{
    public interface IHackerNewsClient
    {
        public Task<IList<int>> GetBestStoriesIds();
        public Task<HackerNewsItemDto?> GetItem(int id);
    }
}