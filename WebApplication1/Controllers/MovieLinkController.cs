using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieLinkController : ControllerBase
    {
        private readonly IMovieLinkRepository _movieLinkRepository;

        public MovieLinkController(IMovieLinkRepository movieLinkRepository)
        {
            _movieLinkRepository = movieLinkRepository;
        }

        
    }
}
