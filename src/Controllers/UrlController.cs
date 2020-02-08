using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using src.Models;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace src.Controllers
{
    [Route("/urls")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly ILogger<UrlController> _logger;
        private readonly AppDbContext _appDbContext;

        public UrlController(ILogger<UrlController> logger,AppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        
        [HttpPost]
        public IActionResult post([FromBody]Url url) {
            
            if (url.LongUrl.Equals("")){
                return BadRequest();
            }
            
            if (!isValid(url.LongUrl)){
                return BadRequest();
            }

            string shortUrl2;
            do{
                shortUrl2 = RandomString(8);
                if (_appDbContext.Urls.Find(shortUrl2) == null) {
                break;
            }
            }while(true);

            url.ShortUrl = shortUrl2;
            _appDbContext.Add(url);
            _appDbContext.SaveChanges();

            return Ok(url);
        }

        public static bool isValid(string url){
            Regex regex =new Regex(@"((www\.|(http|https|ftp|news|file)+\:\/\/)[_.a-z0-9-]+\.[a-z0-9\/_:@=.+?,##%&~-]*[^.|\'|\# |!|\(|?|,| |>|<|;|\)])");
            Match match= regex.Match(url);
            return match.Success;
        }

        public string RandomString(int length)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }
    }
}