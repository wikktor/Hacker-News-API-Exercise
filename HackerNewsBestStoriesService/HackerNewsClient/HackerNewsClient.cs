namespace HackerNewsBestStoriesService.HackerNewsClient
{
    public class HackerNewsClient: IHackerNewsClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HackerNewsClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IList<int>> GetBestStoriesIds()
        {
            var client = _httpClientFactory.CreateClient("HackerNews");
            return await client.GetFromJsonAsync<IList<int>>("beststories.json") ?? new List<int>(); //TODO: handle errors properly
        }
        public async Task<HackerNewsItemDto?> GetItem(int id)
        {
            var client = _httpClientFactory.CreateClient("HackerNews");
            return await client.GetFromJsonAsync<HackerNewsItemDto>($"item/{id}.json");
        }
    }
}
