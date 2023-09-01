using HackerNewsBestStoriesService.Dto;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace HackerNewsBestStoriesService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HackerNewsController : ControllerBase
    {
        private readonly IHackerNewsService _hackerNewsService;
        private readonly ILogger<HackerNewsController> _logger;

        public HackerNewsController(IHackerNewsService hackerNewsService, ILogger<HackerNewsController> logger)
        {
            _hackerNewsService = hackerNewsService;
            _logger = logger;
        }

        [HttpGet("beststories/{count}")]
        public async Task<IEnumerable<BestStoriesDto>> Get(int count)
        {
            return await _hackerNewsService.GetBestStories(count);
        }
    }
}