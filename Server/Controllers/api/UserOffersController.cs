using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetCoreSpa.Server;
using AspNetCoreSpa.Server.Entities;
using AspNetCoreSpa_master.Server.Entities;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreSpa.Server.Controllers.api
{
    [Produces("application/json")]
    [Route("api/UserOffers")]
    public class UserOffersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private SignInManager<ApplicationUser> _signInManager;

        public UserOffersController(ApplicationDbContext context,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        // GET: api/UserOffers
        [HttpGet]
        public IEnumerable<UserOffer> GetUserOffers()
        {
            return _context.UserOffers.Include("Price");
        }

        // GET: api/SpecificUserOffers
        [HttpGet("UserOffers")]
        public async Task<IActionResult> GetUserOffersAsync()
        {
            var offers = _context
                .UserOffers.Where(ud => ud.UserEmail != null).Include("Price");
            return Ok(offers);
        }

        // GET: api/SpecificUserOffers
        [HttpGet("SpecificUserOffers")]
        public async Task<IActionResult> GetSpecificUserOffersAsync()
        {
            var user = await _signInManager.UserManager.GetUserAsync(HttpContext.User);

            if (user == null)
            {
                return Unauthorized();
            }

            var offers = _context
                .UserOffers.Include("Price").Where(ud => ud.UserEmail == user.Email);
            return Ok(offers);
        }
        // GET: api/UserOffers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserOffer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userOffer = await _context.UserOffers.SingleOrDefaultAsync(m => m.Id == id);

            if (userOffer == null)
            {
                return NotFound();
            }

            return Ok(userOffer);
        }

        // PUT: api/UserOffers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserOffer([FromRoute] int id, [FromBody] UserOffer userOffer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userOffer.Id)
            {
                return BadRequest();
            }

            _context.Entry(userOffer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserOfferExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserOffers
        [HttpPost]
        public async Task<IActionResult> PostUserOffer(string description, double price, int bookId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _signInManager.UserManager.GetUserAsync(HttpContext.User);

            if (user == null)
            {
                return Unauthorized();
            }

            var model = new UserOffer()
                {
                    BookId = bookId,
                    UserEmail = user.Email,
                    Price = new Price()
                    {
                    PriceType = PriceType.Paid,
                    Value = price
                },
                Description = description
            };

            _context.UserOffers.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserOffer", new { id = model.Id }, model);
        }

        // DELETE: api/UserOffers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserOffer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userOffer = await _context.UserOffers.SingleOrDefaultAsync(m => m.Id == id);
            if (userOffer == null)
            {
                return NotFound();
            }

            _context.UserOffers.Remove(userOffer);
            await _context.SaveChangesAsync();

            return Ok(userOffer);
        }

        private bool UserOfferExists(int id)
        {
            return _context.UserOffers.Any(e => e.Id == id);
        }
    }
}