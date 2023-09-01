namespace HackerNewsBestStoriesService.HackerNewsClient
{
    public class HackerNewsItemDto
    {
        public string By { get; init; }
        public int Id { get; init; }
        public int Score { get; init; }
        public int Time { get; init; }
        public string Title {  get; init; }
        public int Descendants { get; init; }
        public string Url { get; init; }    
    }
}
