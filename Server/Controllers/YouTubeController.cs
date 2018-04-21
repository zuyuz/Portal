using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreSpa.Server.Services;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreSpa.Server.Controllers
{
    [Route("api/youtube")]
    public class YouTubeController : Controller
    {

        [HttpGet(template: "search")]
        public async Task<ActionResult> Search(string searchText = "Silicon valley", int count = 10)
        {
            try
            {
                var service = new YoutubeService();
                var searchResult = await service.Search(searchText, count);

                return Ok(searchResult);
            }
            catch (AggregateException ex)
            {
                foreach (var e in ex.InnerExceptions)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
                
                return BadRequest();
            }
        }
    }
}