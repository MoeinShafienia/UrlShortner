using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bitly.Models;

namespace Bitly.Controllers
{
    [Route("/redirect/{*shortUrl}")]
    [ApiController]
    public class LongUrlController : ControllerBase
    {

        private readonly ILogger<LongUrlController> _logger;
        private readonly AppDbContext _appDbContext;
    

        public LongUrlController(ILogger<LongUrlController> logger,AppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        
        [HttpGet]
        public IActionResult Get(string shortUrl) {
            if (shortUrl == null){
                return BadRequest();
            }
            
            Url url = _appDbContext.Urls.Find(shortUrl);
            
            if (url == null) {
                return NotFound();
            }
            return Redirect(url.LongUrl);
            //find longUrl
        }

        // public Url GetLongUrl(string shortUrl){
        //     return _urlShortner.get(shortUrl);
        // }
    }
}