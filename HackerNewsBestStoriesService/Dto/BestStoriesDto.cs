namespace HackerNewsBestStoriesService.Dto
{
    public record BestStoriesDto
    {
        public required string Title { get; init; }
        public required string Uri { get; init; }
        public required string PostedBy { get; init; }
        public DateTime Time { get; init; }
        public int Score { get; init; }
        public int CommentCount { get; init; }

    }
}
