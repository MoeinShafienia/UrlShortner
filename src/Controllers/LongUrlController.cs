using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using src.Models;
using System;

namespace src.Controllers
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

            if (shortUrl.Length != 8){
                return BadRequest();
            }

            for(int i=0;i < shortUrl.Length ; i++) {
                if (!char.IsLetter(shortUrl,i)){
                    return BadRequest();
                }
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