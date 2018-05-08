using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreSpa.Server.Entities;
using AspNetCoreSpa.Server.Services;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreSpa.Server.Controllers
{
    [Route("api/youtube")]
    public class YouTubeController : Controller
    {
        ApplicationDbContext _applicationDbContext;
        private readonly IOptions<RequestLocalizationOptions> _locOptions;
        private readonly IHttpContextAccessor _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IStringLocalizer<ApplicationDataService> _stringLocalizer;
        private readonly IMemoryCache _cache;
        public YouTubeController(ApplicationDbContext applicationDbContext,
        IOptions<RequestLocalizationOptions> locOptions,
            IHttpContextAccessor context,
            SignInManager<ApplicationUser> signInManager,
            IStringLocalizer<ApplicationDataService> stringLocalizer,
            IMemoryCache memoryCache)
        {
            _locOptions = locOptions;
            _context = context;
            _signInManager = signInManager;
            _stringLocalizer = stringLocalizer;
            _cache = memoryCache;
            _applicationDbContext = applicationDbContext;
        }

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
        [HttpPost(template: "like")]
        public async Task<ActionResult> Like(string id, bool isFavorite){
        
            try
            {
                var user = await _signInManager.UserManager.GetUserAsync(HttpContext.User);

                var favor = _applicationDbContext
                    .YoutubeFavorites
                    .FirstOrDefault(yf => yf.UserEmail == user.Email && yf.VideoId == id);

                if (favor != null || !isFavorite)
                {
                    _applicationDbContext
                        .YoutubeFavorites
                        .Remove(favor);
                }
                else
                {
                    _applicationDbContext.YoutubeFavorites.Add(new YoutubeFavorite(){
                        VideoId = id,
                        UserEmail = user.Email
                    });
                }
                _applicationDbContext.SaveChanges();
                return Ok(_applicationDbContext.YoutubeFavorites.ToList());
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

        [HttpGet(template: "userfavorite")]
        public async Task<ActionResult> GetCurrentUserFavorite()
        {
            try
            {
                var user = await _signInManager.UserManager.GetUserAsync(HttpContext.User);

                var favorites = _applicationDbContext
                    .YoutubeFavorites
                    .Where(yf => yf.UserEmail == user.Email);

                return Ok(favorites);
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