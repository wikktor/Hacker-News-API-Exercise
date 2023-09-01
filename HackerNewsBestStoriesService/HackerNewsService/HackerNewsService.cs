using HackerNewsBestStoriesService.Dto;
using HackerNewsBestStoriesService.HackerNewsClient;

namespace Services
{
    public class HackerNewsService: IHackerNewsService
    {
        private readonly IHackerNewsClient _client;

        public HackerNewsService(IHackerNewsClient client) {
            _client = client;
        }

        public async Task<IEnumerable<BestStoriesDto>> GetBestStories(int count)
        {
            var bestStories = await _client.GetBestStoriesIds();

            var output = new List<Task<BestStoriesDto>>();
            for (int i = 0; i < bestStories.Count && i < count; i++) 
            {
                int story = bestStories[i];
                output.Add(GetStoryFromId(story));
            }
            Task.WaitAll(output.ToArray());
            
            return output.Select(x => x.Result).OrderByDescending(x => x.Score);
        }

        public async Task<BestStoriesDto> GetStoryFromId(int id)
        {
            var result = await _client.GetItem(id);
            return new BestStoriesDto
            {
                Title = result.Title,
                PostedBy = result.By,
                Score = result.Score,
                CommentCount = result.Descendants,
                Time = DateTimeOffset.FromUnixTimeSeconds(result.Time).DateTime,
                Uri = result.Url
            };
        }

    }
}