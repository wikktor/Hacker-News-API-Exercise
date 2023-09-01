using HackerNewsBestStoriesService.Dto;

namespace Services
{
    public interface IHackerNewsService
    {
        Task<IEnumerable<BestStoriesDto>> GetBestStories(int count);
    }
}